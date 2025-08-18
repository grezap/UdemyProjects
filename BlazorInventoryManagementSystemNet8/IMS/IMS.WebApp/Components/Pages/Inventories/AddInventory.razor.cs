using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using IMS.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Pages.Inventories
{
    public partial class AddInventory
    {
        #region Properties
        [SupplyParameterFromForm]
        private InventoryViewModel Inventory { get; set; } = new InventoryViewModel();

        [Inject]
        public IAddInventoryUseCase? AddInventoryUseCase { get; set; }

        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        #endregion

        #region Method
        private async Task Save()
        {
            var inv = new Inventory()
            {
                InventoryId = Inventory.InventoryId,
                InventoryName = Inventory.InventoryName,
                Quantity = Inventory.Quantity,
                Price = Inventory.Price
            };
            await AddInventoryUseCase!.ExecuteAsync(inv);
            NavigationManager?.NavigateTo("/inventories");
        }
        #endregion
    }
}