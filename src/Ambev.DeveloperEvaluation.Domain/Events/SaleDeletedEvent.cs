namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleDeletedEvent
{
    public Guid SaleId { get; }

    public SaleDeletedEvent(Guid saleId)
    {
        SaleId = saleId;
    }
}
