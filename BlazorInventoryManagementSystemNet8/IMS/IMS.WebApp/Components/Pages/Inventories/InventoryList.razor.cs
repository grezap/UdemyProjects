namespace IMS.WebApp.Components.Pages.Inventories
{
    public partial class InventoryList
    {
        #region Fields
        private string? _inventoryNameToSearch;
        #endregion

        #region Methods
        private void HandleSearch(string searchFilter)
        {
            _inventoryNameToSearch = searchFilter;
        }
        #endregion
    }
}