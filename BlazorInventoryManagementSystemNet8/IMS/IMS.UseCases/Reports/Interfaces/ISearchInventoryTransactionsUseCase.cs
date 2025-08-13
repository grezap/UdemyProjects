using IMS.CoreBusiness;

namespace IMS.UseCases.Reports.Interfaces
{
    public interface ISearchInventoryTransactionsUseCase
    {
        Task<List<InventoryTransaction>> ExecuteAsync(string inventoryName, DateTime? dateFrom, DateTime? dateTo, InventoryTransactionType? inventoryTransactionType);
    }
}