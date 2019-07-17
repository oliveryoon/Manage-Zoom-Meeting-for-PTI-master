﻿using Microsoft.EntityFrameworkCore;
using SchoolWebApi.Models.MusicLessons;
using SchoolWebApi.Models.SickBays;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebAPI.Models
{
    public class SchoolContext:DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
           : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<SickBay> SickBays { get; set; }
        public DbSet<MusicLesson> MusicLessons { get; set; }
        /// <summary>  
        /// Gets or sets to product detail by product Id property.  
        /// </summary>  
        [Display(Name = "SickBay Simple")]
        public UspSickBaySignInOutUpdate SickBayUpdate { get; set; }
        [Display(Name = "SickBay Simple")]
        public UspSickBayStatusSelect SickBayStatus { get; set; }
        public UspMusicLessonStatusSelect SickMusicLessonStatus { get; set; }
        public UspMusicLessonSignInOutUpdate MusicLessonUpdate { get; set; }
        public UspMusicLessonStatusSelect SickMusicLessonAbsenceStatus { get; set; }
        public UspMusicLessonSignInOutUpdate MusicLessonAbsenceUpdate { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("uvStudents", "webapi"); //8213
            modelBuilder.Entity<Student>().Property(s => s.BirthDate).HasColumnName("StudentBirthDate");
            modelBuilder.Entity<Student>().Property(s => s.Gender).HasColumnName("StudentGender");
            modelBuilder.Entity<Student>().Property(s => s.Given1).HasColumnName("StudentGiven1");
            modelBuilder.Entity<Student>().Property(s => s.Preferred).HasColumnName("StudentPreferred");
            modelBuilder.Entity<Student>().Property(s => s.Surname).HasColumnName("StudentSurname");
            modelBuilder.Entity<Student>().Property(s => s.YearLevel).HasColumnName("StudentYearLevel");
            modelBuilder.Entity<Student>().Property(s => s.Id).HasColumnName("StudentID");
            modelBuilder.Entity<Student>().Property(s => s.Barcode).HasColumnName("StudentBarcode");
            modelBuilder.Entity<Student>().Property(s => s.Photo).HasColumnName("Photo");

            modelBuilder.Entity<SickBay>().ToTable("uvMedicalIncidents", "webapi"); //8213
            modelBuilder.Entity<SickBay>().Property(s => s.Seq).HasColumnName("Seq");
            modelBuilder.Entity<SickBay>().Property(s => s.Id).HasColumnName("ID");
            modelBuilder.Entity<SickBay>().Property(s => s.IncidentDate).HasColumnName("IncidentDate");
            modelBuilder.Entity<SickBay>().Property(s => s.TimeIn).HasColumnName("TimeIn");
            modelBuilder.Entity<SickBay>().Property(s => s.TimeOut).HasColumnName("TimeOut");
            modelBuilder.Entity<SickBay>().Property(s => s.DateTimeModified).HasColumnName("DateTimeModified");
            modelBuilder.Entity<SickBay>().Property(s => s.UsernameModified).HasColumnName("UsernameModified");

            modelBuilder.Entity<MusicLesson>().ToTable("uvMusicLessons", "webapi"); //8213            
            modelBuilder.Entity<MusicLesson>().Property(s => s.Seq).HasColumnName("Seq"); // staff schedule seq.
            modelBuilder.Entity<MusicLesson>().Property(s => s.Id).HasColumnName("ID");
            modelBuilder.Entity<MusicLesson>().Property(s => s.DateTimeIn).HasColumnName("DateTimeIn");
            modelBuilder.Entity<MusicLesson>().Property(s => s.DateTimeOut).HasColumnName("DateTimeOut");
            modelBuilder.Entity<MusicLesson>().Property(s => s.DateTimeModified).HasColumnName("DateTimeModified");
            modelBuilder.Entity<MusicLesson>().Property(s => s.DateTimeCreated).HasColumnName("DateTimeCreated");
            
            //modelBuilder.Entity<SickBay>().Property(s => s.Code).HasColumnName("Code");
            //modelBuilder.Entity<SickBay>().Property(s => s.Description).HasColumnName("Description");

            modelBuilder.Query<UspSickBaySignInOutUpdate>();
            modelBuilder.Query<UspSickBayStatusSelect>();
            modelBuilder.Query<UspMusicLessonSignInOutUpdate>();
            modelBuilder.Query<UspMusicLessonStatusSelect>();            
        }
        #region Create Sign In and Sign Out.  
        /// <summary>  
        /// Create Sign In and Sign Out.  
        /// </summary>  
        /// <returns>Returns - Music Lesson Record created or updated.</returns>  
        public MusicLesson UpdateMusicLessonAbsenceSignInOutAsync(MusicLessonDTO musicLessonDTO)
        {
            // Initialization.              

            try
            {
                // Set params.
                SqlParameter iDParam = new SqlParameter("@ID", musicLessonDTO.Id);

                SqlParameter DateTimeCardSwipedParam = new SqlParameter("@DateTimeCardSwiped", musicLessonDTO.DateTimeCardSwiped);
                SqlParameter RequestedJobCodeParam = new SqlParameter("@RequestedJobCode", musicLessonDTO.RequestedJobCode);
                SqlParameter TerminalCodeParam = new SqlParameter("@TerminalCode", musicLessonDTO.TerminalCode);

                // Processing.  
                //;Workstation ID={0}|{1}\{2}

                string sqlQuery = "EXEC webapi.uspMusicLessonAbsenceSignInOutUpdate @ID, @RequestedJobCode, @TerminalCode, @DateTimeCardSwiped";

                //Task<int> x = this.Database.ExecuteSqlCommandAsync(sqlQuery, iDParam, incidentDateParam, timeParam, usernameParam, venueCodeParam);
                //await this.Query<UspSickBayInOutUpdate>().FromSql(sqlQuery, iDParam, incidentDateParam, timeParam, usernameParam, venueCodeParam).ToListAsync();
                var sickbayInOut = this.Query<UspMusicLessonSignInOutUpdate>().FromSql(sqlQuery, iDParam, RequestedJobCodeParam, TerminalCodeParam, DateTimeCardSwipedParam).FirstOrDefault();
                MusicLesson musicLesson = new MusicLesson()
                {
                    Id = sickbayInOut.Id
                    ,
                    Code = sickbayInOut.Code
                    ,
                    DateTimeCreated = sickbayInOut.DateTimeCreated
                    ,
                    DateTimeIn = sickbayInOut.DateTimeIn
                    ,
                    DateTimeModified = sickbayInOut.DateTimeModified
                    ,
                    DateTimeOut = sickbayInOut.DateTimeOut
                    ,
                    Description = sickbayInOut.Description
                    ,
                    Seq = sickbayInOut.Seq
                };                
                return musicLesson;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        /// <summary>  
        /// Create Sign In and Sign Out.  
        /// </summary>  
        /// <returns>Returns - Music Lesson Record created or updated.</returns>  
        public MusicLessonDTO UpdateMusicLessonSignInOutAsync(MusicLessonDTO musicLessonDTO)
        {
            // Initialization.              

            try
            {
                // Set params.
                SqlParameter iDParam = new SqlParameter("@ID", musicLessonDTO.Id);
                
                SqlParameter DateTimeCardSwipedParam = new SqlParameter("@DateTimeCardSwiped", musicLessonDTO.DateTimeCardSwiped);
                SqlParameter RequestedJobCodeParam = new SqlParameter("@RequestedJobCode", musicLessonDTO.RequestedJobCode);
                SqlParameter TerminalCodeParam = new SqlParameter("@TerminalCode", musicLessonDTO.TerminalCode);

                // Processing.  
                //;Workstation ID={0}|{1}\{2}
                
                string sqlQuery = "EXEC webapi.uspMusicLessonSignInOutUpdate @ID, @RequestedJobCode, @TerminalCode, @DateTimeCardSwiped";

                //Task<int> x = this.Database.ExecuteSqlCommandAsync(sqlQuery, iDParam, incidentDateParam, timeParam, usernameParam, venueCodeParam);
                //await this.Query<UspSickBayInOutUpdate>().FromSql(sqlQuery, iDParam, incidentDateParam, timeParam, usernameParam, venueCodeParam).ToListAsync();
                var sickbayInOut = this.Query<UspMusicLessonSignInOutUpdate>().FromSql(sqlQuery, iDParam, RequestedJobCodeParam, TerminalCodeParam, DateTimeCardSwipedParam).FirstOrDefault();
                musicLessonDTO.Seq = sickbayInOut.Seq;
                return musicLessonDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        /// <summary>  
        /// Create Sign In and Sign Out.  
        /// </summary>  
        /// <returns>Returns - Incident Record created or updated.</returns>  
        public SickBayDTO UpdateSickBaySignInOutAsync(SickBayDTO sickBaySimple)
        {
            // Initialization.              

            try
            {
                // Set params.
                SqlParameter iDParam = new SqlParameter("@ID", sickBaySimple.Id);
                SqlParameter incidentDateParam = new SqlParameter("@IncidentDate", sickBaySimple.IncidentDate);
                SqlParameter timeParam = new SqlParameter("@Time", sickBaySimple.Time);
                SqlParameter usernameParam = new SqlParameter("@Username", sickBaySimple.UsernameModified);                
                SqlParameter RequestedJobCodeParam = new SqlParameter("@RequestedJobCode", sickBaySimple.RequestedJobCode);
                SqlParameter TerminalCodeParam = new SqlParameter("@TerminalCode", sickBaySimple.TerminalCode);

                // Processing.  
                string sqlQuery = "EXEC webapi.uspSickBaySignInOutUpdate @ID, @IncidentDate, @Time, @Username, @RequestedJobCode, @TerminalCode";

                //Task<int> x = this.Database.ExecuteSqlCommandAsync(sqlQuery, iDParam, incidentDateParam, timeParam, usernameParam, venueCodeParam);
                //await this.Query<UspSickBayInOutUpdate>().FromSql(sqlQuery, iDParam, incidentDateParam, timeParam, usernameParam, venueCodeParam).ToListAsync();
                var sickbayInOut = this.Query<UspSickBaySignInOutUpdate>().FromSql(sqlQuery, iDParam, incidentDateParam, timeParam, usernameParam, RequestedJobCodeParam, TerminalCodeParam).FirstOrDefault();
                sickBaySimple.Seq = sickbayInOut.Seq;
                return sickBaySimple;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }
        /// <summary>  
        /// Get a status.  
        /// </summary>  
        /// <returns>Returns - Music Lesson Record created or updated.</returns>  
        public MusicLessonStatusDTO GetMusicLessonAbsenceStatusAsync(MusicLessonStatusDTO status)
        {
            // Initialization.              

            try
            {
                // Set params.
                SqlParameter iDParam = new SqlParameter("@ID", status.Id);
                SqlParameter terminalCodeParam = new SqlParameter("@TerminalCode", status.TerminalCode);

                // Processing.  
                string sqlQuery = "EXEC webapi.uspMusicLessonAbsenceStatusSelect @ID, @TerminalCode";

                //Task<int> x = this.Database.ExecuteSqlCommandAsync(sqlQuery, iDParam, incidentDateParam, timeParam, usernameParam, venueCodeParam);
                //await this.Query<UspSickBayInOutUpdate>().FromSql(sqlQuery, iDParam, incidentDateParam, timeParam, usernameParam, venueCodeParam).ToListAsync();
                var musicLessonStatusSelect = this.Query<UspMusicLessonStatusSelect>().FromSql(sqlQuery, iDParam, terminalCodeParam).FirstOrDefault();
                status = new MusicLessonStatusDTO() { Id = musicLessonStatusSelect.Id, Seq = musicLessonStatusSelect.Seq, Code = musicLessonStatusSelect.Code, Description = musicLessonStatusSelect.Description, TerminalCode = status.TerminalCode };

                return status;


            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        /// <summary>  
        /// Get a status.  
        /// </summary>  
        /// <returns>Returns - Music Lesson Record created or updated.</returns>  
        public MusicLessonStatusDTO GetMusicLessonStatusAsync(MusicLessonStatusDTO status)
        {
            // Initialization.              

            try
            {
                // Set params.
                SqlParameter iDParam = new SqlParameter("@ID", status.Id);
                SqlParameter terminalCodeParam = new SqlParameter("@TerminalCode", status.TerminalCode);

                // Processing.  
                string sqlQuery = "EXEC webapi.uspMusicLessonStatusSelect @ID, @TerminalCode";

                //Task<int> x = this.Database.ExecuteSqlCommandAsync(sqlQuery, iDParam, incidentDateParam, timeParam, usernameParam, venueCodeParam);
                //await this.Query<UspSickBayInOutUpdate>().FromSql(sqlQuery, iDParam, incidentDateParam, timeParam, usernameParam, venueCodeParam).ToListAsync();
                var musicLessonStatusSelect = this.Query<UspMusicLessonStatusSelect>().FromSql(sqlQuery, iDParam, terminalCodeParam).FirstOrDefault();
                status = new MusicLessonStatusDTO() { Id = musicLessonStatusSelect.Id, Seq = musicLessonStatusSelect.Seq, Code = musicLessonStatusSelect.Code, Description = musicLessonStatusSelect.Description, TerminalCode = status.TerminalCode };

                return status;


            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        /// <summary>  
        /// Create Sign In and Sign Out.  
        /// </summary>  
        /// <returns>Returns - Incident Record created or updated.</returns>  
        public SickBayStatusDTO GetSickBayStatusAsync(int Id)
        {
            // Initialization.              

            try
            {
                // Set params.
                SqlParameter iDParam = new SqlParameter("@ID", Id);
                
                // Processing.  
                string sqlQuery = "EXEC webapi.uspSickBayStatusSelect @ID";

                //Task<int> x = this.Database.ExecuteSqlCommandAsync(sqlQuery, iDParam, incidentDateParam, timeParam, usernameParam, venueCodeParam);
                //await this.Query<UspSickBayInOutUpdate>().FromSql(sqlQuery, iDParam, incidentDateParam, timeParam, usernameParam, venueCodeParam).ToListAsync();
                var sickbayStatusSelect = this.Query<UspSickBayStatusSelect>().FromSql(sqlQuery, iDParam).FirstOrDefault();
                SickBayStatusDTO status = new SickBayStatusDTO(){ Id = sickbayStatusSelect.Id, Code = sickbayStatusSelect.Code, Description = sickbayStatusSelect.Description };
                
                return status;


            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        /// <summary>  
        /// Create Sign In and Sign Out.  
        /// </summary>  
        /// <returns>Returns - Incident Record created or updated.</returns>  
        public DbSet<SchoolWebApi.Models.MusicLessons.MusicLesson> MusicLesson { get; set; }

        #endregion

        //#region Get product by ID store procedure method.  

        ///// <summary>  
        ///// Get product by ID store procedure method.  
        ///// </summary>  
        ///// <param name="productId">Product ID value parameter</param>  
        ///// <returns>Returns - List of product by ID</returns>  
        //public async Task<List<SpGetProductByID>> GetProductByIDAsync(int productId)
        //{
        //    // Initialization.  
        //    List<SpGetProductByID> lst = new List<SpGetProductByID>();

        //    try
        //    {
        //        // Settings.  
        //        SqlParameter usernameParam = new SqlParameter("@product_ID", productId.ToString() ?? (object)DBNull.Value);

        //        // Processing.  
        //        string sqlQuery = "EXEC [dbo].[GetProductByID] " +
        //                            "@product_ID";

        //        lst = await this.Query<SpGetProductByID>().FromSql(sqlQuery, usernameParam).ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    // Info.  
        //    return lst;
        //}

        //#endregion
    }
}