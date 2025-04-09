using Ambev.DeveloperEvaluation.Application.Sales.GetPagedSale;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetPagedSale;

public class GetPagedSaleProfile : Profile
{

    public GetPagedSaleProfile()
    {
        CreateMap<GetPagedSaleRequest, GetPagedSaleQuery>();
        CreateMap<GetPagedSaleResult, GetPagedSaleResponse>();
        CreateMap<Paged<GetPagedSaleResult>, Paged<GetPagedSaleResponse>>();
    }
}
