namespace IMS.WebApp.Components.Pages.Products
{
    public partial class ProductList
    {
        #region Fields
        private string? _productNameToSearch;
        #endregion

        #region Methods
        private void HandleSearch(string searchFilter)
        {
            _productNameToSearch = searchFilter;
        }
        #endregion
    }
}