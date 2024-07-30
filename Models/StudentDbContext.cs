using Microsoft.EntityFrameworkCore;

namespace CRUD_DocPro_DMS.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Students_Info { get; set; }
    }
}
