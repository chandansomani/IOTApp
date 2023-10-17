using IOTAppDashboardAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace IOTAppDashboardAPI.Models
{
    public static class InitailSeedData
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            Random rd = new Random();
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser() { Id=1, UserName = "Admin", PasswordHash = Utilities.HashPass("admin"), UserType="Admin", DeviceId=rd.Next(10000,99999) },
                new AppUser() { Id=2, UserName = "User1", PasswordHash = Utilities.HashPass("user1"), UserType = "Appuser", DeviceId = rd.Next(10000, 99999) },
                new AppUser() { Id=3, UserName = "User2", PasswordHash = Utilities.HashPass("user2"), UserType = "Appuser", DeviceId = rd.Next(10000, 99999) },
                new AppUser() { Id=4, UserName = "User3", PasswordHash = Utilities.HashPass("user3"), UserType = "Appuser", DeviceId = rd.Next(10000, 99999) },
                new AppUser() { Id=5, UserName = "User4", PasswordHash = Utilities.HashPass("user4"), UserType = "Appuser", DeviceId = rd.Next(10000, 99999) }
                );
        }
    }
}
