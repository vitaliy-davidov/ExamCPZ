using AutoMapper;
using ExamCPZ.BLL;
using ExamCPZ.BLL.Interfaces;
using ExamCPZ.BLL.Models;
using ExamCPZ.BLL.Services;
using ExamCPZ.DAL;
using ExamCPZ.DAL.Entities;
using ExamCPZ.DAL.Interfaces;
using ExamCPZ.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(
//        policy =>
//        {
//            policy.AllowAnyHeader()
//                  .AllowAnyOrigin()
//                  .AllowAnyMethod();
//        });
//});

// Add services to the container.

builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<ExamCPZDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperSettings());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddScoped<ICRUDRepository<Patient>, PatientRepository>();
builder.Services.AddScoped<ICRUDRepository<Appointment>, AppointmentRepository>();

builder.Services.AddScoped<ICRUDService<PatientModel>, PatientService>();
builder.Services.AddScoped<ICRUDService<AppointmentModel>, AppointmentService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
