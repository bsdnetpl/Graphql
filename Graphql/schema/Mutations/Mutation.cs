using Graphql.schema.Querys;
using Graphql.schema.Subscription;
using Graphql.Services;
using Graphql.Services.Courses;
using HotChocolate.Subscriptions;

namespace Graphql.schema.Mutations
{
    public class Mutation
    {
        private readonly CoursesRepository _coursesRepository;
        //------------------------------------------------------------------------------------------------------------------------------------------------

        public Mutation(CoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
        public async Task<CourseResult> CreateCourse(CourseInputType courseInputType, [Service] ITopicEventSender topicEventSender)
        {
            CourseDTO courseDTO = new CourseDTO()
            {
                Name = courseInputType.Name,
                Subject = courseInputType.Subject,
                InstructorId = courseInputType.InstructorId,
            };

           courseDTO = await _coursesRepository.Create(courseDTO);

            CourseResult course = new CourseResult() //return value
            {
                Id = courseDTO.id,
                Name = courseDTO.Name,
                Subject = courseDTO.Subject,
                InstructorId = courseDTO.InstructorId
  
            };
            
           await topicEventSender.SendAsync(nameof(Subscription.Subscription.CourseCreated),course);//subscription
            return course;
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
        public async Task<CourseResult> UpdateCourse(Guid id, CourseInputType courseInputType, [Service] ITopicEventSender topicEventSender)
        {
            //CourseResult course =_course.FirstOrDefault(c => c.Id == id);
            //if(course == null)
            //{
            //    throw new GraphQLException(new Error("Course not Found", "COURSE_NOT_FOUND"));
            //    //throw new Exception("Course not found");
            //}
            CourseDTO courseDTO = new CourseDTO()
            {
                id = id,
                Name = courseInputType.Name,
                Subject = courseInputType.Subject,
                InstructorId = courseInputType.InstructorId,
            };

           courseDTO = await _coursesRepository.Update(courseDTO);


            CourseResult course = new CourseResult() //return value
            {
                Id = courseDTO.id,
                Name = courseDTO.Name,
                Subject = courseDTO.Subject,
                InstructorId = courseDTO.InstructorId

            };

            string updateCourseTopic = $"{course.Id} {nameof(Subscription.Subscription.CourseUpdate)}";//subscription
            await topicEventSender.SendAsync(updateCourseTopic, course);
            return course;
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
        public async Task<bool> DeleteCourse(Guid id)
        {
            return await _coursesRepository.Delete(id);
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
