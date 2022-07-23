using Microsoft.EntityFrameworkCore;

namespace Graphql.Services.Courses
{
    public class CoursesRepository
    {
        private readonly IDbContextFactory<SchoolDbContext> _contextFactory;

        public CoursesRepository(IDbContextFactory<SchoolDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<CourseDTO> Create(CourseDTO course)
        {
            using (SchoolDbContext contex = _contextFactory.CreateDbContext())
            {
                contex.Courses.Add(course);
                await contex.SaveChangesAsync();
                return course;
            }
        }
        public async Task<CourseDTO> Update(CourseDTO course)
        {
            using (SchoolDbContext contex = _contextFactory.CreateDbContext())
            {
                contex.Courses.Update(course);
                await contex.SaveChangesAsync();
                return course;
            }
        }
        public async Task<bool> Delete(Guid id)
        {
            using (SchoolDbContext contex = _contextFactory.CreateDbContext())
            {
                CourseDTO course = new CourseDTO()
                {
                    id = id
                };
                contex.Courses.Remove(course);
                return await contex.SaveChangesAsync() > 0;
                
            }
        }
    }
}
