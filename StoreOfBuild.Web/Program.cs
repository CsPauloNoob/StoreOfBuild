using StoreOfBuild.Data;
using StoreOfBuild.DI;
using StoreOfBuild.Domain;
using StoreOfBuild.Web.Filter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllersWithViews();

BootStrap.Configure(builder.Services,
    builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddMvc( config =>
{
    config.Filters.Add(typeof(CustomExceptionFilter));
});

var app = builder.Build();

app.Use(async (context, next) =>
{
    //Request
    await next.Invoke();

    var unityOfWork = (UnityOfWork)context.RequestServices.GetService(typeof(IUnityOfWork));
    await unityOfWork.Save();
});
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
