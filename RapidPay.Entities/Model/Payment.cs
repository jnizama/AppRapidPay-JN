using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Entities.Model
{
    public class Payment
    {
        public int Id { get; set; }
        public int IdCard { get; set; }

        public DateTimeOffset DateOfPayment { get; set; }

        public decimal PreviusBalance { get; set; }

        public decimal Amount { get; set; }

        public decimal Fee { get; set; }

        public decimal Balance { get; set; }
    }
}
