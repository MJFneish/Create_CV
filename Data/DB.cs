using cv_web_application.Models;
using Microsoft.EntityFrameworkCore;

namespace cv_web_application.Data
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options) { }
        public DbSet<CVModelDB> CVs { get; set; }
    }
}

