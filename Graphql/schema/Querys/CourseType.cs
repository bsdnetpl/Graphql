using Graphql.Models;

namespace Graphql.schema.Querys
{

    public class CourseType
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }

        [GraphQLNonNullType]
        public InstructorType Instructor { get; set; }
        public IEnumerable<StudentType> Students { get; set; }
        public string Description()
        {
            return $"{Name} This is a course.";
        }

    }
}
