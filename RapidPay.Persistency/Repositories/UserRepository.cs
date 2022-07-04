using RapidPay.Entities.Interfaces;
using RapidPay.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Persistency.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly RapidPayContext context;
        public UserRepository(RapidPayContext context) =>
            this.context = context;

        public User Create(User user)
        {
            context.Users.AddAsync(user);
            return user;
        }

        public User Login(string userName, string password)
        {
            return context.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);

        }

        public User UserByName(string userName)
        {
            return context.Users.FirstOrDefault(u => u.UserName == userName);
        }
    }
}
