using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        #region Fields
        private List<Inventory> _inventories;
        #endregion

        #region Constructor
        public InventoryRepository()
        {
            _inventories = new List<Inventory>()
            {
                new Inventory { InventoryId = 1, InventoryName = "Bike Seat", Quantity = 10, Price = 2 }, 
                new Inventory { InventoryId = 1, InventoryName = "Bike Body", Quantity = 10, Price = 15 }, 
                new Inventory { InventoryId = 1, InventoryName = "Bike Wheels", Quantity = 20, Price = 8 }, 
                new Inventory { InventoryId = 1, InventoryName = "Bike Pedals", Quantity = 20, Price = 1 } 
            };
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return await Task.FromResult(_inventories);
            return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        } 
        #endregion
    }
}
