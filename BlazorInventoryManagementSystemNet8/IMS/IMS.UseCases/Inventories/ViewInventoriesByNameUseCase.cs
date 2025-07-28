using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories
{
    public class ViewInventoriesByNameUseCase
    {
        #region Fields
        private readonly IInventoryRepository _inventoryRepository;
        #endregion

        #region Constructor
        public ViewInventoriesByNameUseCase(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Inventory>> ExecuteAsync(string name = "") 
        {
            return await _inventoryRepository.GetInventoriesByNameAsync(name);
        }
        #endregion
    }
}
