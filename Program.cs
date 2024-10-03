using CSHARPAPI_VinylBook.Data;
using CSHARPAPI_VinylBook.Mapping;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// dodavanje baze podataka
builder.Services.AddDbContext<VinylBookContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("VinylBookContext"));
    }
    );

// Svi se od svuda na sve moguce nacine mogu spojitina nas API
// citati https://code-maze.com/aspnetcore-webapi-best-practices/
builder.Services.AddCors(opcije =>
{
    opcije.AddPolicy("CorsPolicy",
        builder =>
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );

});

// automapper
builder.Services.AddAutoMapper(typeof(VinylBookMappingProfile));



var app = builder.Build();

// Configure the HTTP request pipeline. 
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.ConfigObject.AdditionalItems.Add("requestSnippetsEnabled", true);
        options.EnableTryItOutByDefault();
    });
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//za potrebe produkcije
app.UseStaticFiles();
app.UseDefaultFiles();
app.MapFallbackToFile("Index.html");
app.UseCors("CorsPolicy");

app.Run();
