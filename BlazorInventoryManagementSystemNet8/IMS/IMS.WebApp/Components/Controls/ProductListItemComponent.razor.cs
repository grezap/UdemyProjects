using IMS.CoreBusiness;
using IMS.UseCases.Products.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Controls
{
    public partial class ProductListItemComponent
    {
        #region Properties
        [Parameter]
        public Product? Product { get; set; }

        [Inject]
        IDeleteProductUseCase? DeleteProductUseCase { get; set; }

        [Inject]
        NavigationManager? NavigationManager { get; set; }
        #endregion

        #region Methods
        private async Task HandleDelete(int productId)
        {
            await DeleteProductUseCase!.ExecuteAsync(productId);
            Product = null;
        }
        #endregion
    }
}