using Graphql.schema.Querys;

namespace Graphql.schema.Mutations
{
    public class Mutation
    {
        private readonly List<CourseResult> _course;
        public Mutation()
        {
            _course = new List<CourseResult>();
        }
        public CourseResult CreateCourse(CourseInputType courseInputType)
        {
            CourseResult courseType = new CourseResult() //return value
            {
                Id = Guid.NewGuid(),
                Name = courseInputType.Name,
                Subject = courseInputType.Subject,
                InstructorId = courseInputType.InstructorId
  
            };
            _course.Add(courseType);
            return courseType;
        }
        public CourseResult UpdateCourse(Guid id, CourseInputType courseInputType)
        {
            CourseResult course =_course.FirstOrDefault(c => c.Id == id);
            if(course == null)
            {
                throw new GraphQLException(new Error("Course not Found", "COURSE_NOT_FOUND"));
                //throw new Exception("Course not found");
            }
            course.Name = courseInputType.Name;
            course.Subject = courseInputType.Subject;
            course.InstructorId = courseInputType.InstructorId;
            return course;
        }
        public bool DeleteCourse(Guid id)
        {
            return _course.RemoveAll(c => c.Id == id) >= 1;
        }
    }
}
