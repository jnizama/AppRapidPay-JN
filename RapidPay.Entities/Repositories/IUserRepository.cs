using RapidPay.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Entities.Interfaces
{
    public interface IUserRepository
    {
        User Login(string username, string password);
        User UserByName(string userName);
        User Create(User user);
    }
}
