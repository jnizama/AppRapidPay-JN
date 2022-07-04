using RapidPay.Entities.DTO;
using RapidPay.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Services
{
    public class AuthService : IAuthService
    {
        readonly IEncryptService encryptService;
        readonly IUnitOfWork unitOfWork;
        readonly ITokenService tokenService;
        public AuthService
            (IEncryptService encryptService, IUnitOfWork unitOfWork, ITokenService tokenService) =>
            (this.encryptService, this.unitOfWork, this.tokenService) = (encryptService, unitOfWork, tokenService);

        public Task<UserDTO> Login(LoginDTO login)
        {
            string encryptedPassword = encryptService.GetHash(login.Password);
            var user = unitOfWork.UserRepository.Login(login.UserName, encryptedPassword);

            if (user == null)
            {
                throw new ArgumentException("User or Password wrong");
            }

            UserDTO userDTO = new()
            {
                Id = user.Id,
                UserName = user.UserName,
                Token = tokenService.GenerateSecurityToken(user.UserName)
            };

            return Task.FromResult(userDTO);
        }
    }
}
