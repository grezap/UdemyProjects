using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class ProductRepository : IProductRepository
    {
        #region Fields
        private List<Product> _products;
        #endregion

        #region Constructor
        public ProductRepository()
        {
            _products = new List<Product>()
            {
                new Product { ProductId = 1, ProductName = "Bike", Quantity = 10, Price = 150 }, 
                new Product { ProductId = 2, ProductName = "Car", Quantity = 10, Price = 25000 }
            };
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return await Task.FromResult(_products);
            return _products.Where(x => x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public Task AddProductAsync(Product Product)
        {
            if (_products.Any(x => x.ProductName.Equals(Product.ProductName, StringComparison.OrdinalIgnoreCase)))
                { return Task.CompletedTask; }

            var maxId = _products.Max(x => x.ProductId);
            Product.ProductId = maxId + 1;

            _products.Add(Product);
            return Task.CompletedTask;
        }

        public Task UpdateProductAsync(Product Product)
        {
            if(_products.Any(x =>x.ProductId != Product.ProductId && x.ProductName.ToLower() == Product.ProductName.ToLower()))
                return Task.CompletedTask;

            var prod = _products.FirstOrDefault(x => x.ProductId == Product.ProductId);
            if (prod != null)
            {
                prod.ProductName = Product.ProductName;
                prod.Quantity = Product.Quantity;
                prod.Price = Product.Price;
                prod.ProductInventories = Product.ProductInventories;
            }
            return Task.CompletedTask;
        }

        public async Task<Product?> GetProductByIdAsync(int ProductId)
        {
            var prod = _products.FirstOrDefault(x => x.ProductId == ProductId);
            Product newProd = new();
            if (prod != null)
            {
                newProd.ProductId = prod.ProductId;
                newProd.ProductName = prod.ProductName;
                newProd.Quantity = prod.Quantity;
                newProd.Price = prod.Price;
                newProd.ProductInventories = new List<ProductInventory>();
                if (prod.ProductInventories != null && prod.ProductInventories.Count > 0)
                {
                    foreach (var prodInv in prod.ProductInventories)
                    {
                        ProductInventory newProdInv = new();
                        newProdInv.InventoryId = prodInv.InventoryId;
                        newProdInv.Product = prod;
                        newProdInv.ProductId = prodInv.ProductId;
                        newProdInv.Inventory = new Inventory();
                        newProdInv.InventoryQuantity = prodInv.InventoryQuantity;

                        if (prodInv.Inventory is not null)
                        {
                            newProdInv.Inventory.InventoryId = prodInv.Inventory.InventoryId;
                            newProdInv.Inventory.InventoryName = prodInv.Inventory.InventoryName;
                            newProdInv.Inventory.Quantity = prodInv.Inventory.Quantity;
                            newProdInv.Inventory.Price = prodInv.Inventory.Price;
                        }
                        newProd.ProductInventories.Add(newProdInv);
                    }
                }
            }
            return await Task.FromResult(newProd);
        }

        public async Task DeleteProductByIdAsync(int ProductId)
        {
            var Product = _products.FirstOrDefault(x => x.ProductId == ProductId);
            if(Product != null)
                _products.Remove(Product);
            await Task.CompletedTask;
        }
        #endregion
    }
}
