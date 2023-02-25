using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class ResolutionCategory
    {
        public int Id { get; set; }
        public string ResolutionName { get; set; }
        public string Resolution { get; set;}

        public List<Camera> Cameras { get; set; }
    }
}
