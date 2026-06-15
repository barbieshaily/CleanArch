using CleanArch.Infra.Data.Context;
using CleanArch.Infra.IoC;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<UniversityDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("UniversityDBConnection") ?? throw new InvalidOperationException("Connection string 'UniversityDBConnection' not found.")));
builder.Services.AddControllersWithViews();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "University Api", Version = "v1" });  
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Program)));


// call your DI registrar // option A: call your container directly
DependencyContainer.RegisterServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{ 
 c.SwaggerEndpoint("/swagger/v1/swagger.json", "University Api v1");
});
app.MapControllers();

app.Run();
