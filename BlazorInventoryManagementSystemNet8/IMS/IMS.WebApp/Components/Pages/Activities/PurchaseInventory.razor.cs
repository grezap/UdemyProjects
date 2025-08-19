using IMS.CoreBusiness;
using IMS.UseCases.Activities.Interfaces;
using IMS.UseCases.Inventories.Interfaces;
using IMS.WebApp.Components.Controls.Common;
using IMS.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace IMS.WebApp.Components.Pages.Activities
{
    public partial class PurchaseInventory
    {
        #region Fields
        private PurchaseViewModel _purchaseViewModel = new PurchaseViewModel();
        private Inventory? _selectedInventory = null;
        private AuthenticationState? _authState;
        #endregion

        #region Properties
        [Inject]
        IViewInventoriesByNameUseCase? ViewInventoriesByNameUseCase { get; set; }
        [Inject]
        IViewInventoryByIdUseCase? ViewInventoryByIdUseCase { get; set; }
        [Inject]
        IPurchaseInventoryUseCase? PurchaseInventoryUseCase { get; set; }
        [Inject]
        IJSRuntime? JSRuntime { get; set; }
        [Inject]
        AuthenticationStateProvider? AuthenticationStateProvider { get; set; }
        #endregion

        #region Methods
        protected override async Task OnInitializedAsync()
        {
            _authState = await AuthenticationStateProvider!.GetAuthenticationStateAsync();
        }

        private async Task<List<ItemViewModel>?> SearchInventory(string name)
        {
            var list = await ViewInventoriesByNameUseCase!.ExecuteAsync(name);
            if (list == null) return null;
            return list.Select(x => new ItemViewModel { Id = x.InventoryId, Name = x.InventoryName })?.ToList();
        }

        private async Task HandleItemSelected(ItemViewModel item)
        {
            _selectedInventory = await ViewInventoryByIdUseCase!.ExecuteAsync(item.Id);
            _purchaseViewModel.InventoryId = item.Id;
            _purchaseViewModel.InventoryPrice = _selectedInventory.Price;
        }

        private async Task Purchase()
        {
            string userName = string.Empty;
            if (_authState?.User?.Identity?.IsAuthenticated ?? false)
                userName = _authState?.User?.Identity?.Name ?? string.Empty;

            await PurchaseInventoryUseCase!.ExecuteAsync(_purchaseViewModel.PONumber, _selectedInventory, _purchaseViewModel.QuanityToPurchase, userName);
            _purchaseViewModel = new PurchaseViewModel();
            _selectedInventory = null;
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender) 
            {
                JSRuntime!.InvokeVoidAsync("preventFormSubmission", "purchase-form");
            }
        }
        #endregion
    }
}