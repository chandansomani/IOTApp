namespace IOTAppDashboardAPI.Models
{
    public class Readings
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string Sensor { get; set; }
        public int ReadingValue { get; set; }
        public DateTime Moment { get; set; }
        public int ReportedByAppUserId { get; set; }
    }
}
