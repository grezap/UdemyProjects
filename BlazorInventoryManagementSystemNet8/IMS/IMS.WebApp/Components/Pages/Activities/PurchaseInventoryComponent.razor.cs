using IMS.CoreBusiness;
using IMS.UseCases.Activities.Interfaces;
using IMS.UseCases.Inventories.Interfaces;
using IMS.WebApp.Components.Controls.Common;
using IMS.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Pages.Activities
{
    public partial class PurchaseInventoryComponent
    {
        #region Fields
        private PurchaseViewModel _purchaseViewModel = new PurchaseViewModel();
        private Inventory? _selectedInventory = null;
        #endregion

        #region Properties
        [Inject]
        IViewInventoriesByNameUseCase? ViewInventoriesByNameUseCase { get; set; }
        [Inject]
        IViewInventoryByIdUseCase? ViewInventoryByIdUseCase { get; set; }
        [Inject]
        IPurchaseInventoryUseCase? PurchaseInventoryUseCase { get; set; }
        #endregion

        #region Methods
        private List<ItemViewModel>? SearchInventory(string name)
        {
            var list = ViewInventoriesByNameUseCase!.ExecuteAsync(name).GetAwaiter().GetResult();
            if (list == null) return null;
            return list.Select(x => new ItemViewModel { Id = x.InventoryId, Name = x.InventoryName })?.ToList();
        }

        private async Task HandleItemSelected(ItemViewModel item)
        {
            _selectedInventory = await ViewInventoryByIdUseCase!.ExecuteAsync(item.Id);
            _purchaseViewModel.InventoryId = item.Id;
            _purchaseViewModel.InventoryPrice = _selectedInventory.Price;
        }

        private async Task Purchase()
        {
            await PurchaseInventoryUseCase!.ExecuteAsync(_purchaseViewModel.PONumber, _selectedInventory, _purchaseViewModel.QuanityToPurchase, "Someone");
            _purchaseViewModel = new PurchaseViewModel();
            _selectedInventory = null;
        }
        #endregion
    }
}