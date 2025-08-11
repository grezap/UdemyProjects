using IMS.CoreBusiness.Validations;
using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(150)]
        public string ProductName { get; set; } = string.Empty;

        [Range(0,int.MaxValue, ErrorMessage = "Quantity must be grater or equal to 0.")]
        public int Quantity { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price must be grater or equal to 0.")]
        public double Price { get; set; }
        [ProductEnsurePriceIsGreaterThanInventoriesCost]
        public List<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();

        #region Methods
        public void AddInventory(Inventory inventory)
        {

            if (!this.ProductInventories.Any(x => x.Inventory is not null && x.Inventory.InventoryName.Equals(inventory.InventoryName)))
            {
                ProductInventories.Add(new ProductInventory
                {
                    InventoryId = inventory.InventoryId,
                    Inventory = inventory,
                    InventoryQuantity = 1,
                    ProductId = ProductId,
                    Product = this
                });
            }
        }

        public void RemoveInventory(ProductInventory productInventory)
        {
            ProductInventories?.Remove(productInventory);
        }
        #endregion
    }
}
