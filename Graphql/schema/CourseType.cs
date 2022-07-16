namespace Graphql.schema
{
    public enum Subject
    {
        Matematyka,
        Angielski,
        Historia
    }
    public class CourseType
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }

        [GraphQLNonNullType]
        public InstructorType Instructor { get; set; }
        public IEnumerable<StudentType> Students { get; set; }

    }
}
