using AutoMapper;
using DigitalPropertyManagementBLL.Dtos;
using GP_DigitalPropertyManegmentApi.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Services.MappingProfiles
{
    public class PropertyProfile : Profile
    {
        public PropertyProfile()
        {
            //CreateMap<Property, PropertiesReadDto>();

            CreateMap<Property, PropertiesReadDto>()
                .ForMember(dest => dest.InternalAmenities,
                    opt => opt.MapFrom(src => src.InternalAmenities.Select(a => a.Name)))
                .ForMember(dest => dest.ExternalAmenities,
                    opt => opt.MapFrom(src => src.ExternalAmenities.Select(a => a.Name)))
                .ForMember(dest => dest.AccessibilityAmenities,
                    opt => opt.MapFrom(src => src.AccessibilityAmenities.Select(a => a.Name)));
        }
    }
}
