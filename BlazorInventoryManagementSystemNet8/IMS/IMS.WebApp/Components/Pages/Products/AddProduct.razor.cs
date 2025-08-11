using IMS.CoreBusiness;
using IMS.UseCases.Products.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Pages.Products
{
    public partial class AddProduct
    {
        #region Properties
        private Product Product { get; set; } = new Product();

        [Inject]
        public IAddProductUseCase? AddProductUseCase { get; set; }

        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        #endregion

        #region Method
        private async Task Save()
        {
            await AddProductUseCase!.ExecuteAsync(Product);
            NavigationManager?.NavigateTo("/products");
        }
        #endregion
    }
}