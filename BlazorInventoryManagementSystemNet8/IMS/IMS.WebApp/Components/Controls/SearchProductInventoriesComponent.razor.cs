using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Controls
{
    public partial class SearchProductInventoriesComponent
    {
        #region Fields
        private string _searchFilter = string.Empty;
        private List<Inventory> _inventories = new List<Inventory>();
        #endregion

        #region Properties
        [Inject]
        public IViewInventoriesByNameUseCase? ViewInventoriesByNameUseCase { get; set; }
        private string SearchFilter { get => _searchFilter; set { _searchFilter = value; HandleSearch(); } }
        [Parameter]
        public EventCallback<Inventory> OnInventorySelected { get; set; }
        #endregion

        #region Methods
        private async Task HandleSearch()
        {
            await Task.Delay(1000);
            _inventories = (await ViewInventoriesByNameUseCase!.ExecuteAsync(_searchFilter)).ToList();
            StateHasChanged();
        }

        private async Task HandleSelectInventory(Inventory inventory)
        {
            await OnInventorySelected.InvokeAsync(inventory);
            _inventories.Clear();
        }
        #endregion
    }
}