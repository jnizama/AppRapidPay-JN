using RapidPay.Entities.DTO;
using RapidPay.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Entities.Interfaces
{
    public interface ICardManagementService
    {
        Task<CardDTO> CreateCard(CreateCardDTO card);

        Task<CardDTO> GetCardBalance(int cardId);

        Task Pay(NewPaymentDTO payment);
    }
}
