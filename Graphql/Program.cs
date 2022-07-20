using Graphql.schema.Mutations;
using Graphql.schema.Querys;
using Graphql.schema.Subscription;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>();

builder.Services.AddInMemorySubscriptions();

var app = builder.Build();
app.UseRouting();
app.UseWebSockets();
app.MapGraphQL();
app.Run();
