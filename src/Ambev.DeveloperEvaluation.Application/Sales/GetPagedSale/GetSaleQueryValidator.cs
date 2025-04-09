using Ambev.DeveloperEvaluation.Application.Sales.GetPagedSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetPagedSale;

public class GetPagedSaleQueryValidator : AbstractValidator<GetPagedSaleQuery>
{
    public GetPagedSaleQueryValidator()
    {
        RuleFor(sale => sale.Page).GreaterThanOrEqualTo(1);
        RuleFor(sale => sale.PageSize).GreaterThanOrEqualTo(1);
    }
}
