﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Dtos
{
    public class PropertyCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string PropertyType { get; set; }
        public double Size { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Governate { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }

    }
}
