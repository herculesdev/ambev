using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Specifications;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; } = null!;
    public Guid BranchId { get; set; }
    public string BranchName { get; set; } = null!;
    public int Number { get; set; }
    public DateTime Date { get; set; }
    public decimal Discount { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Total { get; set; }
    public List<SaleItem> Items { get; set; } = new();
    public bool IsCancelled { get; set; }

    public void AddItem(SaleItem item)
    {
        var maxProductPerSaleSpecification = new MaxProductQuantityPerSaleSpecification(item.ProductId, item.Quantity);
        if (!maxProductPerSaleSpecification.IsSatisfiedBy(this))
            throw new DomainException("Maximum of 20 units per product allowed");

        Discount += item.TotalDiscount;
        Subtotal += item.Subtotal;
        Total += item.Total;

        Items.Add(item);
    }

    public void AddItemRange(IEnumerable<SaleItem> items)
    {
        foreach (var item in items)
            AddItem(item);
    }

    public void RecalculateTotals()
    {
        ResetTotals();
        Items.ForEach(i =>
        {
            Discount += i.TotalDiscount;
            Subtotal += i.Subtotal;
            Total += i.Total;
        });
    }

    public void Update(Guid customerId, string customerName, Guid branchId, string branchName, int number, DateTime date)
    {
        CustomerId = customerId;
        CustomerName = customerName;
        BranchId = branchId;
        BranchName = branchName;
        Number = number;
        Date = date;
    }

    private void ResetTotals()
    {
        Discount = 0;
        Subtotal = 0;
        Total = 0;
    }
}
