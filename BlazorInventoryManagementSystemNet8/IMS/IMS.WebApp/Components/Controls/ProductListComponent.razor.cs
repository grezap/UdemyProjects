using IMS.CoreBusiness;
using IMS.UseCases.Products.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Controls
{
    public partial class ProductListComponent
    {
        #region Fields
        private List<Product>? products;
        #endregion

        #region Properties
        [Inject]
        public IViewProductsByNameUseCase? ViewProductsByNameUseCase { get; set; }

        [Parameter]
        public string? SearchProductFilter { get; set; }
        #endregion

        #region Methods
        protected override async Task OnParametersSetAsync()
        {
            products = (await ViewProductsByNameUseCase!.ExecuteAsync(SearchProductFilter ?? String.Empty)).ToList();
        }
        #endregion
    }
}