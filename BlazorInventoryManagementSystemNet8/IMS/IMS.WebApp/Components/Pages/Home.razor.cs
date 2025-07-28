using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Pages
{
    public partial class Home
    {
        #region Fields
        private List<Inventory>? inventories;
        #endregion

        #region Properties
        [Inject]
        public IViewInventoriesByNameUseCase? ViewInventoriesByNameUseCase { get; set; }
        #endregion

        #region Methods
        protected override async Task OnInitializedAsync()
        {
            inventories = (await ViewInventoriesByNameUseCase!.ExecuteAsync()).ToList();
        } 
        #endregion
    }
}