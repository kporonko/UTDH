using Backend.Core.Interfaces;
using Backend.Core.Models;
using Backend.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Backend.Controllers
{
    [Route("cameras")]
    [ApiController]
    public class CameraController : Controller
    {
        private readonly ICameraService _cameraService;
        public CameraController(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        [HttpGet()]
        public async Task<ActionResult<List<Camera>>> Get()
        {
            List<Camera> activities = await _cameraService.GetCameras();
            return Ok(activities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Camera>> GetById(int id)
        {
            Camera? activities = await _cameraService.GetCameraById(id);
            return Ok(activities);
        }

        [HttpGet("cards")]
        public async Task<ActionResult<List<CameraCard>>> GetCards()
        {
            List<CameraCard> activities = await _cameraService.GetCameraCards();
            return Ok(activities);
        }

        [HttpGet("cards/{id}")]
        public async Task<ActionResult<CameraCard>> GetCardbyId(int id)
        {
            CameraCard? activities = await _cameraService.GetCameraCardById(id);
            return Ok(activities);
        }
    }
}
