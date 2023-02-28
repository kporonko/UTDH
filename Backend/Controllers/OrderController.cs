using Backend.Core.Models;
using LiqPay.SDK.Dto.Enums;
using LiqPay.SDK.Dto;
using LiqPay.SDK;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Newtonsoft.Json;
using Backend.Core.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Backend.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : Controller
    {
        const string publicApiKey = "";
        const string privateApiKey = "";

        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("payment")]
        public async Task<ActionResult> LiqPayPost(string jsonData, string signature)
        {
            var liqPayClient = new LiqPayClient(publicApiKey, privateApiKey);
            string sign = liqPayClient.StrToSign(publicApiKey + jsonData + privateApiKey);

            if (signature != sign)
            {
                return BadRequest();
            }

            var data = JsonConvert.DeserializeObject<Dictionary<String, Object>>(jsonData);
            data["status"].ToString();

            // send invoce by email
            var invoiceRequest = new LiqPayRequest
            {
                Email = "email@example.com",
                Amount = 200,
                Currency = "USD",
                OrderId = data["order_id"].ToString(),
                Action = LiqPayRequestAction.InvoiceSend,
                Language = LiqPayRequestLanguage.UK,
                Goods = new List<LiqPayRequestGoods> {
                    new LiqPayRequestGoods {
                        Amount = 100,
                        Count = 2,
                        Unit = "pcs.",
                        Name = "phone"
                    }
                }
            };

            //liqPayClient.IsCnbSandbox = true;
            var response = await liqPayClient.RequestAsync("request", invoiceRequest);

            if (response.Status == LiqPayResponseStatus.Success)
            {
                return Ok();
            }
            else
            {
                return Ok();
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post(OrderPostDTO order)
        {
            if (order.CartItems.IsNullOrEmpty())
            {
                return BadRequest("Cart is empty");
            }
            OrderGetDTO result = await _orderService.PostOrder(order);
            return Ok(result);
        }
    }
}
