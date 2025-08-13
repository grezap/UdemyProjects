using IMS.WebApp.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.ViewModelsValidations
{
    public class Produce_EnsureEnoughInventoryQuantity : ValidationAttribute
    {
        #region Methods
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var produceViewModel = validationContext.ObjectInstance as ProduceViewModel;
            if (produceViewModel != null)
            {
                if(produceViewModel.Product != null && produceViewModel.Product.ProductInventories != null)
                {
                    foreach (var pi in produceViewModel.Product.ProductInventories)
                    {
                        if(pi.Inventory != null && pi.InventoryQuantity * produceViewModel.QuanityToProduce > pi.Inventory.Quantity)
                        {
                            return new ValidationResult($"The inventory ({pi.Inventory.InventoryName}) is not enough to produce {produceViewModel.QuanityToProduce} products.",
                                new[] { validationContext.MemberName});
                        }
                    }
                }
            }
            return ValidationResult.Success;
        } 
        #endregion
    }
}
