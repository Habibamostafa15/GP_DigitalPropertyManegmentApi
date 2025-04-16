using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Interfaces
{
    public interface IServicesManager
    {
        IPropertyServices PropertyServices { get; }
    }
}
