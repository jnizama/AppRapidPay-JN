using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Entities.DTO
{
    public class CreateCardDTO
    {
        public int IdUser { get; set; }
        public long CardNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
