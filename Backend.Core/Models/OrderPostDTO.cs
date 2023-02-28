using Backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Models
{
    public class OrderPostDTO
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerPatronymic { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPostOffice { get; set; }
        public List<CartItemDTO> CartItems { get; set; }
    }
}
