using IMS.CoreBusiness;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Controls
{
    public partial class InventoryListItemComponent
    {
        #region Properties
        [Parameter]
        public Inventory? Inventory { get; set; } 
        #endregion
    }
}