using Backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Models
{
    public class CartItemDTO
    {
        public int Amount { get; set; }
        public int CameraId { get; set; }
    }
}
