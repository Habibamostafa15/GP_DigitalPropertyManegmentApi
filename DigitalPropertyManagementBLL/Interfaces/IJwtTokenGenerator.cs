using GP_DigitalPropertyManegmentApi.Data.Context;

namespace DigitalPropertyManagementBLL.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}