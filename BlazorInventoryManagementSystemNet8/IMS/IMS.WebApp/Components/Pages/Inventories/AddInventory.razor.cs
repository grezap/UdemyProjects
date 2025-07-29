using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Pages.Inventories
{
    public partial class AddInventory
    {
        #region Properties
        [SupplyParameterFromForm]
        private Inventory Inventory { get; set; } = new Inventory();

        [Inject]
        public IAddInventoryUseCase? AddInventoryUseCase { get; set; }

        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        #endregion

        #region Method
        private async Task Save()
        {
            await AddInventoryUseCase!.ExecuteAsync(Inventory);
            NavigationManager?.NavigateTo("/inventories");
        }
        #endregion
    }
}