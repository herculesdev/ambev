using Ambev.DeveloperEvaluation.Domain.Publishers;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using AutoMapper;
using FluentValidation;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleCommandHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly IEventPublisher _eventPublisher;

    public UpdateSaleCommandHandler(ISaleRepository saleRepository, IMapper mapper, IEventPublisher eventPublisher)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _eventPublisher = eventPublisher;
    }

    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var dbSale = await _saleRepository.GetByIdAsync(command.Id, cancellationToken);
        if(dbSale is null)
            throw new KeyNotFoundException($"Sale with ID {command.Id} not found");

        dbSale.Update(
            command.CustomerId, 
            command.CustomerName, 
            command.BranchId, 
            command.BranchName, 
            command.Number,
            command.Date);

        var updatedSale = await _saleRepository.UpdateAsync(dbSale, cancellationToken);
        await _eventPublisher.PublishAsync(new SaleModifiedEvent(updatedSale));
        var result = _mapper.Map<UpdateSaleResult>(updatedSale);
        return result;
    }
}
