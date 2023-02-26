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

        [HttpGet("{id}")]
        public async Task<ActionResult<CameraDTO>> GetById(int id)
        {
            CameraDTO? camera = await _cameraService.GetCameraById(id);

            if (camera is null)
            {
                return NotFound();
            }
            
            return Ok(camera);
        }

        [HttpGet("cards/search")]
        public async Task<ActionResult<List<CameraCard>>> GetCardsByModelName([FromQuery(Name = "modelName")] string modelName)
        {
            List<CameraCard> cameraCards = await _cameraService.GetCardsByModelName(modelName);
            if (cameraCards is null)
            {
                return NotFound();
            }

            return Ok(cameraCards);
        }

        [HttpGet("cards")]
        public async Task<ActionResult<List<CameraCard>>> GetCards()
        {
            List<CameraCard> cameraCards = await _cameraService.GetCameraCards();
            if (cameraCards is null)
            {
                return NotFound();
            }
            
            return Ok(cameraCards);
        }

        [HttpGet("cards/{id}")]
        public async Task<ActionResult<CameraCard>> GetCardbyId(int id)
        {
            CameraCard? cameraCard = await _cameraService.GetCameraCardById(id);
            if (cameraCard is null)
            {
                return NotFound();
            }
            return Ok(cameraCard);
        }
    }
}
