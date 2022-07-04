using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Entities.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Token { get; set; }
    }
}
