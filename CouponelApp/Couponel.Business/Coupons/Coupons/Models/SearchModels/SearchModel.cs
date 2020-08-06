using LinqBuilder.OrderBy;

namespace Couponel.Business.Coupons.Coupons.Models.SearchModels
{
    public sealed class SearchModel
    {
        public string SortColumn { get; set; } = "Title";

        public Sort SortType { get; set; } = Sort.Descending;

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}
