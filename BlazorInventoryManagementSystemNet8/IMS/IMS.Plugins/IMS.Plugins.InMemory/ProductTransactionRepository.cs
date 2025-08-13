using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class ProductTransactionRepository : IProductTransactionRepository
    {
        #region Fields
        private List<ProductTransaction> _productTransactions = new List<ProductTransaction>();
        private readonly IProductRepository _productRepository;
        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;
        private readonly IInventoryRepository _inventoryRepository;
        #endregion

        #region Constructor
        public ProductTransactionRepository(IProductRepository productRepository, IInventoryTransactionRepository inventoryTransactionRepository, IInventoryRepository inventoryRepository)
        {
            this._productRepository = productRepository;
            this._inventoryTransactionRepository = inventoryTransactionRepository;
            this._inventoryRepository = inventoryRepository;
        }
        #endregion

        #region Methods
        public async Task ProduceAsync(string productionNumber, Product product, int quantity, string doneBy)
        {
            var prod = await _productRepository.GetProductByIdAsync(product.ProductId);
            if (prod != null) 
            {
                foreach (var pi in prod.ProductInventories) 
                {
                    if(pi.Inventory != null)
                    {
                        await _inventoryTransactionRepository.ProduceAsync(productionNumber, pi.Inventory, pi.InventoryQuantity * quantity, doneBy, -1);
                        var inv = await _inventoryRepository.GetInventoryByIdAsync(pi.InventoryId);
                        inv.Quantity -= pi.InventoryQuantity * quantity;
                        await _inventoryRepository.UpdateInventoryAsync(inv);
                    }
                }
            }
            _productTransactions.Add(new ProductTransaction 
            {
                ProductionNumber = productionNumber,
                ProductId = product.ProductId,
                QuantityBefore = product.Quantity,
                QuantityAfter = product.Quantity + quantity,
                ActivityType = ProductTransactionType.ProduceProduct,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy
            });
        }

        public Task SellProductAsync(string salesOrderNumber, Product product, int quantity, double unitPrice, string doneBy)
        {
            _productTransactions.Add(new ProductTransaction 
            {
                ActivityType = ProductTransactionType.SellProduct,
                SONumber = salesOrderNumber,
                Product = product,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy,
                ProductId = product.ProductId,
                QuantityBefore = product.Quantity,
                QuantityAfter = product.Quantity - quantity,
                UnitPrice = unitPrice
            });
            return Task.CompletedTask;
        }
        #endregion
    }
}
