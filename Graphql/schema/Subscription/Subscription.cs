using Graphql.schema.Mutations;
using Graphql.schema.Querys;
using HotChocolate.Execution;
using HotChocolate.Language;
using HotChocolate.Subscriptions;

namespace Graphql.schema.Subscription
{
    public class Subscription
    {
        [Subscribe]
        public CourseResult CourseCreated([EventMessage]CourseResult course) => course;
        [SubscribeAndResolve]
        public ValueTask<ISourceStream<CourseResult>> CourseUpdate(Guid courseId, [Service] ITopicEventReceiver topicEventReceiver)
        {
            string topicName = $"{courseId} {nameof(Subscription.CourseUpdate)}";
            return topicEventReceiver.SubscribeAsync<string, CourseResult>(topicName);
        }
    }
}
