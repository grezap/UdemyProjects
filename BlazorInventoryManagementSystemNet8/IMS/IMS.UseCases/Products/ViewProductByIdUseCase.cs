using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products.Interfaces;

namespace IMS.UseCases.Inventories
{
    public class ViewProductByIdUseCase : IViewProductByIdUseCase
    {
        #region Fields
        private readonly IProductRepository _productRepository;
        #endregion

        #region Constructor
        public ViewProductByIdUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region Methods
        public async Task<Product> ExecuteAsync(int productId)
        {
            return await _productRepository.GetProductByIdAsync(productId);
        }
        #endregion
    }
}
