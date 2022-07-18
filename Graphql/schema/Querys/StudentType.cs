namespace Graphql.schema.Querys
{
    public class StudentType
    {
        public Guid id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [GraphQLName("gpa")]
        public double GPA { get; set; }

    }
}
