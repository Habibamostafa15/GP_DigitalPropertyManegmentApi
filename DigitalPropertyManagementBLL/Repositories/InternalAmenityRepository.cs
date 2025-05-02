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
    public class InternalAmenityRepository : GenericAmenityRepository<InternalAmenity>, IInternalAmenityRepository
    {
        public InternalAmenityRepository(AppDbContext context):base(context) { }
        
    }
}
