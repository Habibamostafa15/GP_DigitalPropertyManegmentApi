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
            CreateMap<Property, PropertiesReadDto>();

            CreateMap<Property, PropertyResponseDto>()
                .ForMember(dest => dest.PropertyImages,
                    opt => opt.MapFrom(src => src.PropertyImages.Select(p => p.ImageUrl)))
                .ForMember(dest => dest.OwnerInfo,
                    opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.InternalAmenities,
                    opt => opt.MapFrom(src => src.InternalAmenities.Select(p => p.Name)))
                .ForMember(dest => dest.ExternalAmenities,
                    opt => opt.MapFrom(src => src.ExternalAmenities.Select(p => p.Name)))
                .ForMember(dest => dest.AccessibilityAmenities,
                    opt => opt.MapFrom(src => src.AccessibilityAmenities.Select(p => p.Name)));

            CreateMap<User, OwnerInfoDto>()
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
        }
    }
}
