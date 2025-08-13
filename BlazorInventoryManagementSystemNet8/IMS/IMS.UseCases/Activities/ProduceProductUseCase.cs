using IMS.CoreBusiness;
using IMS.UseCases.Activities.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Activities
{
    public class ProduceProductUseCase : IProduceProductUseCase
    {
        #region Fields
        private readonly IProductTransactionRepository _productTransactionRepository;
        private readonly IProductRepository _productRepository;
        #endregion

        #region Constructor
        public ProduceProductUseCase(IProductTransactionRepository productTransactionRepository, IProductRepository productRepository)
        {
            _productTransactionRepository = productTransactionRepository;
            _productRepository = productRepository;
        }
        #endregion

        #region Methods
        public async Task ExecuteAsync(string productionNumber, Product product, int quantity, string doneBy)
        {
            await _productTransactionRepository.ProduceAsync(productionNumber, product, quantity, doneBy);

            product.Quantity += quantity;
            await _productRepository.UpdateProductAsync(product);
        }
        #endregion
    }
}
