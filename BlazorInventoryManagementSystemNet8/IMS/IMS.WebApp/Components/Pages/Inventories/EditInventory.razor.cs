using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
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
        private Inventory? Inventory { get; set; }

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
            Inventory ??= await ViewInventoryByIdUseCase!.ExecuteAsync(InvId);
        }

        private async Task Update()
        {
            if (Inventory != null)
            {
                await EditInventoryUseCase!.ExecuteAsync(Inventory);
                NavigationManager?.NavigateTo("/inventories");
            }
        }
        #endregion
    }
}