using Backend.Core.Models;
using LiqPay.SDK.Dto.Enums;
using LiqPay.SDK.Dto;
using LiqPay.SDK;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Newtonsoft.Json;

namespace Backend.Controllers
{
    [ApiController]
    [Route("payment")]
    public class PaymentController : Controller
    {
        const string publicApiKey = "";
        const string privateApiKey = "";

        [HttpPost()]
        public async Task<ActionResult> Post(string jsonData, string signature)
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
                Language = LiqPayRequestLanguage.EN,
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
    }
}
