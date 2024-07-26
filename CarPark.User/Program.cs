using Serilog;
using Serilog.Events;



Log.Logger = new LoggerConfiguration()
    //.MinimumLevel.Debug()                                   //Log Level Debug
    .MinimumLevel.Information()                               //Log Level Information
    //.MinimumLevel.Override("Microsoft",LogEventLevel.Information)
    //.Enrich.FromLogContext()
    .Enrich.WithProperty("ApplicationName", "CarPark.User") //Detail for Property
    .Enrich.WithMachineName()                               //Detail for MachineName
    .WriteTo.Console()                       //Log for Consol
    .WriteTo.File("SeriLog.txt")             //Log for File
    .WriteTo.Seq("http://localhost:5341/")   //Log for Seq  
    .CreateLogger();


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSerilog();               //Added for Serilog 
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
