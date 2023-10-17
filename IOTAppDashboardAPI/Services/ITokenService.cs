using IOTAppDashboardAPI.Models;

namespace IOTAppDashboardAPI.Services
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
