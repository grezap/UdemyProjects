using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IMS.Plugins.EFCoreSqlServer
{
    public class ProductTransactionEFCoreRepository : IProductTransactionRepository
    {
        private readonly IDbContextFactory<IMSContext> _contextFactory;
        private readonly IProductRepository _productRepository;
        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;
        private readonly IInventoryRepository _inventoryRepository;

        public ProductTransactionEFCoreRepository(IDbContextFactory<IMSContext> contextFactory, IProductRepository productRepository, IInventoryTransactionRepository inventoryTransactionRepository, IInventoryRepository inventoryRepository)
        {
            _contextFactory = contextFactory;
            _productRepository = productRepository;
            _inventoryTransactionRepository = inventoryTransactionRepository;
            _inventoryRepository = inventoryRepository;
        }

        public async Task<IEnumerable<ProductTransaction>> GetProductTransactionsAsync(string productName, DateTime? dateFrom, DateTime? dateTo, ProductTransactionType? productTransactionType)
        {
            using var db = await _contextFactory.CreateDbContextAsync();

            var query = from it in db.ProductTransactions
                        join inv in db.Products on it.ProductId equals inv.ProductId
                        where (string.IsNullOrWhiteSpace(productName) || inv.ProductName.ToLower().IndexOf(productName.ToLower()) >= 0)
                              && (!dateFrom.HasValue || it.TransactionDate >= dateFrom.Value.Date)
                              && (!dateTo.HasValue || it.TransactionDate <= dateTo.Value.Date)
                              && (!productTransactionType.HasValue || it.ActivityType == productTransactionType)
                        select it
                        ;

            return await query.Include(x =>x.Product).ToListAsync();
        }

        public async Task ProduceAsync(string productionNumber, Product product, int quantity, string doneBy)
        {
            using var db = await _contextFactory.CreateDbContextAsync();

            var prod = await _productRepository.GetProductByIdAsync(product.ProductId);
            if (prod != null && prod.ProductInventories is not null && prod.ProductInventories.Count > 0)
            {
                foreach (var pi in prod.ProductInventories)
                {
                    if (pi.Inventory != null)
                    {
                        await _inventoryTransactionRepository.ProduceAsync(productionNumber, pi.Inventory, pi.InventoryQuantity * quantity, doneBy, -1);
                        var inv = await _inventoryRepository.GetInventoryByIdAsync(pi.InventoryId);
                        inv.Quantity -= pi.InventoryQuantity * quantity;
                        await _inventoryRepository.UpdateInventoryAsync(inv);
                    }
                }
            }
            await db.ProductTransactions.AddAsync(new ProductTransaction
            {
                ProductionNumber = productionNumber,
                ProductId = product.ProductId,
                QuantityBefore = product.Quantity,
                QuantityAfter = product.Quantity + quantity,
                ActivityType = ProductTransactionType.ProduceProduct,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy
            });

            await db.SaveChangesAsync();
        }

        public async Task SellProductAsync(string salesOrderNumber, Product product, int quantity, double unitPrice, string doneBy)
        {
            using var db = await _contextFactory.CreateDbContextAsync();

            ProductTransaction toAdd = new ProductTransaction
            {
                ActivityType = ProductTransactionType.SellProduct,
                SONumber = salesOrderNumber,
                //Product = product,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy,
                ProductId = product.ProductId,
                QuantityBefore = product.Quantity,
                QuantityAfter = product.Quantity - quantity,
                UnitPrice = unitPrice
            };

            await db.ProductTransactions.AddAsync(toAdd);
            await db.SaveChangesAsync();
        }
    }
}
