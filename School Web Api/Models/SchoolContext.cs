using Microsoft.EntityFrameworkCore;
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
        public UspSickBayInOutUpdate SickBayUpdate { get; set; }
        [Display(Name = "SickBay Simple")]
        public UspSickBayStatusSelect SickBayStatus { get; set; }
        public UspMusicLessonStatusSelect SickMusicLessonStatus { get; set; }
        public UspMusicLessonInOutUpdate MusicLessonUpdate { get; set; }
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
            modelBuilder.Entity<SickBay>().Property(s => s.DateModified).HasColumnName("DateModified");
            modelBuilder.Entity<SickBay>().Property(s => s.UsernameModified).HasColumnName("UsernameModified");

            modelBuilder.Entity<MusicLesson>().ToTable("uvMedicalIncidents", "webapi"); //8213
            modelBuilder.Entity<MusicLesson>().Property(s => s.Seq).HasColumnName("Seq");            
            modelBuilder.Entity<MusicLesson>().Property(s => s.DateTimeIn).HasColumnName("DateTimeIn");
            modelBuilder.Entity<MusicLesson>().Property(s => s.DateTimeOut).HasColumnName("DateTimeOut");
            modelBuilder.Entity<MusicLesson>().Property(s => s.DateModified).HasColumnName("DateModified");
            modelBuilder.Entity<MusicLesson>().Property(s => s.DateCreated).HasColumnName("DateCreated");


            //modelBuilder.Entity<SickBay>().Property(s => s.Code).HasColumnName("Code");
            //modelBuilder.Entity<SickBay>().Property(s => s.Description).HasColumnName("Description");

            modelBuilder.Query<UspSickBayInOutUpdate>();
            modelBuilder.Query<UspSickBayStatusSelect>();
        }
        #region Create Sign In and Sign Out.  

        /// <summary>  
        /// Create Sign In and Sign Out.  
        /// </summary>  
        /// <returns>Returns - Music Lesson Record created or updated.</returns>  
        public MusicLessonDTO UpdateMusicLessonInOutAsync(MusicLessonDTO musicLessonDTO)
        {
            // Initialization.              

            try
            {
                // Set params.
                SqlParameter iDParam = new SqlParameter("@ID", musicLessonDTO.Id);                
                SqlParameter RequestedJobCodeParam = new SqlParameter("@RequestedJobCode", musicLessonDTO.RequestedJobCode);
                SqlParameter TerminalCodeParam = new SqlParameter("@TerminalCode", musicLessonDTO.TerminalCode);

                // Processing.  
                string sqlQuery = "EXEC webapi.uspMusicLessonInOutUpdate @ID, @RequestedJobCode, @TerminalCode";

                //Task<int> x = this.Database.ExecuteSqlCommandAsync(sqlQuery, iDParam, incidentDateParam, timeParam, usernameParam, venueCodeParam);
                //await this.Query<UspSickBayInOutUpdate>().FromSql(sqlQuery, iDParam, incidentDateParam, timeParam, usernameParam, venueCodeParam).ToListAsync();
                var sickbayInOut = this.Query<UspMusicLessonInOutUpdate>().FromSql(sqlQuery, iDParam, RequestedJobCodeParam, TerminalCodeParam).FirstOrDefault();
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
        public SickBayDTO UpdateSickBayInOutAsync(SickBayDTO sickBaySimple)
        {
            // Initialization.              

            try
            {
                // Set params.
                SqlParameter iDParam = new SqlParameter("@ID", sickBaySimple.Id);
                SqlParameter incidentDateParam = new SqlParameter("@IncidentDate", sickBaySimple.IncidentDate);
                SqlParameter timeParam = new SqlParameter("@Time", sickBaySimple.Time);
                SqlParameter usernameParam = new SqlParameter("@Username", sickBaySimple.UsernameModified);
                SqlParameter venueCodeParam = new SqlParameter("@VenueCode", "test");
                SqlParameter RequestedJobCodeParam = new SqlParameter("@RequestedJobCode", sickBaySimple.RequestedJobCode);
                SqlParameter TerminalCodeParam = new SqlParameter("@TerminalCode", sickBaySimple.TerminalCode);

                // Processing.  
                string sqlQuery = "EXEC webapi.uspSickBayInOutUpdate @ID, @IncidentDate, @Time, @Username, @VenueCode, @RequestedJobCode, @TerminalCode";

                //Task<int> x = this.Database.ExecuteSqlCommandAsync(sqlQuery, iDParam, incidentDateParam, timeParam, usernameParam, venueCodeParam);
                //await this.Query<UspSickBayInOutUpdate>().FromSql(sqlQuery, iDParam, incidentDateParam, timeParam, usernameParam, venueCodeParam).ToListAsync();
                var sickbayInOut = this.Query<UspSickBayInOutUpdate>().FromSql(sqlQuery, iDParam, incidentDateParam, timeParam, usernameParam, venueCodeParam, RequestedJobCodeParam, TerminalCodeParam).FirstOrDefault();
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
        public MusicLessonStatusDTO GetMusicLessonStatusAsync(int Id)
        {
            // Initialization.              

            try
            {
                // Set params.
                SqlParameter iDParam = new SqlParameter("@ID", Id);

                // Processing.  
                string sqlQuery = "EXEC webapi.uspMusicLessonStatusSelect @ID";

                //Task<int> x = this.Database.ExecuteSqlCommandAsync(sqlQuery, iDParam, incidentDateParam, timeParam, usernameParam, venueCodeParam);
                //await this.Query<UspSickBayInOutUpdate>().FromSql(sqlQuery, iDParam, incidentDateParam, timeParam, usernameParam, venueCodeParam).ToListAsync();
                var musicLessonStatusSelect = this.Query<UspMusicLessonStatusSelect>().FromSql(sqlQuery, iDParam).FirstOrDefault();
                MusicLessonStatusDTO status = new MusicLessonStatusDTO() { Id = musicLessonStatusSelect.Id, Code = musicLessonStatusSelect.Code, Description = musicLessonStatusSelect.Description };

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
