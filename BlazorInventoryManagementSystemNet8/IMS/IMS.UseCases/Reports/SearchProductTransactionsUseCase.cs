using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Reports.Interfaces;

namespace IMS.UseCases.Reports
{
    public class SearchProductTransactionsUseCase : ISearchProductTransactionsUseCase
    {
        #region Fields
        private readonly IProductTransactionRepository _productTransactionRepository;
        #endregion

        #region Constructor
        public SearchProductTransactionsUseCase(IProductTransactionRepository productTransactionRepository)
        {
            this._productTransactionRepository = productTransactionRepository;
        }
        #endregion

        #region Methods
        public async Task<List<ProductTransaction>> ExecuteAsync(string ProductName, DateTime? dateFrom, DateTime? dateTo, ProductTransactionType? ProductTransactionType)
        {
            if(dateTo.HasValue)
                dateTo.Value.AddDays(1);
            return (await _productTransactionRepository.GetProductTransactionsAsync(ProductName, dateFrom, dateTo, ProductTransactionType)).ToList();
        }
        #endregion
    }
}
