using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetPagedSale;

public class GetPagedSaleQueryHandler : IRequestHandler<GetPagedSaleQuery, Paged<GetPagedSaleResult>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public GetPagedSaleQueryHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<Paged<GetPagedSaleResult>> Handle(GetPagedSaleQuery query, CancellationToken cancellationToken)
    {
        var validator = new GetPagedSaleQueryValidator();
        var validationResult = await validator.ValidateAsync(query, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = await _saleRepository.GetPagedAsync(query.Page, query.PageSize, cancellationToken);

        var result = _mapper.Map<Paged<GetPagedSaleResult>>(sale);
        return result;
    }
}
