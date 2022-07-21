namespace Graphql.Services
{
    public class InstructorDTO
    {
        public Guid id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }
        public IEnumerable<CourseDTO> Course { get; set; }
    }
}
