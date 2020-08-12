using System.Collections.Generic;
using Domain.Dtos;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICreditCardService
    {
        void Save(CreditCardDto creditCardDto);
        void Delete(int creditCardId, string customerCpf);
        void Update(CreditCardDto creditCardDto, string customerCpf);
        IEnumerable<CreditCardDto> GetCardsByCustomerCpf(string customerCpf);
        CreditCard GetCardById(int cardId);
    }
}