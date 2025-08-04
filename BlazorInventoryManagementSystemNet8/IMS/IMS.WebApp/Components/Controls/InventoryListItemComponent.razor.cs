using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Controls
{
    public partial class InventoryListItemComponent
    {
        #region Properties
        [Parameter]
        public Inventory? Inventory { get; set; }

        [Inject]
        IDeleteInventoryUseCase? DeleteInventoryUseCase { get; set; }

        [Inject]
        NavigationManager? NavigationManager { get; set; }
        #endregion

        #region Methods
        private async Task DeleteInventory(int inventoryId)
        {
            await DeleteInventoryUseCase!.ExecuteAsync(inventoryId);
            NavigationManager?.Refresh();
        }
        #endregion
    }
}