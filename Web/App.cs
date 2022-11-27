using Database;
using Logic.Services;
using Web.Extensions;

var builder = WebApplication.CreateBuilder(args).UseSerilog();

string CorsPolicyName = builder.Configuration.GetCorsPolicyName();

// IMvcBuilder configuration
builder.Services
    .AddControllers()
    .ConfigureJsonSerializer();

// IServiceCollection configuration
builder.Services
    .ConfigureCorsToAllow(CorsPolicyName)
    .ConfigureSqlDatabase<ApplicationDbContext>(builder.Configuration)
    .AddAutoMapper()
    .AddScoped<IEmployeeService, EmployeeService>()
    .AddScoped<IDepartmentService, DepartmentService>()
    .AddScoped<IDocumentService, DocumentService>()
    .AddScoped<IEducationService, EducationService>()
#if !RELEASE
    .AddEndpointsApiExplorer()
    .ConfigureSwagger(builder.Configuration)
#endif
    .AddResponseCompression()
    .AddRepositoryWrapper();

var app = builder.Build();

#if !RELEASE
if (app.Environment.IsDevelopment())
{
    app.UseSwagger()
        .UseSwaggerUI();
}
#endif

app
    .UseCors(CorsPolicyName)
    .UseAuthorization()
    //.UseHttpsRedirection()
    .UseResponseCompression();

app.MapControllers();

app.Run();