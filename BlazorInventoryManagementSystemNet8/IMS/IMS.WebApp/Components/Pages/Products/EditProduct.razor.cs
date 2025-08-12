using IMS.CoreBusiness;
using IMS.UseCases.Products.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Pages.Products
{
    public partial class EditProduct
    {
        #region Fields
        private Product? _product;
        #endregion

        #region Properties
        [Parameter]
        public int Id { get; set; }
        [Inject]
        IViewProductByIdUseCase? ViewProductByIdUseCase { get; set; }
        [Inject]
        IEditProductUseCase? EditProductUseCase { get; set; }
        [Inject]
        NavigationManager? NavigationManager { get; set; }
        #endregion

        #region Methods
        protected override async Task OnParametersSetAsync()
        {
            _product = await ViewProductByIdUseCase!.ExecuteAsync(Id);
        }

        private async Task Update()
        {
            if (_product != null)
            {
                await EditProductUseCase!.ExecuteAsync(_product);
                NavigationManager!.NavigateTo("/products");
            }
        }
        #endregion
    }
}