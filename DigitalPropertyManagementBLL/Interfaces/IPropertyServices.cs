﻿using DigitalPropertyManagementBLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Interfaces
{
    public interface IPropertyServices
    {
        Task<paginationResponse<PropertiesReadDto>> GetAllAsync(PropertySpecificationsParameters specParams);
    }
}
