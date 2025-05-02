using DigitalPropertyManagementBLL.Interfaces;
using DigitslPropertyManangementDAL.Data.Models;
using GP_DigitalPropertyManegmentApi.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Repositories
{
    public class AccessibilityAmenityRepository:GenericAmenityRepository<AccessibillityAmenity>,IAccessibilityAmenityRepository
    {
        public AccessibilityAmenityRepository(AppDbContext context):base(context)
        {
            
        }
    }
}
