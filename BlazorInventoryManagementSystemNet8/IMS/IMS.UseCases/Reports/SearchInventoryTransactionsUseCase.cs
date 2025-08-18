using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Reports.Interfaces;

namespace IMS.UseCases.Reports
{
    public class SearchInventoryTransactionsUseCase : ISearchInventoryTransactionsUseCase
    {
        #region Fields
        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;
        #endregion
        #region Constructor
        public SearchInventoryTransactionsUseCase(IInventoryTransactionRepository inventoryTransactionRepository)
        {
            this._inventoryTransactionRepository = inventoryTransactionRepository;
        }
        #endregion

        #region Methods
        public async Task<List<InventoryTransaction>> ExecuteAsync(string inventoryName, DateTime? dateFrom, DateTime? dateTo, InventoryTransactionType? inventoryTransactionType)
        {
            if(dateTo.HasValue)
                dateTo.Value.AddDays(1);
            return (await _inventoryTransactionRepository.GetInventoryTransactionsAsync(inventoryName, dateFrom, dateTo, inventoryTransactionType)).ToList();
        }
        #endregion
    }
}
