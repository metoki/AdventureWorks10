using System.ComponentModel;
using AdventureWorks.Context;
using AdventureWorks.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddRazorPages();

IConfiguration configuration = builder.Configuration;
string? con = configuration.GetConnectionString("AdventureWorksCosmosContext");
var settings = configuration.GetSection("Settings");
builder.Services.Configure<Settings>(settings);

// string? conString = Environment.GetEnvironmentVariable("ConnectionStrings:AdventureWorksCosmosContext");
// string? blobContainerUrl = Environment.GetEnvironmentVariable("Settings:BlobContainerUrl");
// string? blobToken = Environment.GetEnvironmentVariable("Settings:BlobSASToken");

//Console.WriteLine($"Connection:{con}");

// Console.WriteLine($"Connection:{settings["BlobContainerUrl"]}");
// Console.WriteLine($"Url:{blobContainerUrl}");
// Console.WriteLine($"Token:{blobToken}");



builder.Services.AddScoped<Settings>(setting => new Settings(settings["BlobContainerUrl"],settings["BlobSASToken"]));
builder.Services.AddScoped<IAdventureWorksProductContext, AdventureWorksCosmosContext>(
    provider =>
    new AdventureWorksCosmosContext(con??"")
    );

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
