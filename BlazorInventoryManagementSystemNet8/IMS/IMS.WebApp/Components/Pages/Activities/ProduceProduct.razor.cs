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
    public partial class ProduceProduct
    {
        #region Fields
        private ProduceViewModel _produceViewModel = new ProduceViewModel();
        private Product? _selectedProduct;
        private AuthenticationState? _authState;
        #endregion

        #region Properties
        [Inject]
        IViewProductsByNameUseCase? ViewProductsByNameUseCase { get; set; }
        [Inject]
        IViewProductByIdUseCase? ViewProductByIdUseCase { get; set; }
        [Inject]
        IProduceProductUseCase? ProduceProductUseCase { get; set; }
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
            _produceViewModel.ProductId = item.Id;
            _produceViewModel.Product = _selectedProduct;
        }

        private async Task Produce()
        {
            string userName = string.Empty;
            if (_authState?.User?.Identity?.IsAuthenticated ?? false)
                userName = _authState?.User?.Identity?.Name ?? string.Empty;

            await ProduceProductUseCase!.ExecuteAsync(_produceViewModel.ProductionNumber, _selectedProduct, _produceViewModel.QuanityToProduce, userName);
            _produceViewModel = new ProduceViewModel();
            _selectedProduct = null;
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                JSRuntime!.InvokeVoidAsync("preventFormSubmission", "produce-form");
            }
        }
        #endregion
    }
}