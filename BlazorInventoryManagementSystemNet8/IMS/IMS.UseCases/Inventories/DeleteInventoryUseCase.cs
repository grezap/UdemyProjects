using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories
{
    public class DeleteInventoryUseCase : IDeleteInventoryUseCase
    {
        #region Fields
        private readonly IInventoryRepository _inventoryRepository;
        #endregion

        #region Constructor
        public DeleteInventoryUseCase(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        #endregion

        #region Methods
        public async Task ExecuteAsync(int inventoryId)
        {
            await _inventoryRepository.DeleteInventoryByIdAsync(inventoryId);
        }
        #endregion
    }
}
