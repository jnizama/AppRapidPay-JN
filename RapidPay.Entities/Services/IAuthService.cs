using RapidPay.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Entities.Interfaces
{
    public interface IAuthService
    {
        Task<UserDTO> Login(LoginDTO login);
    }
}
