using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products.Interfaces;

namespace IMS.UseCases.Inventories
{
    public class ViewProductsByNameUseCase : IViewProductsByNameUseCase
    {
        #region Fields
        private readonly IProductRepository _productRepository;
        #endregion

        #region Constructor
        public ViewProductsByNameUseCase(IProductRepository ProductRepository)
        {
            _productRepository = ProductRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Product>> ExecuteAsync(string name = "")
        {
            return await _productRepository.GetProductsByNameAsync(name);
        }
        #endregion
    }
}
