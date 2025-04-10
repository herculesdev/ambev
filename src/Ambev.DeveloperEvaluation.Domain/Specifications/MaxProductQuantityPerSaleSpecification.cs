using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;

public class MaxProductQuantityPerSaleSpecification : ISpecification<Sale>
{
    private readonly Guid _productId;
    private readonly int _additionalQuantity;
    private const int MaxAllowed = 20;

    public MaxProductQuantityPerSaleSpecification(Guid productId, int additionalQuantity)
    {
        _productId = productId;
        _additionalQuantity = additionalQuantity;
    }

    public bool IsSatisfiedBy(Sale sale)
    {
        var existing = sale.Items
            .Where(i => i.ProductId == _productId)
            .Sum(i => i.Quantity);

        var total = existing + _additionalQuantity;
        return total <= MaxAllowed;
    }
}
