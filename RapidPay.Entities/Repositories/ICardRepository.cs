using RapidPay.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Entities.Interfaces
{
    public interface ICardRepository
    {
        Task CreateCard(Card card);

        Task UpdateCard(Card card);

        Task<Card> GetCardById(int id);

        Task<Card> GetCardByNumber(long cardNumber);
    }
}
