using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Policies;
namespace Ambev.DeveloperEvaluation.Domain.Services;

public class SaleService : ISaleService
{
    public void CalculateAndApplyItemDiscounts(Sale sale)
    {
        var discountPolicy = new QuantityBasedDiscountPolicy();
        var itemsGrouped = sale.Items.GroupBy(item => item.ProductId);

        foreach (var group in itemsGrouped)
        {
            var totalQuantity = group.Sum(i => i.Quantity);
            var discount = discountPolicy.GetDiscountRate(totalQuantity);

            foreach (var item in group)
            {
                item.ApplyDiscount(discount);
            }
        }

        sale.RecalculateTotals();
    }
}
