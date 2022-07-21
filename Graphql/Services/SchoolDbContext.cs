
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Graphql.Services
{
    public class SchoolDbContext: DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext>options)
            : base(options) { }
        public DbSet<CourseDTO> Courses { get; set; }
        public DbSet<StudentDTO> Students { get; set; }
        public DbSet<InstructorDTO> Instructors { get; set; }
    }
}
