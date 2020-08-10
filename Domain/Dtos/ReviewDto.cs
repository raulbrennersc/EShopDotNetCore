using Domain.Entities;

namespace Domain.Dtos
{
    public class ReviewDto
    {
        public string Description { get; set; }
        public int Rating { get; set; }

        public ReviewDto(Review review)
        {
            Description = review.Description;
            Rating = review.Rating;
        }
    }
}