using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetPagedSale;

public class GetPagedSaleProfile : Profile
{
    public GetPagedSaleProfile()
    {
        CreateMap<Sale, GetPagedSaleResult>();
        CreateMap<Paged<Sale>, Paged<GetPagedSaleResult>>();
    }
}
