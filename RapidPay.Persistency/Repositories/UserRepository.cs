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
        public User Authenticate(string userName, string password)
        {
            return context.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);

            //return new User()
            //{
            //    Id = 1,
            //    UserName = "stivens.morgan",
            //    Password = "123"
            //};
        }
    }
}
