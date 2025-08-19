using IMS.CoreBusiness;
using IMS.UseCases.Activities.Interfaces;
using IMS.UseCases.Products.Interfaces;
using IMS.WebApp.Components.Controls.Common;
using IMS.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace IMS.WebApp.Components.Pages.Activities
{
    public partial class SellProduct
    {
        #region Fields
        private SellViewModel _sellViewModel = new SellViewModel();
        private Product? _selectedProduct;
        private AuthenticationState? _authState;
        #endregion

        #region Properties
        [Inject]
        IViewProductsByNameUseCase? ViewProductsByNameUseCase { get; set; }
        [Inject]
        IViewProductByIdUseCase? ViewProductByIdUseCase { get; set; }
        [Inject]
        ISellProductUseCase? SellProductUseCase { get; set; }
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

        private async Task<List<ItemViewModel>?> SearchProduct(string name)
        {
            var list = await ViewProductsByNameUseCase!.ExecuteAsync(name);
            if (list == null) return null;
            return list.Select(x => new ItemViewModel { Id = x.ProductId, Name = x.ProductName })?.ToList();
        }

        private async Task HandleItemSelected(ItemViewModel item)
        {
            _selectedProduct = await ViewProductByIdUseCase!.ExecuteAsync(item.Id);
            _sellViewModel.ProductId = item.Id;
            _sellViewModel.Product = _selectedProduct;
            _sellViewModel.UnitPrice = _selectedProduct.Price;
        }

        private async Task Sell()
        {
            string userName = string.Empty;
            if (_authState?.User?.Identity?.IsAuthenticated ?? false)
                userName = _authState?.User?.Identity?.Name ?? string.Empty;

            await SellProductUseCase!.ExecuteAsync(_sellViewModel.SalesOrderNumber, _selectedProduct, _sellViewModel.QuantityToSell, _sellViewModel.UnitPrice, userName);
            _sellViewModel = new SellViewModel();
            _selectedProduct = null;
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                JSRuntime!.InvokeVoidAsync("preventFormSubmission", "sell-form");
            }
        }
        #endregion
    }
}