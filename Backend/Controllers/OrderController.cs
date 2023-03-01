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
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using Backend.Core.Services;

namespace Backend.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : Controller
    {
        const string publicApiKey = "1";
        const string privateApiKey = "1";
        LiqPayClient liqPayClient = new LiqPayClient(publicApiKey, privateApiKey);

        private readonly IOrderService _orderService;
        private readonly ICameraService _cameraService;

        public OrderController(IOrderService orderService, ICameraService cameraService)
        {
            _orderService = orderService;
            _cameraService = cameraService;
        }

        [HttpPost("payment")]
        public async Task<ActionResult> LiqPayPost(string jsonData, string signature)
        {
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
                    int orderId = int.Parse(data["order_id"].ToString()!);
                    OrderGetDTO? order = await _orderService.GetOrderById(orderId);
                    if (order == null)
                    {
                        break;
                    }
                    SendSuccessEmail(order);
                    break;
            }
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<OrderGetDTO>> Post(OrderPostDTO order)
        {
            if (order.CartItems.IsNullOrEmpty())
            {
                return BadRequest("Cart is empty");
            }
            OrderGetDTO? result = await _orderService.PostOrder(order);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        private async Task<bool> CreateInvoiceAsync(Dictionary<String, Object> data)
        {
            int orderId = int.Parse(data["order_id"].ToString()!);
            OrderGetDTO? order = await _orderService.GetOrderById(orderId);
            if (order == null)
            {
                return false;
            }

            List<LiqPayRequestGoods> goods = new List<LiqPayRequestGoods>();
            double totalSum = 0;
            foreach (var cartItem in order.CartItems)
            {
                CameraGetDTO camera =  await _cameraService.GetCameraById(cartItem.CameraId);
                goods.Add(new LiqPayRequestGoods
                {
                    Amount = (double)camera.Price,
                    Count = cartItem.Amount,
                    Unit = "шт.",
                    Name = camera.ModelName
                });
                totalSum += cartItem.Amount * (double)camera.Price;
            }
            var invoiceRequest = new LiqPayRequest
            {
                Email = order.CustomerEmail,
                Amount = totalSum,
                Currency = "UAH",
                OrderId = orderId.ToString(),
                Action = LiqPayRequestAction.InvoiceSend,
                Language = LiqPayRequestLanguage.UK,
                Goods = goods
            };

            //liqPayClient.IsCnbSandbox = true;
            var response = await liqPayClient.RequestAsync("request", invoiceRequest);
            return response.Status == LiqPayResponseStatus.Success;
        }

        private void SendSuccessEmail(OrderGetDTO order)
        {
            string subject = "Order status update";
            string message = $"Your order {order.Id} is successfully accepted!";
            SendEmailAsync(order.CustomerEmail, subject, message);
        }

        private Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient("smtp.office365.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("your.email@live.com", "your password")
            };

            return client.SendMailAsync(
                new MailMessage(from: "your.email@live.com",
                                to: email,
                                subject,
                                message
                                ));
        }
    }
}
