using RapidPay.Entities.Interfaces;
using RapidPay.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Persistency.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        readonly RapidPayContext _context;
        public PaymentRepository(RapidPayContext context) =>
            _context = context;
        
        public Task Add(Payment payment)
        {
            _context.PaymentHistory.Add(payment);

            return Task.CompletedTask;
        }
    }
}
