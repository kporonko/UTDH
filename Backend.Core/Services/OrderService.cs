using AutoMapper;
using Backend.Core.Interfaces;
using Backend.Core.Models;
using Backend.Infrastructure.Data;
using Backend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        public async Task<OrderGetDTO?> PostOrder(OrderPostDTO order)
        {
            Order orderToAdd = new();
            _mapper.Map(order, orderToAdd);
            await _context.Orders.AddAsync(orderToAdd);
            var addedOrder = await _context.Orders.AddAsync(orderToAdd);
            foreach (CartItemPostDTO item in order.CartItems)
            {
                if (await _context.Cameras.FirstOrDefaultAsync(camera => camera.Id == item.CameraId) == null)
                {
                    return null;
                }
                await _context.CartItems.AddAsync(
                    new CartItem
                    {
                        CameraId = item.CameraId,
                        Amount = item.Amount,
                        Order = orderToAdd
                    });
            }
            await _context.SaveChangesAsync();

            var result = _mapper.Map(await _context.Orders.Include(order => order.CartItems).FirstAsync(order => order.Id == addedOrder.Entity.Id), new OrderGetDTO());
            return result;
        }

        public async Task<OrderGetDTO?> GetOrderById(int id)
        {
            Order? order = await _context.Orders.Include(order => order.CartItems).FirstAsync(order => order.Id == id);
            if (order == null)
            {
                return null;
            }
            var result = _mapper.Map(order, new OrderGetDTO());
            return result;
        }

        public async Task<List<CameraGetDTO>?> GetOrderCameras(int orderId)
        {
            Order? order = await _context.Orders.Include(order => order.CartItems).FirstOrDefaultAsync(order => order.Id == orderId);
            if (order == null)
            {
                return null;
            }

            List <CameraGetDTO> result = new List<CameraGetDTO>();
            foreach (CartItem cartItem in order.CartItems)
            {
                var camera = await _context.Cameras.FirstOrDefaultAsync(x => x.Id == cartItem.CameraId);
                if (camera == null)
                {
                    return null;
                }
                _context.Entry(camera).Reference(x => x.Model).Load();
                _context.Entry(camera).Reference(x => x.ResolutionCategory).Load();
                _context.Entry(camera).Collection(x => x.CameraInterfaces).Query().Include(x => x.Interface).Load();
                _context.Entry(camera).Collection(x => x.CameraSystems).Query().Include(x => x.System).Load();

                result.Add(_mapper.Map(camera, new CameraGetDTO()));
            }

            return result;
        }
    }
}
