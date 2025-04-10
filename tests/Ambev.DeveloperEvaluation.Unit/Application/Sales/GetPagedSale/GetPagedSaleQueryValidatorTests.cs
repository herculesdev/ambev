using Ambev.DeveloperEvaluation.Application.Sales.GetPagedSale;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.GetPagedSale;

public class GetPagedSaleQueryValidatorTests
{
    private readonly GetPagedSaleQueryValidator _validator = new();

    [Theory(DisplayName = "Valid Page and PageSize should pass validation")]
    [InlineData(1, 10)]
    [InlineData(5, 20)]
    public void Validate_ValidPageAndPageSize_ShouldBeValid(int page, int pageSize)
    {
        // Arrange
        var query = new GetPagedSaleQuery(page, pageSize);

        // Act
        var result = _validator.Validate(query);

        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Theory(DisplayName = "Invalid Page or PageSize should fail validation")]
    [InlineData(0, 10)]
    [InlineData(1, 0)]
    [InlineData(0, 0)]
    public void Validate_InvalidPageOrPageSize_ShouldBeInvalid(int page, int pageSize)
    {
        // Arrange
        var query = new GetPagedSaleQuery(page, pageSize);

        // Act
        var result = _validator.Validate(query);

        // Assert
        result.IsValid.Should().BeFalse();
        if (page < 1)
            result.Errors.Should().Contain(e => e.PropertyName == nameof(GetPagedSaleQuery.Page));
        if (pageSize < 1)
            result.Errors.Should().Contain(e => e.PropertyName == nameof(GetPagedSaleQuery.PageSize));
    }
}
