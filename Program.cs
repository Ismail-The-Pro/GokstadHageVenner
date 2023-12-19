using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GokstadHageVenner.Mapper;
using GokstadHageVenner.Mapper.Interface;
using GokstadHageVenner.Models.DTO;
using GokstadHageVenner.Models.Entity;
using GokstadHageVenner.Repository;
using GokstadHageVenner.Repository.Repository_Interface;
using GokstadHageVenner.Services;
using GokstadHageVenner.Services.Interface;
using Swashbuckle.AspNetCore.SwaggerGen; // Legg til denne importen
using Microsoft.AspNetCore.Mvc.ApiExplorer; // Legg til denne importen
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore; // Legg til denne importen
using Pomelo

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMedlemService, MedlemService>();
builder.Services.AddScoped<IArrangementService, ArrangementService>();
builder.Services.AddScoped<IKjopOgSalgService, KjopOgSalgService>();
builder.Services.AddScoped<IPåmeldingService, PåmeldingService>();

builder.Services.AddScoped<IMapper<Arrangement, ArrangementDTO>, ArrangementMapper>();
builder.Services.AddScoped<IMapper<Påmelding, PåmeldingDTO>, PåmeldingMapper>();
builder.Services.AddScoped<IMapper<Medlem, MedlemDto>, MedlemMapper>();
builder.Services.AddScoped<IMapper<KjopOgSalg, KjopOgSalgDTO>, KjopOgSalgMapper>();

// Add other services and mappers as needed

builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddFluentValidationAutoValidation(config => config.DisableDataAnnotationsValidation = false);

builder.Services.AddScoped<IMedlemRepository, MedlemRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add other repositories as needed

// Register the Swagger generator
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GokstadHageVenner", Version = "v1" });

    // Optionally, include the XML comments from your project
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// Configure the HTTP request pipeline.
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseMiddleware<StudentBlogBasicAuthentication>();
app.UseRouting();

app.MapControllers();

app.Run();
