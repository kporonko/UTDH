﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class System
    {
        public int Id { get; set; }
        public string SystemName { get; set; }

        public List<CameraSystem> CameraSystems { get; set; }
    }
}
