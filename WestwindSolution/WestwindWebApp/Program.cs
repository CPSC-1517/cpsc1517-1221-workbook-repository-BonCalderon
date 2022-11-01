#region namespaces required to setup database services 
using Microsoft.EntityFrameworkCore;
using WestWindSystem; // need this namespace to recognize the addbackdependencies method and to activate it
#endregion

var builder = WebApplication.CreateBuilder(args); // pre generated code when you create razor page project (web application)

#region code required to setup database servives
var dbConnectionString = builder.Configuration.GetConnectionString("TrainWatchLocalDB");// thsi sets the dbConnectionString to what ever connection string you put in getconnectionstring
builder.Services.AddBackendDependencies(option => option.UseSqlServer(dbConnectionString));

/*
 * If the BLL classes were declared as public instead of internal you can do this instead
builder.Services.AddDbContext<WestwindContext>(options =>
{
    // Verify that the NuGet package Microsoft.EntityFrameworkCore.SqlServer has been installed
    options.UseSqlServer(dbConnectionString);
});
// The AddTransient<T>() method adds a transient service of the type T to resolve each dependency on type T
builder.Services.AddTransient<BuildVersionServices>(serviceProvider =>
{
    var context = serviceProvider.GetRequiredService<WestwindContext>();
    return new BuildVersionServices(context);
});
builder.Services.AddTransient<CategoryServices>(serviceProvider =>
{
    var context = serviceProvider.GetRequiredService<WestwindContext>();
    return new CategoryServices(context);
});
*/

#endregion

// Add services to the container.
builder.Services.AddRazorPages();

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
