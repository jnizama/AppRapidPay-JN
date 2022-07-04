using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Entities.DTO
{
    public class NewPaymentDTO
    {
        public int IdCard { get; set; }

        public decimal Amount { get; set; }
    }
}
