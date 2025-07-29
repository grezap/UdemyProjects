using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Pages.Inventories
{
    public partial class EditInventory
    {
        #region Properties
        [Parameter]
        public int InvId { get; set; }
        #endregion
    }
}