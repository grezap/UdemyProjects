using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products.Interfaces;

namespace IMS.UseCases.Inventories
{
    public class EditProductUseCase : IEditProductUseCase
    {
        #region Fields
        private readonly IProductRepository _ProductRepository;
        #endregion

        #region Constructor
        public EditProductUseCase(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }
        #endregion

        #region Methods
        public async Task ExecuteAsync(Product Product)
        {
            await _ProductRepository.UpdateProductAsync(Product);
        }
        #endregion
    }
}
