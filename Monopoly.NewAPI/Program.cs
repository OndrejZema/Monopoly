using Microsoft.EntityFrameworkCore;
using Monopoly.NewAPI.Middlewares;
using Monopoly.NewDAL;
using Monopoly.Repository.Repositories;
using Monopoly.Repository.Repositories.Interfaces;
using Monopoly.Service.Services;
using Monopoly.Service.Services.Interfaces;

namespace Monopoly.NewAPI;

public class Program
{
    public static void Main(string[] args)
    {
        DotNetEnv.Env.Load();
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigins",
                builder =>
                {
                    builder.WithOrigins("*")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });
        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddControllers();
        builder.Services.AddScoped<ICardRepository, CardRepository>();
        builder.Services.AddScoped<ICardTypeRepository, CardTypeRepository>();
        builder.Services.AddScoped<IFieldRepository, FieldRepository>();
        builder.Services.AddScoped<IFieldTypeRepository, FieldTypeRepository>();
        builder.Services.AddScoped<IGameRepository, GameRepository>();
        builder.Services.AddScoped<IBanknoteRepository, BanknoteRepository>();
        builder.Services.AddScoped<ICardService, CardService>();
        builder.Services.AddScoped<ICardTypeService, CardTypeService>();
        builder.Services.AddScoped<IFieldService, FieldService>();
        builder.Services.AddScoped<IFieldTypeService, FieldTypeService>();
        builder.Services.AddScoped<IGameService, GameService>();
        builder.Services.AddScoped<IGamePreviewService, GamePreviewService>();
        builder.Services.AddScoped<IBanknoteService, BanknoteService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IAuthRepository, AuthRepository>();

        builder.Services.AddControllers();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors("AllowSpecificOrigins"); 

        app.UseAuthorization();
        
        app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
        {
            //appBuilder.UseMiddleware<AuthMiddleware>();
            
        });

        app.MapControllers();

        app.Run();
    }
}