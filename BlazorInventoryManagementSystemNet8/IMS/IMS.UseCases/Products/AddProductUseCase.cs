using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products.Interfaces;

namespace IMS.UseCases.Inventories
{
    public class AddProductUseCase : IAddProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public AddProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #region Methods
        public async Task ExecuteAsync(Product product)
        {
            await _productRepository.AddProductAsync(product);
        }
        #endregion
    }
}
