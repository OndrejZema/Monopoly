using Microsoft.EntityFrameworkCore;
using Monopoly.NewDAL;
using Monopoly.Repository.Repositories;
using Monopoly.Service.Services;

namespace Monopoly.NewAPI;

public class Program
{
    public static void Main(string[] args)
    {
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
        builder.Services.AddScoped<CardRepository>();
        builder.Services.AddScoped<CardTypeRepository>();
        builder.Services.AddScoped<FieldRepository>();
        builder.Services.AddScoped<FieldTypeRepository>();
        builder.Services.AddScoped<GameRepository>();
        builder.Services.AddScoped<BanknoteRepository>();
        builder.Services.AddScoped<CardService>();
        builder.Services.AddScoped<CardTypeService>();
        builder.Services.AddScoped<FieldService>();
        builder.Services.AddScoped<FieldTypeService>();
        builder.Services.AddScoped<GameService>();
        builder.Services.AddScoped<GamePreviewService>();
        builder.Services.AddScoped<BanknoteService>();

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