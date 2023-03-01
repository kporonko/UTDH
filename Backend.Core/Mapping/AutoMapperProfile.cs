using AutoMapper;
using Backend.Core.Models;
using Backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Mapping
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Camera, CameraGetDTO>()
                .ForMember(
                    dest => dest.InterfaceNames,
                    opt => opt.MapFrom(src => src.CameraInterfaces.Select(cameraInterface => cameraInterface.Interface.InterfaceName))
                )
                .ForMember(
                    dest => dest.SystemNames,
                    opt => opt.MapFrom(src => src.CameraSystems.Select(cameraSystem => cameraSystem.System.SystemName))
                )
                .ForMember(
                    dest => dest.SystemNames,
                    opt => opt.MapFrom(src => src.CameraSystems.Select(cameraSystem => cameraSystem.System.SystemName))
                )
                .ForMember(
                    dest => dest.Manufacturer,
                    opt => opt.MapFrom(src => src.Model.Manufacturer)
                )
                .ForMember(
                    dest => dest.ModelName,
                    opt => opt.MapFrom(src => src.Model.ModelName)
                )
                .ForMember(
                    dest => dest.Country,
                    opt => opt.MapFrom(src => src.Model.Country)
                )
                .ForMember(
                    dest => dest.Resolution,
                    opt => opt.MapFrom(src => src.ResolutionCategory.Resolution)
                )
                .ForMember(
                    dest => dest.ResolutionName,
                    opt => opt.MapFrom(src => src.ResolutionCategory.ResolutionName)
                );

            CreateMap<OrderPostDTO, Order>()
                .ForMember(
                    dest => dest.CartItems,
                    opt => opt.Ignore()
                );
            CreateMap<Order, OrderGetDTO>()
                .ForMember(
                    dest => dest.CartItems,
                    opt => opt.MapFrom(src => src.CartItems.Select(cartItem => new CartItemGetDTO { CameraId = cartItem.CameraId, Amount = cartItem.Amount}))
                );
        }
    }
}
