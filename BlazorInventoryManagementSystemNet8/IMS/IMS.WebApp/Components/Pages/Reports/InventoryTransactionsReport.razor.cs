using IMS.CoreBusiness;
using IMS.UseCases.Reports.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace IMS.WebApp.Components.Pages.Reports
{
    public partial class InventoryTransactionsReport
    {
        #region Fields
        private string _invName;
        private DateTime? _dateFrom;
        private DateTime? _dateTo;
        private int _activityTypeId;
        private IEnumerable<InventoryTransaction>? _inventoryTransactions;
        #endregion

        #region Properties
        [Inject]
        ISearchInventoryTransactionsUseCase? SearchInventoryTransactionsUse {  get; set; }
        [Inject]
        IJSRuntime? JSRuntime { get; set; }
        #endregion

        #region Methods
        private async Task SearchInventories()
        {
            InventoryTransactionType? invType = null;
            if(_activityTypeId != 0)
                invType = (InventoryTransactionType)_activityTypeId;

            _inventoryTransactions = await SearchInventoryTransactionsUse!.ExecuteAsync(_invName,_dateFrom,_dateTo,invType);
        }

        private async Task Print()
        {
            await JSRuntime!.InvokeVoidAsync("print");
        }
        #endregion
    }
}