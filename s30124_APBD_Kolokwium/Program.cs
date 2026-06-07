using Microsoft.EntityFrameworkCore;
using s30124_APBD_Kolokwium.Models;
using s30124_APBD_Kolokwium.Services;


var builder = WebApplication.CreateBuilder(args); 

builder.Services.AddControllers(); 

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); 

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(connectionString)); 
builder.Services.AddScoped<IKolokwiumService,KolokwiumService>();

var app = builder.Build(); 

app.UseHttpsRedirection();
app.UseAuthorization(); 
app.MapControllers(); 

app.Run();