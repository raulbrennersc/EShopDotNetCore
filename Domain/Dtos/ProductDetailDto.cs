using Domain.Entities;

namespace Domain.Dtos
{
    public class ProductDetailDto
    {
        public string Label { get; set; }
        public string Value { get; set; }

        public ProductDetailDto(ProductDetail productDetail)
        {
            Label = productDetail.Label;
            Value = productDetail.Value;
        }
    }
}