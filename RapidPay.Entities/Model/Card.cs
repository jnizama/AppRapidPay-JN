using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Entities.Model
{
    public class Card
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public long CardNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
