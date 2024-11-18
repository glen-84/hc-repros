using Application.Modules.Core.Database;
using Application.Modules.Users.Services;
using Microsoft.EntityFrameworkCore;
using Application.Modules.Users.Types;

var builder = WebApplication.CreateBuilder(args);

// Entity Framework.
var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services
    .AddPooledDbContextFactory<ApplicationDbContext>(
        options => options
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            .EnableDetailedErrors(builder.Environment.IsDevelopment())
            .EnableSensitiveDataLogging(builder.Environment.IsDevelopment())
            .UseSnakeCaseNamingConvention());

// Hot Chocolate.
builder.Services
    .AddGraphQLServer()
    .InitializeOnStartup()
    .ModifyRequestOptions(
        options => options.IncludeExceptionDetails = builder.Environment.IsDevelopment())
    .AddGlobalObjectIdentification()
    // Set default type for the User entity.
    .AddType<UserType>()
    .AddApplicationTypes()
    .AddQueryType()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

builder.Services.AddTransient<UserService>();

var app = builder.Build();

app.MapGraphQL();

await app.RunAsync();
