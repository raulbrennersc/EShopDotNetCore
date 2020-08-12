using System.Collections.Generic;
using System.Linq;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Services.Exceptions;

namespace Services.Services
{
    public class CreditCardService : ICreditCardService
    {
        private readonly IRepository<CreditCard> _creditCardRepository;

        public CreditCardService(IRepository<CreditCard> creditCardRepository)
        {
            _creditCardRepository = creditCardRepository;
        }

        public void Delete(int creditCardId, string customerCpf)
        {
            var creditCard = _creditCardRepository.Get(creditCardId);
            if (creditCard.Customer.Cpf == customerCpf)
            {
                _creditCardRepository.Delete(creditCardId);
            }
            else
            {
                throw new NotTheOwnerException(ServicesConstants.ERR_NOT_THE_OWNER);
            }
        }

        public CreditCard GetCardById(int cardId, string customerCpf)
        {
            var card = _creditCardRepository.Get(cardId);
            if (card.Customer.Cpf == customerCpf)
            {
                return card;
            }

            throw new NotTheOwnerException(ServicesConstants.ERR_NOT_THE_OWNER);
        }

        public IEnumerable<CreditCardDto> GetCardsByCustomerCpf(string customerCpf)
        {
            return _creditCardRepository.GetAll()
            .Where(c => c.Customer.Cpf == customerCpf).Select(c => new CreditCardDto(c));
        }

        public void Save(CreditCardDto creditCardDto, Customer customer)
        {
            var number = creditCardDto.Number.Replace(".", "");
            var newCard = new CreditCard
            {
                Customer = customer,
                ExpirationMonth = creditCardDto.ExpirationMonth,
                ExpirationYear = creditCardDto.ExpirationYear,
                Number = number,
                OwnerName = creditCardDto.OwnerName
            };
            _creditCardRepository.Save(newCard);
        }

        public void Update(CreditCardDto creditCardDto, string customerCpf)
        {
            var card = _creditCardRepository.Get(creditCardDto.Id);
            if (card.Customer.Cpf == customerCpf)
            {
                card.ExpirationMonth = creditCardDto.ExpirationMonth;
                card.ExpirationYear = creditCardDto.ExpirationYear;
                card.Number = creditCardDto.Number;
                card.OwnerName = creditCardDto.OwnerName;
                _creditCardRepository.Update(card);
            }
            else
            {
                throw new NotTheOwnerException(ServicesConstants.ERR_NOT_THE_OWNER);
            }
        }
    }
}