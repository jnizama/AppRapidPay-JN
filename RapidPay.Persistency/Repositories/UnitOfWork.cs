using RapidPay.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Persistency.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly RapidPayContext context;
        private ICardRepository cardRepository;
        private IPaymentRepository paymentRepository;
        private IUserRepository userRepository;

        public UnitOfWork(RapidPayContext context) =>
            this.context = context;

        public ICardRepository CardRepository
        {
            get
            {
                if (cardRepository == null)
                {
                    cardRepository = new CardRepository(context);
                }

                return cardRepository;
            }
        }

        public IPaymentRepository PaymentRepository
        {
            get
            {
                if (paymentRepository == null)
                {
                    paymentRepository = new PaymentRepository(context);
                }

                return paymentRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(context);
                }

                return userRepository;
            }
        }

        public Task<int> SaveChanges()
        {
            return context.SaveChangesAsync();
        }
    }
}
