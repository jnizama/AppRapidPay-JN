using Microsoft.EntityFrameworkCore;
using RapidPay.Entities.Interfaces;
using RapidPay.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Persistency.Repositories
{
    public class CardRepository : ICardRepository
    {
        readonly RapidPayContext context;

        public CardRepository(RapidPayContext context) =>
            this.context = context;
        
        public Task CreateCard(Card card)
        {
            context.Cards.Add(card);

            return Task.CompletedTask;
        }

        public Task UpdateCard(Card card)
        {
            context.Cards.Update(card);

            return Task.CompletedTask;
        }

        public Task<Card> GetCardByNumber(long cardNumber)
        {
            return context.Cards.FirstOrDefaultAsync(c => c.CardNumber == cardNumber);
        }

        public async Task<Card> GetCardById(int id)
        {
            return await context.Cards.FindAsync(id);
        }
    }
}
