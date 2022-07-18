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
        public CourseResult CreateCourse(string name, Subject subject, Guid instructorid)
        {
            CourseResult courseType = new CourseResult() //return value
            {
                Id = Guid.NewGuid(),
                Name = name,
                Subject = subject,
                InstructorId = instructorid
  
            };
            _course.Add(courseType);
            return courseType;
        }
        public CourseResult UpdateCourse(Guid id,string name, Subject subject, Guid instructorid)
        {
            CourseResult course =_course.FirstOrDefault(c => c.Id == id);
            if(course == null)
            {
                throw new Exception("Course nor found");
            }
            course.Name = name;
            course.Subject = subject;
            course.InstructorId = instructorid;
            return course;
        }
    }
}
