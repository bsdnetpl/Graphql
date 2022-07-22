using Graphql.schema.Mutations;
using Graphql.schema.Querys;
using Graphql.schema.Subscription;
using Graphql.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);


string connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddPooledDbContextFactory<SchoolDbContext>(o => o.UseSqlite(connectionString));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>();
    //.RegisterDbContext<SchoolDbContext>(DbContextKind.Pooled);

builder.Services.AddInMemorySubscriptions();

var app = builder.Build();

using var scope = app.Services.CreateScope();
using var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<SchoolDbContext>>().CreateDbContext();
contextFactory.Database.Migrate();
    
app.UseRouting();
app.UseWebSockets();  //subscription
app.MapGraphQL();
app.Run();
