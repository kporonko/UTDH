using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Models
{
    public class CameraCardGetDTO
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public decimal Price { get; set; }
        public string ModelName { get; set; }
    }
}
