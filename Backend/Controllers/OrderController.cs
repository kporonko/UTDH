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
        LiqPayClient liqPayClient;

        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("payment")]
        public async Task<ActionResult> LiqPayPost(string jsonData, string signature)
        {
            liqPayClient = new LiqPayClient(publicApiKey, privateApiKey);
            string sign = liqPayClient.StrToSign(publicApiKey + jsonData + privateApiKey);

            if (signature != sign)
            {
                return BadRequest();
            }

            var data = JsonConvert.DeserializeObject<Dictionary<String, Object>>(jsonData);
            string status = data["status"].ToString();
            switch (status)
            {
                case "cash_wait":
                    await CreateInvoiceAsync(data);
                    break;
                case "success":
                    break;
            }
            return Ok();
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

        private async Task CreateInvoiceAsync(Dictionary<String, Object> data)
        {
            int orderId = int.Parse(data["order_id"].ToString()!);
            OrderGetDTO order = await _orderService.GetOrderById(orderId);
            var invoiceRequest = new LiqPayRequest
            {
                Email = order.CustomerEmail,
                Amount = 200,
                Currency = "USD",
                OrderId = orderId.ToString(),
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
        }
    }
}
