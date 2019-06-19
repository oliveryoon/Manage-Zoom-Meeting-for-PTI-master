using Microsoft.EntityFrameworkCore;
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
        /// <summary>  
        /// Gets or sets to product detail by product Id property.  
        /// </summary>  
        [Display(Name = "SickBay Simple")]
        public UspSickBayInOutUpdate SickBayUpdate { get; set; }

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
            modelBuilder.Entity<Student>().Property(s => s.Photo).HasColumnName("Photo");

            modelBuilder.Entity<SickBay>().ToTable("uvMedicalIncidents", "webapi"); //8213
            modelBuilder.Entity<SickBay>().Property(s => s.Seq).HasColumnName("Seq");
            modelBuilder.Entity<SickBay>().Property(s => s.Id).HasColumnName("ID");
            modelBuilder.Entity<SickBay>().Property(s => s.IncidentDate).HasColumnName("IncidentDate");
            modelBuilder.Entity<SickBay>().Property(s => s.TimeIn).HasColumnName("TimeIn");
            modelBuilder.Entity<SickBay>().Property(s => s.TimeOut).HasColumnName("TimeOut");
            modelBuilder.Entity<SickBay>().Property(s => s.DateModified).HasColumnName("DateModified");
            modelBuilder.Entity<SickBay>().Property(s => s.UsernameModified).HasColumnName("UsernameModified");

            modelBuilder.Query<UspSickBayInOutUpdate>();
        }
        #region Create Sign In and Sign Out.  

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

                // Processing.  
                string sqlQuery = "EXEC webapi.uspSickBayInOutUpdate @ID, @IncidentDate, @Time, @Username, @VenueCode";

                //Task<int> x = this.Database.ExecuteSqlCommandAsync(sqlQuery, iDParam, incidentDateParam, timeParam, usernameParam, venueCodeParam);
                //await this.Query<UspSickBayInOutUpdate>().FromSql(sqlQuery, iDParam, incidentDateParam, timeParam, usernameParam, venueCodeParam).ToListAsync();
                var sickbayInOut = this.Query<UspSickBayInOutUpdate>().FromSql(sqlQuery, iDParam, incidentDateParam, timeParam, usernameParam, venueCodeParam).FirstOrDefault();
                sickBaySimple.Seq = sickbayInOut.Seq;
                return sickBaySimple;


            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }

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
