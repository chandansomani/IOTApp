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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);


        //    // OnModelCreating can be called before 1st update-database
        //    // Once Database is created this method doesnt gets invoked
        //    //InitailSeedData.SeedData(modelBuilder);            
        //}

        public void ManualSeedData() 
        {
            var count = AppUser.Count();            
            
            Random rd = new Random();
                
                List<AppUser> users = new List<AppUser>()
                {
                    new AppUser() {UserName = "Admin", PasswordHash = Utilities.HashPass("admin"), UserType="Admin",     DeviceId = rd.Next(10000, 99999) },
                    new AppUser() {UserName = "User1", PasswordHash = Utilities.HashPass("user1"), UserType = "AppUser", DeviceId = rd.Next(10000, 99999) },
                    new AppUser() {UserName = "User2", PasswordHash = Utilities.HashPass("user2"), UserType = "AppUser", DeviceId = rd.Next(10000, 99999) },
                    new AppUser() {UserName = "User3", PasswordHash = Utilities.HashPass("user3"), UserType = "AppUser", DeviceId = rd.Next(10000, 99999) },
                    new AppUser() {UserName = "User4", PasswordHash = Utilities.HashPass("user4"), UserType = "AppUser", DeviceId = rd.Next(10000, 99999) }
                };
                AppUser.AddRange(users);
        }

        
    }
}
