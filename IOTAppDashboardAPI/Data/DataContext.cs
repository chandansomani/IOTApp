using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IOTAppDashboardAPI.Models;
using System.Text;
using IOTAppDashboardAPI.Services;

namespace IOTAppDashboardAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<IOTAppDashboardAPI.Models.AppUser> AppUser { get; set; } = default!;

        public DbSet<IOTAppDashboardAPI.Models.Device> Devices { get; set; }

        public DbSet<IOTAppDashboardAPI.Models.Readings> Readings { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);


        //    // OnModelCreating can be called before 1st update-database
        //    // Once Database is created this method doesnt gets invoked
        //    //InitailSeedData.SeedData(modelBuilder);            
        //}

        public void ManualSeedData(string param) 
        {
            var count = AppUser.Count();

            Random rd = new Random();

            switch (param)
            {
                case "AppUser":
                    List<AppUser> users = new List<AppUser>()
                    {
                        new AppUser() {UserName = "Admin", PasswordHash = Utilities.HashPass("admin"), UserType="Admin",     DeviceId = rd.Next(10000, 99999) },
                        new AppUser() {UserName = "User1", PasswordHash = Utilities.HashPass("user1"), UserType = "AppUser", DeviceId = rd.Next(10000, 99999) },
                        new AppUser() {UserName = "User2", PasswordHash = Utilities.HashPass("user2"), UserType = "AppUser", DeviceId = rd.Next(10000, 99999) },
                        new AppUser() {UserName = "User3", PasswordHash = Utilities.HashPass("user3"), UserType = "AppUser", DeviceId = rd.Next(10000, 99999) },
                        new AppUser() {UserName = "User4", PasswordHash = Utilities.HashPass("user4"), UserType = "AppUser", DeviceId = rd.Next(10000, 99999) }
                    };
                    AppUser.AddRange(users);
                    break;
                case "Devices":
                    List<Device> devices = new List<Device>()
                    {
                        new Device() { Name = "Device 1", Parameter1 = rd.Next(1,100), Parameter2 ="Low", Parameter3 = rd.Next(0,200) },
                        new Device() { Name = "Device 2", Parameter1 = rd.Next(1,100), Parameter2 ="Low", Parameter3 = rd.Next(0,200) },
                        new Device() { Name = "Device 3", Parameter1 = rd.Next(1,100), Parameter2 ="Low", Parameter3 = rd.Next(0,200) },
                    };
                    Devices.AddRange(devices);
                    break;

                case "Readings":

                    break;
            }
        }
    }
}
