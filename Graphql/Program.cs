using Graphql.schema.Mutations;
using Graphql.schema.Querys;
using Graphql.schema.Subscription;
using Graphql.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

//private readonly IConfiguration _configuration;
//public Program(IConfiguration configuration)
//{
//    _configuration = configurationl
//}

IHost host = builder.Build();
using (IServiceScope scope = host.Services.CreateScope())
{
    IDbContextFactory<SchoolDbContext> contextFactory = 
        scope.ServiceProvider.GetRequiredService<IDbContextFactory<SchoolDbContext>>();
    using(SchoolDbContext context = contextFactory.CreateDbContext())
    {
        context.Database.Migrate();
    }
}

    host.Start();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>();
   // .RegisterDbContext<SchoolDbContext>(DbContextKind.Pooled);

builder.Services.AddInMemorySubscriptions();
string connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddPooledDbContextFactory<SchoolDbContext>(o => o.UseSqlite(connectionString));

var app = builder.Build();
app.UseRouting();
app.UseWebSockets();  //subscription
app.MapGraphQL();
app.Run();
