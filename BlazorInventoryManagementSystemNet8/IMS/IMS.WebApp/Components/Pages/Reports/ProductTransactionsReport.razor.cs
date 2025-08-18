using IMS.CoreBusiness;
using IMS.UseCases.Reports.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace IMS.WebApp.Components.Pages.Reports
{
    public partial class ProductTransactionsReport
    {
        #region Fields
        private string _prodName;
        private DateTime? _dateFrom;
        private DateTime? _dateTo;
        private int _activityTypeId;
        private IEnumerable<ProductTransaction>? _productTransactions;
        #endregion

        #region Properties
        [Inject]
        ISearchProductTransactionsUseCase? SearchProductTransactionsUse {  get; set; }
        [Inject]
        IJSRuntime? JSRuntime { get; set; }
        #endregion

        #region Methods
        private async Task SearchProducts()
        {
            ProductTransactionType? invType = null;
            if(_activityTypeId != 0)
                invType = (ProductTransactionType)_activityTypeId;

            _productTransactions = await SearchProductTransactionsUse!.ExecuteAsync(_prodName,_dateFrom,_dateTo,invType);
        }

        private async Task Print()
        {
            await JSRuntime!.InvokeVoidAsync("print");
        }
        #endregion
    }
}