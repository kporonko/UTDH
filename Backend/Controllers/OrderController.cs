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
using Backend.Core.Services;
using MailKit.Net.Smtp;
using System.Net.Mail;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Backend.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : Controller
    {
        string CompanyEmail = "uthd2023@gmail.com";
        string CompanyPassword = "oyowvxbisyngvxit";
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
        public async Task<ActionResult> LiqPayPost([FromBody] PaymantDto model)
        {
            string sign = liqPayClient.StrToSign(publicApiKey + model.Data + privateApiKey);

            if (model.Signature != sign)
            {
                return BadRequest();
            }

            var data = JsonConvert.DeserializeObject<Dictionary<String, Object>>(model.Data);
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
                    // Send email
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
            Send(CreateEmailMessage(order.CustomerEmail, "Order status update", $"Your order {result.Id} is successfully accepted!"));
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

        private MimeMessage CreateEmailMessage(string email, string subject, string content)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(MailboxAddress.Parse(CompanyEmail));
            emailMessage.To.Add(MailboxAddress.Parse(email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = content };
            return emailMessage;
        }
        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(CompanyEmail, CompanyPassword);
                    client.Send(mailMessage);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
