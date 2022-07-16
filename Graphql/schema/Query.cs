using Bogus;

namespace Graphql.schema
{
    public class Query
    {
        private readonly Faker<InstructorType> _InstructorFaker;
        private readonly Faker<StudentType> _StudentFaker;
        private readonly Faker<CourseType> _courseFaker;

        public Query()
        {
            _InstructorFaker = new Faker<InstructorType>()
                .RuleFor(c => c.id, f => Guid.NewGuid())
                .RuleFor(c => c.FirstName, f => f.Name.FindName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.Salary, f => f.Random.Double(0, 100000));

            _StudentFaker = new Faker<StudentType>()
                .RuleFor(c => c.id, f => Guid.NewGuid())
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.GPA, f => f.Random.Double(1, 4));

            _courseFaker = new Faker<CourseType>()
                .RuleFor(c => c.id, f => Guid.NewGuid())
                .RuleFor(c => c.Name, f => f.Name.JobTitle())
                .RuleFor(c => c.Subject, f => f.PickRandom<Subject>())
                .RuleFor(c => c.Instructor, f => _InstructorFaker.Generate())
                .RuleFor(c => c.Students, f => _StudentFaker.Generate(3));
        }
        public IEnumerable<CourseType> GetCourses()
        {
            return _courseFaker.Generate(5);
        }

        public async Task<CourseType> GetCourseByIdAsync(Guid Id)
        {
            await Task.Delay(1000);
            CourseType course = _courseFaker.Generate();
            course.id = Id;
            return course;
        }
        //public string info => "Hello world !";
    }
}
