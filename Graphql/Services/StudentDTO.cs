namespace Graphql.Services
{
    public class StudentDTO
    {
        public Guid id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double GPA { get; set; }
        public IEnumerable<CourseDTO> Course { get; set; }
    }
}
