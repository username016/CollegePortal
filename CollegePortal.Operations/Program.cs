using CollegePortal.Services.DataAccessLayer;
using CollegePortal.Services.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorOptions(options =>
    {
        // Add custom view location for Pages/Students folder
        options.ViewLocationFormats.Add("/Views/Pages/Students/{0}.cshtml");
    });

// DbContext connection string and build
builder.Services.AddDbContext<DbContextStudent>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Register repositories
builder.Services.AddScoped<IGymRepository, GymRepository>();
builder.Services.AddScoped<ILFRepository, LFRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudyRoomRepository, StudyRoomRepository>();
builder.Services.AddScoped<ITutorRepository, TutorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Set the default controller/action to Student/Login
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Login}/{id?}"); // Default is now Student/Login

app.Run();
