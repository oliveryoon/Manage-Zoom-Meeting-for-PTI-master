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
        public UspSickBayInOutUpdate SickBaySimple { get; set; }

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

            modelBuilder.Entity<SickBay>().ToTable("vMedicalIncidents", "dbo"); //8213
            modelBuilder.Entity<SickBay>().Property(s => s.IncidentDate).HasColumnName("IncidentDate");
            modelBuilder.Entity<SickBay>().Property(s => s.TimeIn).HasColumnName("CheckIn");
            modelBuilder.Entity<SickBay>().Property(s => s.TimeOut).HasColumnName("CheckOut");
            modelBuilder.Entity<SickBay>().Property(s => s.DateModified).HasColumnName("ModifiedDate");
            modelBuilder.Entity<SickBay>().Property(s => s.UsernameModified).HasColumnName("ModifiedBy");

            modelBuilder.Query<UspSickBayInOutUpdate>();
        }
        #region Get products whose price is greater than equal to 1000 store procedure method.  

        /// <summary>  
        /// Get products whose price is greater than equal to 1000 store procedure method.  
        /// </summary>  
        /// <returns>Returns - List of products whose price is greater than equal to 1000</returns>  
        public async void PostSickBayInOutUpdate(SickBaySimple sickBay)
        {
            // Initialization.              

            try
            {
                // Set params.
                SqlParameter iDParam = new SqlParameter("@ID", sickBay.Id);
                SqlParameter incidentDateParam = new SqlParameter("@IncidentDate", sickBay.IncidentDate);
                SqlParameter timeParam = new SqlParameter("@Time", sickBay.Time);
                SqlParameter usernameParam = new SqlParameter("@Username", sickBay.UsernameModified);

                // Processing.  
                string sqlQuery = "EXEC [dbo].[GetProductByPriceGreaterThan1000] @ID, @IncidentDate, @Time, @Username";

                await this.Query<UspSickBayInOutUpdate>().FromSql(sqlQuery, iDParam, incidentDateParam, timeParam, usernameParam).ToListAsync();
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
