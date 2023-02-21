using Microsoft.EntityFrameworkCore;
using StudioGhibliMovieMaker.BusinessObjects.Contexts;
using StudioGhibliMovieMaker.BusinessObjects.Models.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

string? connectionString = builder.Configuration.GetConnectionString("MariaDBConnectionString");
builder.Services.AddDbContextPool<StudentContext>(options => options
    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddDbContextPool<CourseContext>(options => options
    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
