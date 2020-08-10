namespace Domain.Dtos
{
    public class ProductToListDto
    {
        public virtual decimal Price { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual double Rating { get; set; }
    }
}