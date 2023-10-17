namespace IOTAppDashboardAPI.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public string UserType { get; set; }
        public int DeviceId { get; set; }
    }
}
