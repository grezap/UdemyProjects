using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryTransactionRepository : IInventoryTransactionRepository
    {
        #region Fields
        private readonly IInventoryRepository _inventoryRepository;
        #endregion

        #region Constructor
        public InventoryTransactionRepository(IInventoryRepository inventoryRepository)
        {
            this._inventoryRepository = inventoryRepository;
        } 
        #endregion

        #region Properties
        public List<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();
        #endregion

        #region Methods
        public async Task PurchaseAsync(string poNumber, Inventory inventory, int quantity, string doneBy, double price)
        {
            InventoryTransactions.Add(new InventoryTransaction 
            {
                PONumber = poNumber,
                InventoryId = inventory.InventoryId,
                QuantityBefore = inventory.Quantity,
                ActivityType = InventoryTransactionType.PurchaseInventory,
                QuantityAfter = inventory.Quantity+ quantity,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy,
                UnitPrice = price
            });
        }
        public async Task ProduceAsync(string productionNumber, Inventory inventory, int quantityToConsume, string doneBy, double price)
        {
            InventoryTransactions.Add(new InventoryTransaction
            {
                ProductionNumber = productionNumber,
                InventoryId = inventory.InventoryId,
                QuantityBefore = inventory.Quantity,
                ActivityType = InventoryTransactionType.ProdudeProduct,
                QuantityAfter = inventory.Quantity - quantityToConsume,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy,
                UnitPrice = price
            });
        }

        public async Task<IEnumerable<InventoryTransaction>> GetInventoryTransactionsAsync(
            string inventoryName, 
            DateTime? dateFrom, 
            DateTime? dateTo, 
            InventoryTransactionType? inventoryTransactionType
            )
        {
            var inventories = (await _inventoryRepository.GetInventoriesByNameAsync(string.Empty)).ToList();
            var query = from it in InventoryTransactions
                        join inv in inventories on it.InventoryId equals inv.InventoryId
                        where (string.IsNullOrWhiteSpace(inventoryName) || inv.InventoryName.ToLower().IndexOf(inventoryName.ToLower()) >= 0)
                              && (!dateFrom.HasValue || it.TransactionDate >= dateFrom.Value.Date) 
                              && (!dateTo.HasValue || it.TransactionDate <= dateTo.Value.Date) 
                              && (!inventoryTransactionType.HasValue || it.ActivityType == inventoryTransactionType)
                        select new InventoryTransaction 
                        {
                            Inventory = inv,
                            InventoryTransactionId = it.InventoryTransactionId,
                            PONumber = it.PONumber,
                            InventoryId = it.InventoryId,
                            QuantityBefore = it.QuantityBefore,
                            QuantityAfter = it.QuantityAfter,
                            ActivityType = it.ActivityType,
                            TransactionDate = it.TransactionDate,
                            DoneBy = it.DoneBy,
                            UnitPrice = it.UnitPrice
                        }
                        ;
            return query;
        }
        #endregion
    }
}
