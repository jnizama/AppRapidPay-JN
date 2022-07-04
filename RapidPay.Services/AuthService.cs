using RapidPay.Entities.DTO;
using RapidPay.Entities.Interfaces;
using RapidPay.Entities.Model;
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

        public Task<UserDTO> CreateUser(LoginDTO login)
        {
            string encryptedPassword = encryptService.GetHash(login.Password);
            UserDTO userDTO = new()
            {
                Token = encryptedPassword,
                UserName = login.UserName
            };
            User newUser = new()
            {
                UserName = userDTO.UserName,
                Password = userDTO.Token
            };
            unitOfWork.UserRepository.Create(newUser);
            unitOfWork.SaveChanges();

            return Task.FromResult(userDTO);
        }

        public Task<UserDTO> GetUserByName(string userName)
        {
            var user = unitOfWork.UserRepository.UserByName(userName);
            UserDTO userDTO = new()
            {
                Id = user.Id,
                UserName = user.UserName
            };
            return Task.FromResult(userDTO);
        }

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
