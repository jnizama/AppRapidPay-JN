using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RapidPay.Api.ViewModel;
using RapidPay.Entities.DTO;
using RapidPay.Entities.Interfaces;
using RapidPay.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CardController : ControllerBase
    {
        private readonly ICardManagementService cardService;
        public CardController(ICardManagementService _cardService) =>
            cardService = _cardService;


        [HttpGet]
        [Route("GetCardBalance")]
        public async Task<IActionResult> GetCardBalance(int id)
        {
            try
            {
                var card = await cardService.GetCardBalance(id);

                return Ok(card);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new ErrorResponse()
                    {
                        Message = ex.Message
                    });
            }
        }


        [HttpPost]
        [Route("CreateCard")]
        public async Task<IActionResult> CreateCard(CreateCardDTO card)
        {
            try
            {
                var newCard = await cardService.CreateCard(card);
                return Ok(newCard);
            }
            catch(Exception ex)
            {
                return BadRequest(
                    new ErrorResponse()
                    {
                        Message = ex.Message
                    });
            }
        }

        [HttpPost]
        [Route("Payment")]
        public async Task<IActionResult> Payment(NewPaymentDTO payment)
        {
            try
            {
                await cardService.Pay(payment);
                return Ok(
                    new
                    {
                        Message = "Payment sucessfull"
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new ErrorResponse()
                    {
                        Message = ex.Message
                    });
            }
        }
    }
}
