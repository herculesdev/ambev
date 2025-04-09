namespace Ambev.DeveloperEvaluation.Domain.Common;

public class Paged<T>
{
    public int Page { get; set; }
    public int PerPage { get; set; }
    public int TotalItemCount { get; set; }
    public int PageItemCount => Items.Count();
    public int PageCount => (int)Math.Ceiling((double)TotalItemCount / PerPage);
    public IEnumerable<T> Items { get; set; }

    public Paged(IEnumerable<T> items, int page, int perPage, int totalItemCount)
    {
        Page = page;
        PerPage = perPage;
        TotalItemCount = totalItemCount;
        Items = items;
    }
}
