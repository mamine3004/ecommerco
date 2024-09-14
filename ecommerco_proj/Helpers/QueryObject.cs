namespace ecommerco_proj.Helpers
{

    public class QueryObject
    {

        public string? name { get; set; } = null;
        public decimal? price { get; set; } = null;
        public decimal? qty { get; set; } = null;
        public int? CategoryId { get; set; } = null;
        public string? sortBy { get; set; } = null;
        public bool isDecsending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;

    }
}
