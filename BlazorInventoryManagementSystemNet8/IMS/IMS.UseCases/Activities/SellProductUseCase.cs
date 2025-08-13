using IMS.CoreBusiness;
using IMS.UseCases.Activities.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Activities
{
    public class SellProductUseCase : ISellProductUseCase
    {
        #region Fields
        private readonly IProductTransactionRepository _productTransactionRepository;
        private readonly IProductRepository _productRepository;
        #endregion

        #region Methods
        public SellProductUseCase(IProductTransactionRepository productTransactionRepository, IProductRepository productRepository)
        {
            this._productTransactionRepository = productTransactionRepository;
            this._productRepository = productRepository;
        }
        #endregion

        #region Methods
        public async Task ExecuteAsync(string salesOrderNumber, Product product, int quantity, double unitPrice, string doneBy)
        {
            await _productTransactionRepository.SellProductAsync(salesOrderNumber, product, quantity, unitPrice, doneBy);

            product.Quantity -= quantity;
            await _productRepository.UpdateProductAsync(product);
        }
        #endregion
    }
}
