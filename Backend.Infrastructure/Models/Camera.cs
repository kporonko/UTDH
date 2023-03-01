using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class Camera
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

        public int ResolutionCategoryId { get; set; }
        public ResolutionCategory ResolutionCategory { get; set; }

        public int ModelId { get; set; }
        public Model Model { get; set; }

        public List<InterfaceCamera> CameraInterfaces { get; set; }
        public List<CameraSystem> CameraSystems { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
