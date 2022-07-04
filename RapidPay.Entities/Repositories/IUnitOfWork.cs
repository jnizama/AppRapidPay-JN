using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Entities.Interfaces
{
    public interface IUnitOfWork
    {
        ICardRepository CardRepository { get; }
        IPaymentRepository PaymentRepository { get; }

        IUserRepository UserRepository { get; }
        Task<int> SaveChanges();
    }
}
