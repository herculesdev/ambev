using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetPagedSale;

public class GetPagedSaleRequestValidator : AbstractValidator<GetPagedSaleRequest>
{
    public GetPagedSaleRequestValidator()
    {
        RuleFor(sale => sale.Page).GreaterThanOrEqualTo(1);
        RuleFor(sale => sale.PageSize).GreaterThanOrEqualTo(1);
    }
}
