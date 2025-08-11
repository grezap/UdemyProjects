using IMS.CoreBusiness;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Controls
{
    public partial class ProductInventoriesComponent
    {
        #region Properties
        [Parameter]
        public Product? Product { get; set; }
        #endregion

        #region Methods
        private void RemoveInventory(ProductInventory productInventory)
        {
            Product?.RemoveInventory(productInventory);
        }
        private void HandleInventorySelected(Inventory inventory)
        {
            Product?.AddInventory(inventory);
        }
        #endregion
    }
}