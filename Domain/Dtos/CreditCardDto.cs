using Domain.Entities;

namespace Domain.Dtos
{
    public class CreditCardDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string OwnerName { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }

        public CreditCardDto(CreditCard card)
        {
            var length = card.Number.Length;
            Number = $"XXXX.XXXX.XXXX.{card.Number.Substring(length - 4)}";
            Id = card.Id;
            OwnerName = card.Number;
            ExpirationMonth = card.ExpirationMonth;
            ExpirationYear = card.ExpirationYear;
        }
    }
}