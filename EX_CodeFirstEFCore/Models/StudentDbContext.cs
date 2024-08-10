using Microsoft.EntityFrameworkCore;

namespace EX_CodeFirstEFCore.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options): base(options) 
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
