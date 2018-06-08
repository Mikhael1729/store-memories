using Microsoft.EntityFrameworkCore;
using StoreMemories.Models;
using System;
using System.IO;
using Xamarin.Forms;

namespace StoreMemories.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string databaseName = "storememories5.db";

        public DbSet<Memory> Memories { get; set; }
        public DbSet<Photo> Photos { get; set; }
        
        public ApplicationDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String databasePath = "";
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    SQLitePCL.Batteries_V2.Init();
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", databaseName); ;
                    break;
                case Device.Android:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), databaseName);
                    break;
                default:
                    throw new NotImplementedException("Platform not supported");
            }
            // Specify that we will use sqlite and the path of the database here
            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }
    }
}
