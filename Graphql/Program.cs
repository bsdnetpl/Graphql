using Graphql.schema.Mutations;
using Graphql.schema.Querys;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();


app.MapGraphQL();
app.Run();
