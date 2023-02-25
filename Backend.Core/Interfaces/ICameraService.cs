using Backend.Core.Models;
using Backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Interfaces
{
    public interface ICameraService
    {
        Task<Camera?> GetCameraById(int id); 
        Task<List<CameraCard>> GetCameraCards();
        Task<CameraCard?> GetCameraCardById(int id);
    }
}
