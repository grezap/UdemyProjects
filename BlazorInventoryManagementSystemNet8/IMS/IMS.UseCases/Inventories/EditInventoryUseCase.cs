using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories
{
    public class EditInventoryUseCase : IEditInventoryUseCase
    {
        #region Fields
        private readonly IInventoryRepository _inventoryRepository;
        #endregion

        #region Constructor
        public EditInventoryUseCase(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        #endregion

        #region Methods
        public async Task ExecuteAsync(Inventory inventory)
        {
            await _inventoryRepository.UpdateInventoryAsync(inventory);
        }
        #endregion
    }
}
