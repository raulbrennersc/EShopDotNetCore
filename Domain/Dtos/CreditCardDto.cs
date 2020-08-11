using Domain.Entities;

namespace Domain.Dtos
{
    public class CreditCardDto
    {
        public string Number { get; set; }
        public string OwnerName { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }

        public CreditCardDto(CreditCard card)
        {
            var length = card.Number.Length;
            Number = $"XXXX.XXXX.XXXX.{card.Number.Substring(length - 4)}";
            OwnerName = card.Number;
            ExpirationMonth = card.ExpirationMonth;
            ExpirationYear = card.ExpirationYear;
        }
    }
}