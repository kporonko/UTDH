﻿using AutoMapper;
using Backend.Core.Interfaces;
using Backend.Core.Models;
using Backend.Infrastructure.Data;
using Backend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Services
{
    public class CameraService : ICameraService
    {
        private ApplicationContext _context;
        private readonly IMapper _mapper;

        public CameraService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CameraGetDTO?> GetCameraById(int id)
        {
            var camera = await _context.Cameras.FirstOrDefaultAsync(x => x.Id == id);
            if (camera == null)
            {
                return null;
            }
            _context.Entry(camera).Reference(x => x.Model).Load();
            _context.Entry(camera).Reference(x => x.ResolutionCategory).Load();
            _context.Entry(camera).Collection(x => x.CameraInterfaces).Query().Include(x => x.Interface).Load();
            _context.Entry(camera).Collection(x => x.CameraSystems).Query().Include(x => x.System).Load();

            CameraGetDTO result = new();
            _mapper.Map(camera, result);

            return result;
        }

        public async Task<CameraCardGetDTO?> GetCameraCardById(int id)
        {
            var camera = await _context.Cameras.FirstOrDefaultAsync(x => x.Id == id);
            if (camera == null )
            {
                return null;
            }
            _context.Entry(camera).Reference(x => x.Model).Load();

            return new CameraCardGetDTO
            {
                Id = camera.Id,
                ModelName = camera.Model.ModelName,
                Photo = camera.Photo,
                Price = camera.Price
            };
        }

        public async Task<List<CameraCardGetDTO>> GetCameraCards()
        {
            var cameras = await _context.Cameras.Include(x => x.Model).ToListAsync();

            var resList = new List<CameraCardGetDTO>();
            foreach (var camera in cameras)
            {
                resList.Add(new CameraCardGetDTO
                {
                    Id = camera.Id,
                    ModelName = camera.Model.ModelName,
                    Photo = camera.Photo,
                    Price = camera.Price
                });
            }

            return resList;
        }

        public async Task<List<CameraCardGetDTO>> GetCardsByModelName(string modelName)
        {
            var cards = GetCameraCards().Result.Where(card => card.ModelName.StartsWith(modelName)).ToList();

            return cards;
        }

        public async Task<List<CameraGetDTO?>> GetCamerasById(int[] ids)
        {
            var resList = new List<CameraGetDTO?>();
            foreach (var id in ids)
            {
                var camera = await _context.Cameras.FirstOrDefaultAsync(x => x.Id == id);
                if (camera == null)
                {
                    return null;
                }
                _context.Entry(camera).Reference(x => x.Model).Load();
                _context.Entry(camera).Reference(x => x.ResolutionCategory).Load();
                _context.Entry(camera).Collection(x => x.CameraInterfaces).Query().Include(x => x.Interface).Load();
                _context.Entry(camera).Collection(x => x.CameraSystems).Query().Include(x => x.System).Load();

                CameraGetDTO result = new();
                _mapper.Map(camera, result);
                resList.Add(result);
            }

            return resList;

        }

        public async Task<List<CameraGetDTO>> GetCameras()
        {
            var resList = new List<CameraGetDTO>();
            var cameras = await _context.Cameras
                .Include(c => c.Model)
                .Include(c => c.ResolutionCategory)
                .Include(c => c.CameraInterfaces)
                    .ThenInclude(e => e.Interface)
                .Include(c => c.CameraSystems)
                    .ThenInclude(e => e.System)
                .ToListAsync();
            foreach (var camera in cameras)
            {
                CameraGetDTO result = new();
                _mapper.Map(camera, result);
                resList.Add(result);
            }

            return resList;
        }
    }
}
