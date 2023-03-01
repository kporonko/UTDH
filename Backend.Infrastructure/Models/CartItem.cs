using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int CameraId { get; set; }
        public Camera Camera { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
