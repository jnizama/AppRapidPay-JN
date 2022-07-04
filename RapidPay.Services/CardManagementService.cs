using RapidPay.Entities.DTO;
using RapidPay.Entities.Interfaces;
using RapidPay.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Services
{
    public class CardManagementService : ICardManagementService
    {
        const int CARD_FORMAT = 15;
        readonly IUnitOfWork unitOfWork;
        readonly IUniversalFeeExchangeService ufeService;
        public CardManagementService(IUnitOfWork _unitOfWork, IUniversalFeeExchangeService _ufeService) =>
            (this.unitOfWork, ufeService) = (_unitOfWork, _ufeService);
        public async Task<CardDTO> CreateCard(CreateCardDTO card)
        {
            var existsCard = await unitOfWork.CardRepository.GetCardByNumber(card.CardNumber);

            if (card.CardNumber.ToString().Length != CARD_FORMAT)
            {
                throw new ArgumentException("Tarjeta no " + card.CardNumber.ToString() + " válida. " + CARD_FORMAT.ToString() + " digits expected");
            }

            if (card.Balance <= 0)
            {
                throw new ArgumentException("La cantidad debe ser mayor a cero");
            }

            if (existsCard != null)
            {
                throw new ArgumentException("La tarjeta" + card.CardNumber.ToString() + " ya existe");
            }

            Card newCard = new()
            {
                IdUser = card.IdUser,
                CardNumber = card.CardNumber,
                Balance = card.Balance
            };

            await unitOfWork.CardRepository.CreateCard(newCard);
            _ = await unitOfWork.SaveChanges();

            return new CardDTO()
            {
                Id = newCard.Id,
                CardNumber = newCard.CardNumber,
                Balance = newCard.Balance
            };
        }

        public async Task<CardDTO> GetCardBalance(int id)
        {
            var card = await unitOfWork.CardRepository.GetCardById(id);

            if (card == null)
            {
                throw new ArgumentException("La tarjeta " + id.ToString() + " no fue encontrada");
            }

            return new CardDTO()
            {
                Id = card.Id,
                CardNumber = card.CardNumber,
                Balance = card.Balance
            };
        }

        public async Task Pay(NewPaymentDTO payment)
        {
            var card = await unitOfWork.CardRepository.GetCardById(payment.IdCard);

            if (card == null)
            {
                throw new ArgumentException("La tarjeta " + payment.IdCard.ToString() + " no fue encontrada");
            }

            decimal fee = ufeService.GetFee();
            decimal amountWithFee = payment.Amount + fee;

            if (amountWithFee > card.Balance)
            {
                throw new ArgumentException("Insuficientes fondos");
            }

            Payment newPayment = new()
            {
                IdCard = card.Id,
                PreviusBalance = card.Balance,
                Amount = payment.Amount,
                Fee = fee,
                DateOfPayment = DateTimeOffset.Now,
                Balance = card.Balance - amountWithFee
            };

            card.Balance -= amountWithFee;

            await unitOfWork .CardRepository.UpdateCard(card);
            await unitOfWork.PaymentRepository.Add(newPayment);
            _ = await unitOfWork.SaveChanges();
        }
    }
}
