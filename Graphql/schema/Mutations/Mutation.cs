using Graphql.schema.Querys;
using Graphql.schema.Subscription;
using HotChocolate.Subscriptions;

namespace Graphql.schema.Mutations
{
    public class Mutation
    {
        private readonly List<CourseResult> _course;
        public Mutation()
        {
            _course = new List<CourseResult>();
        }
        public async Task<CourseResult> CreateCourse(CourseInputType courseInputType, [Service] ITopicEventSender topicEventSender)
        {
            CourseResult course = new CourseResult() //return value
            {
                Id = Guid.NewGuid(),
                Name = courseInputType.Name,
                Subject = courseInputType.Subject,
                InstructorId = courseInputType.InstructorId
  
            };
            _course.Add(course);
            topicEventSender.SendAsync(nameof(Subscription.Subscription.CourseCreated),course);
            return course;
        }
        //----------------------------------------------------------------------------
        public async Task<CourseResult> UpdateCourse(Guid id, CourseInputType courseInputType, [Service] ITopicEventSender topicEventSender)
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

            string updateCourseTopic = $"{course.Id} {nameof(Subscription.Subscription.CourseUpdate)}";
            await topicEventSender.SendAsync(updateCourseTopic, course);
            return course;
        }
        public bool DeleteCourse(Guid id)
        {
            return _course.RemoveAll(c => c.Id == id) >= 1;
        }
    }
}
