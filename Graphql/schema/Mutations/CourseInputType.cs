using Graphql.Models;
using Graphql.schema.Querys;

namespace Graphql.schema.Mutations
{
    public class CourseInputType
    {
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public Guid InstructorId { get; set; }
    }
}
