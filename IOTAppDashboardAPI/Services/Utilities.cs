using System.Security.Cryptography;
using System.Text;

namespace IOTAppDashboardAPI.Services
{
    public class Utilities
    {
        public static byte[] HashPass(string Pass)
        {
            return SHA256.HashData(Encoding.UTF8.GetBytes(Pass));
        }
    }
}
