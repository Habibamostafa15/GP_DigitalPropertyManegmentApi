using AutoMapper;
using DigitalPropertyManagementBLL.Dtos;
using DigitalPropertyManagementBLL.Interfaces;
using DigitalPropertyManagementBLL.Services.Specifications;
using GP_DigitalPropertyManegmentApi.Data.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Services
{
    public class PropertyServices(IUnitOfWork unitOfWork, IMapper mapper) : IPropertyServices
    {
        public async Task<paginationResponse<PropertyResponseDto>> GetAllAsync(PropertySpecificationsParameters specParams)
        {
            var spec = new PropertyWithIncludedsSpecification(specParams);
            var properties = await unitOfWork.GetRepository<Property>().GetAllAsync(spec);

            var specCount = new PropertyWithCountSpecification(specParams);
            var count = await unitOfWork.GetRepository<Property>().CountAsync(specCount);

            var result = mapper.Map<IEnumerable<PropertyResponseDto>>(properties);

            return new paginationResponse<PropertyResponseDto>(specParams.PageIndex, specParams.PageSize, count, result);

        }

        public async Task<paginationResponse<PropertiesReadDto>> GetPropertiesByCityAsync(string city, int pageIndex, int pageSize)
        {
            var spec = new PropertyWithIncludedsSpecification(city);
            var properties = await unitOfWork.GetRepository<Property>().GetAllAsync(spec);

            var specCount = new PropertyWithCountSpecification(city);
            var count = await unitOfWork.GetRepository<Property>().CountAsync(specCount);

            var result = mapper.Map<IEnumerable<PropertiesReadDto>>(properties);

            return new paginationResponse<PropertiesReadDto>(pageIndex, pageSize, count, result);
        }
    }
}
