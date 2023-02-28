using Backend.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Interfaces
{
    public interface IOrderService
    {
        public Task<OrderGetDTO> PostOrder(OrderPostDTO order);
        public Task<bool> DeleteOrder(int id);
        public Task<OrderGetDTO> GetOrderById(int id);
    }
}
