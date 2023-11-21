using BeautySalon.Application.Repositories;
using BeautySalon.Infrastructure.Database;
using BeautySalon.Infrastructure.Repositories;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddScoped<IMapper, Mapper>();
builder.Services.AddDbContext<BeautySalonContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BeautySalonContext")));

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
