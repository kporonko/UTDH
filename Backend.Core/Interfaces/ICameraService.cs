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
        Task<CameraGetDTO?> GetCameraById(int id);
        Task<List<CameraGetDTO?>> GetCamerasById(int[] ids);
        Task<List<CameraGetDTO>> GetCameras();
        Task<List<CameraCardGetDTO>> GetCameraCards();
        Task<List<CameraCardGetDTO>> GetCardsByModelName(string modelName);
        Task<CameraCardGetDTO?> GetCameraCardById(int id);
    }
}
