using Ambev.DeveloperEvaluation.Domain.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetPagedSale;

public class GetPagedSaleQuery : IRequest<Paged<GetPagedSaleResult>>
{
    public int Page { get; set; }
    public int PageSize { get; set; }

    public GetPagedSaleQuery(int page, int pageSize)
    {
        Page = page;
        PageSize = pageSize;
    }
}
