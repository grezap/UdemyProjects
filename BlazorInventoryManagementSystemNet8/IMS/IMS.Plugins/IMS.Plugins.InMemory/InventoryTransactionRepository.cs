using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryTransactionRepository : IInventoryTransactionRepository
    {
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
        #endregion
    }
}
