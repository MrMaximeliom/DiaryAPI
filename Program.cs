using DiaryAPI.Controllers;
using DiaryAPI.Data;
using Microsoft.OpenApi.Models;
using System.Reflection;

DBContext db_context = new();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c => 
    {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        { 
            Title = "Diary API",
            Version = "v1",
            Description = "A sample ASP.NET Core Web API that allows you to create your own diary.",
            Contact = new OpenApiContact
            {
                Name = "Moayed Abdulhafiez",
                Email="hysoca7@gmail.com",
                Url= new Uri("https://github.com/mrmaximeliom"),
            },
            License = new OpenApiLicense
            {
                Name = "MIT License",
                Url  = new Uri("https://opensource.org/licenses/MIT"),
            },
            
        });
        // generate the xml docs that'll  drive the swagger docs
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);  



    }

    ).AddSwaggerGenNewtonsoftSupport();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();   

app.UseAuthorization();

app.MapControllers();

app.Run();
