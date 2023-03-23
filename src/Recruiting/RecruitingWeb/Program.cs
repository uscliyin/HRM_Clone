using Infrastructure.Services;
using ApplicationCore.Contracts.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories;
using ApplicationCore.Contracts.Repositories;
using RecruitingWeb.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IJobService,JobService>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<ISubmissionsRepository,SubmissonsRepository>();
builder.Services.AddScoped<ISubmissionsService, SubmissionsService>();
builder.Services.AddDbContext<RecruitingDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("RecruitingDbConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRecruitingMiddleware();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
