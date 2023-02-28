using AutoMapper;
using Backend.Core.Interfaces;
using Backend.Core.Models;
using Backend.Infrastructure.Data;
using Backend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Services
{
    public class OrderService : IOrderService
    {
        private ApplicationContext _context;
        private readonly IMapper _mapper;

        public OrderService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            Order? orderToDelete = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (orderToDelete == null)
            {
                return false;
            }
            var result = _context.Orders.Remove(orderToDelete);
            return result.State == EntityState.Deleted;
        }

        public async Task<OrderGetDTO> PostOrder(OrderPostDTO order)
        {
            Order orderToAdd = new();
            _mapper.Map(order, orderToAdd);
            var addedOrder = await _context.Orders.AddAsync(orderToAdd);
            foreach (CartItemDTO item in order.CartItems)
            {
                _context.CartItems.Add(
                    new CartItem
                    {
                        CameraId = item.CameraId,
                        Amount = item.Amount,
                        OrderId = addedOrder.Entity.Id
                    });
            }
            await _context.SaveChangesAsync();
            var result = _mapper.Map(_context.Orders.Find(addedOrder), new OrderGetDTO());
            return result;
        }

        public Task<OrderGetDTO> GetOrderById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
