namespace Domain.Dtos
{
    public class ProductFilterDto
    {
        public decimal? MinPrice { get; set; }
        public string Name { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? MinRating { get; set; }
        public int? MaxRating { get; set; }
        public int[] Categories { get; set; }
        public int Page { get; set; }
    }
}