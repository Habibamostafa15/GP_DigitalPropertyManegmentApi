using AutoMapper;
using DigitalPropertyManagementBLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Services
{
    public class ServicesManager(IUnitOfWork unitOfWork, IMapper mapper) : IServicesManager
    {
        public IPropertyServices PropertyServices { get; } = new PropertyServices(unitOfWork, mapper);
    }
}
