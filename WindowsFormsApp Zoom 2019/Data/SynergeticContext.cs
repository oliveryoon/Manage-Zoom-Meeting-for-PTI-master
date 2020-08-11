using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WindowsFormsApp_Zoom_2019.Models;

namespace WindowsFormsApp_Zoom_2019.Data
{
    public class SynergeticContext : DbContext
    {
        string _schema_name = "dbo";      
        public SynergeticContext(): base("SynergeticDatabase")
        {
            _schema_name = ConfigurationManager.AppSettings["db_schema_name"]; //It gets a name from app.config file.
        }
        public DbSet<ZoomUser> ZoomUsers { get; set; }
        public DbSet<vZoomUser> vZoomUsers { get; set; }
        public DbSet<Config> Configs { get; set; }
        public DbSet<ApprovalType> ApprovalTypes { get; set; }
        public DbSet<Audio> Audios { get; set; }
        public DbSet<AutoRecording> AutoRecordings { get; set; }
        public DbSet<MeetingType> MeetingTypes { get; set; }
        public DbSet<RegistrationType> RegistrationTypes { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ZoomUser>().ToTable("uZoom_Users", _schema_name); //         
            modelBuilder.Entity<Config>().ToTable("uZoom_Configs", _schema_name); //         
            modelBuilder.Entity<vZoomUser>().ToTable("uvZoom_Users", _schema_name); //         

            modelBuilder.Entity<ApprovalType>().ToTable("uZoom_ApprovalTypes", _schema_name); // 
            modelBuilder.Entity<Audio>().ToTable("uZoom_Audios", _schema_name); // 
            modelBuilder.Entity<AutoRecording>().ToTable("uZoom_AutoRecordings", _schema_name); // 
            modelBuilder.Entity<MeetingType>().ToTable("uZoom_MeetingTypes", _schema_name); // 
            modelBuilder.Entity<RegistrationType>().ToTable("uZoom_RegistrationTypes", _schema_name); // 
        }
        
    }
}
