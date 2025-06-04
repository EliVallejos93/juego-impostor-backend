using FluentValidation;
using juego_impostor_backend.API.AlertMessage;
using juego_impostor_backend.API.Middlewares;
using juego_impostor_backend.Features.Categorias.Application.Interfaces;
using juego_impostor_backend.Features.Categorias.Application.UseCases;
using juego_impostor_backend.Features.Categorias.Infrastructure;
using juego_impostor_backend.Features.IniciarPartida.Application.Interfaces;
using juego_impostor_backend.Features.IniciarPartida.Application.Services;
using juego_impostor_backend.Features.IniciarPartida.Application.UseCases;
using juego_impostor_backend.Features.IniciarPartida.Infrastructure;
using juego_impostor_backend.Shared.Behaviors;
using juego_impostor_backend.Shared.Persistence;
using juego_impostor_backend.Features.Categorias.Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { c.EnableAnnotations(); }); // Habilitar anotaciones para la documentaci�n

// Configuracion ConnectionStrings, DbContext, UnitOfWork y Repositories
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoriasRepository, CategoriasRepository>();
builder.Services.AddScoped<ISubCategoriasRepository, SubCategoriasRepository>();
builder.Services.AddScoped<IPalabraSecretaRepository, PalabraSecretaRepository>();

// Servicios compartidos
builder.Services.AddScoped<IAlertMessageHandler, AlertMessageHandler>();

// Servicios de logica de Features
builder.Services.AddScoped<IGetCategoriasService, GetCategoriasService>();
builder.Services.AddScoped<IConfiguracionService, ConfiguracionService>();

// Configuracion de MediatR de comandos y handlers
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetCategoriasQuery).Assembly).RegisterServicesFromAssembly(typeof(GetCategoriasQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(IniciarPartidaCommand).Assembly).RegisterServicesFromAssembly(typeof(IniciarPartidaCommandHandler).Assembly));
// Configuracion de FluentValidation
//builder.Services.AddValidatorsFromAssemblyContaining<GetCategoriasCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<IniciarPartidaCommandValidator>();
// Configuracion de Behaviors de MediatR
// middleware de MediatR que valida los comandos de request
builder.Services.AddHttpContextAccessor(); // necesario para IHttpContextAccessor
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
// middleware de MediatR que valida las transacciones en Db
//builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));


var app = builder.Build();

app.UseCors(builder =>
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

// Registro del Middleware de Errores
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
