using APIAA.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<VideojuegoContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("VideojuegoBBDD")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins",
                      policy  =>
                      {
                        policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                          /* policy.WithOrigins("http://example.com",
                                              "http://www.contoso.com"); */
                      });
});


var app = builder.Build();

// Configure the HTTP request pipeline.+
app.UseRouting();

app.UseAuthorization();

app.UseCors("MyAllowSpecificOrigins");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

/* app.UseRouting();
app.UseAuthorization();

app.UseCors("MyAllowSpecificOrigins");



// services.AddResponseCaching();

builder.Services.AddControllers(); */

/* 
// if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();


app.MapControllers(); */

app.Run();
