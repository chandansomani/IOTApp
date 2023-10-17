using System.ComponentModel.DataAnnotations;

namespace IOTAppDashboardAPI.Models
{
    public class Device
    {
        public int Id { get; set; }        
        public string Name { get; set; } = string.Empty;
        public int Parameter1 { get; set; }
        public string Parameter2 { get; set; } = string.Empty;
        public decimal Parameter3 { get; set; }

    }
}
