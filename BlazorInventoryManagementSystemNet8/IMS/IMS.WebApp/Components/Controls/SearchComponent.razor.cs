using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Controls
{
    public partial class SearchComponent
    {
        #region Properties
        [SupplyParameterFromForm]
        public string? SearchFilter { get; set; } = String.Empty;

        [Parameter]
        public EventCallback<string> OnSearch { get; set; }
        #endregion

        #region Methods
        private void Search()
        {
            OnSearch.InvokeAsync(SearchFilter);
        }
        #endregion
    }
}