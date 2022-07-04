
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RapidPay.Api.ViewModel;
using RapidPay.Entities.DTO;
using RapidPay.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly IAuthService authService;
        public AccountController(IAuthService authService) =>
            this.authService = authService;

        [HttpPost]
        [Route("Account")]
        public async Task<IActionResult> Account(LoginDTO login)
        {
            try
            {
                var user = await authService.Login(login);
                return Ok(user);
            }
            catch(Exception ex)
            {
                return Unauthorized(
                    new ErrorResponse()
                    {
                        Message = ex.Message
                    });
            }
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(LoginDTO login)
        {
            try
            {
                var user = authService.CreateUser(login);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return Unauthorized(
                    new ErrorResponse()
                    {
                        Message = ex.Message
                    });
            }
        }
    }
}
