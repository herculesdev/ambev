using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;

public class CancelSaleItemCommandValidator : AbstractValidator<CancelSaleItemCommand>
{
    public CancelSaleItemCommandValidator()
    {
        RuleFor(sale => sale.SaleId).NotEmpty();
        RuleFor(sale => sale.ItemId).NotEmpty();
    }
}
