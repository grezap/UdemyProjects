using IMS.UseCases.Products.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Products
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        #region Fields
        private readonly IProductRepository _productRepository;
        #endregion

        #region Constructor
        public DeleteProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region Methods
        public async Task ExecuteAsync(int productId)
        {
            await _productRepository.DeleteProductByIdAsync(productId);
        }
        #endregion
    }
}
