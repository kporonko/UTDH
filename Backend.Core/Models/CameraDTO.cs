using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Models
{
    public class CameraDTO
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public decimal Price { get; set; }
        public int InStockCount { get; set; }
        public double SensorWidth { get; set; }
        public double SensorHeight { get; set; }
        public bool IsOpticInComplect { get; set; }
        public double MegaPixels { get; set; }
        public string LCDMount { get; set; }
        public string Microphone { get; set; }
        public string Protection { get; set; }
        public string Supply { get; set; }
        public bool IsMacroPhotography { get; set; }
        public string Stabilization { get; set; }
        public bool IsRAWSupport { get; set; }
        public string SoundFormat { get; set; }
        public bool IsSensorDisplay { get; set; }
        public string ExpositionMode { get; set; }
        public string LCDDiagonal { get; set; }
        public int MaxZoomValue { get; set; }
        public string Manufacturer { get; set; }
        public string ModelName { get; set; }
        public string Country { get; set; }
        public string ResolutionName { get; set; }
        public string Resolution { get; set; }
        public List<string> InterfaceNames { get; set; }
        public List<string> SystemNames { get; set; }
    }
}
