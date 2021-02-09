using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType

            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<ClassDetails> ClassDetails { get; set; }

        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<CourseTeacher> CourseTeachers { get; set; }

        public DbSet<Groups> Groups { get; set; }

        //public DbSet<Job> Jobs { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        //public DbSet<StaffJob> StaffJobs { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<StudentFaculty> StudentFaculties { get; set; }

        public DbSet<TeacherStudent> TeacherStudents { get; set; }

        public DbSet<Timetable> Timetables { get; set; }

        public DbSet<Routine> Routines { get; set; }



        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public static ApplicationDbContext Create()
        {

            return new ApplicationDbContext();
        }
        public void Create(string sql)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public void Edit(string sql)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
                public void Delete(string sql)
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                    SqlCommand cmd = new SqlCommand(sql, con);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    finally
                    {
                        con.Close();
                    }

                }
                public DataTable List(string sql)
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                    SqlCommand cmd = new SqlCommand(sql, con);

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    try
                    {
                        con.Open();
                        da.Fill(dt);
                    }
                    finally
                    {
                        con.Close();
                    }
                    return dt;
                }
            }

        }