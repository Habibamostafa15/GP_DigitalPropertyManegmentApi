using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPropertyManagementBLL.Dtos
{
    public class ConfirmRegistrationDTO
    {

        public string OTP { get; set; }
        public UserDTO UserDto { get; set; }
    }
}
