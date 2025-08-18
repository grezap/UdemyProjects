using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using IMS.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Pages.Inventories
{
    public partial class EditInventory
    {
        #region Fields

        #endregion

        #region Properties
        [Parameter]
        public int InvId { get; set; }

        [SupplyParameterFromForm]
        private InventoryViewModel? Inventory { get; set; }

        [Inject]
        public IViewInventoryByIdUseCase? ViewInventoryByIdUseCase { get; set; }

        [Inject]
        public IEditInventoryUseCase? EditInventoryUseCase { get; set; }

        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        #endregion

        #region Methods
        protected override async Task OnParametersSetAsync()
        {
            if(Inventory is null)
            {
                var inv = await ViewInventoryByIdUseCase!.ExecuteAsync(InvId);
                Inventory = new InventoryViewModel()
                {
                    InventoryId = inv.InventoryId,
                    InventoryName = inv.InventoryName,
                    Price = inv.Price,
                    Quantity = inv.Quantity
                };
            }
        }

        private async Task Update()
        {
            if (Inventory != null)
            {
                var inv = new Inventory() 
                { 
                    InventoryId = Inventory.InventoryId,
                    InventoryName = Inventory.InventoryName,
                    Quantity = Inventory.Quantity,
                    Price = Inventory.Price
                };
                await EditInventoryUseCase!.ExecuteAsync(inv);
                NavigationManager?.NavigateTo("/inventories");
            }
        }
        #endregion
    }
}