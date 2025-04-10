using Ambev.DeveloperEvaluation.Application.Sales.GetPagedSale;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.GetPagedSale;

public class GetPagedSaleQueryHandlerTests
{
    private readonly ISaleRepository _saleRepository = Substitute.For<ISaleRepository>();
    private readonly IMapper _mapper = Substitute.For<IMapper>();

    private readonly GetPagedSaleQueryHandler _handler;

    public GetPagedSaleQueryHandlerTests()
    {
        _handler = new GetPagedSaleQueryHandler(_saleRepository, _mapper);
    }

    [Fact(DisplayName = "Given valid GetPagedSaleQuery should return paged result")]
    public async Task Handle_ValidQuery_ReturnsPagedResult()
    {
        // Arrange
        var query = new GetPagedSaleQuery(1, 10);

        var pagedSales = new Paged<Sale>
        {
            Page = query.Page,
            PerPage = query.PageSize,
            TotalItemCount = 2,
            Items = new List<Sale>
            {
                new Sale { Id = Guid.NewGuid() },
                new Sale { Id = Guid.NewGuid() }
            }
        };

        var expectedResult = new Paged<GetPagedSaleResult>
        {
            Page = pagedSales.Page,
            PerPage = pagedSales.PerPage,
            TotalItemCount = pagedSales.TotalItemCount,
            Items = pagedSales.Items.Select(s => new GetPagedSaleResult { Id = s.Id }).ToList()
        };

        _saleRepository.GetPagedAsync(query.Page, query.PageSize, Arg.Any<CancellationToken>())
            .Returns(pagedSales);

        _mapper.Map<Paged<GetPagedSaleResult>>(pagedSales).Returns(expectedResult);

        // Act
        var result = await _handler.Handle(query, default);

        // Assert
        result.Should().NotBeNull();
        result.Items.Should().HaveCount(2);
        result.TotalItemCount.Should().Be(2);

        await _saleRepository.Received(1).GetPagedAsync(query.Page, query.PageSize, Arg.Any<CancellationToken>());
        _mapper.Received(1).Map<Paged<GetPagedSaleResult>>(pagedSales);
    }

    [Fact(DisplayName = "Given invalid GetPagedSaleQuery should throw ValidationException")]
    public async Task Handle_InvalidQuery_ThrowsValidationException()
    {
        // Arrange
        var query = new GetPagedSaleQuery(0, -20);

        // Act
        Func<Task> act = async () => await _handler.Handle(query, default);

        // Assert
        await act.Should().ThrowAsync<ValidationException>();

        await _saleRepository.DidNotReceive().GetPagedAsync(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<CancellationToken>());
        _mapper.DidNotReceive().Map<Paged<GetPagedSaleResult>>(Arg.Any<Paged<Sale>>());
    }
}
