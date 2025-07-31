using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Controls
{
    public partial class InventoryListComponent
    {
        #region Fields
        private List<Inventory>? inventories;
        #endregion

        #region Properties
        [Inject]
        public IViewInventoriesByNameUseCase? ViewInventoriesByNameUseCase { get; set; }

        [Parameter]
        public string? SearchInventoryFilter { get; set; }
        #endregion

        #region Methods
        protected override async Task OnInitializedAsync()
        {
            inventories = (await ViewInventoriesByNameUseCase!.ExecuteAsync(SearchInventoryFilter??String.Empty)).ToList();
        }
        #endregion
    }
}