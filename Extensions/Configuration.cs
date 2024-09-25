using System.Text;
using Carter;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace SwitchBoard.Extensions;

public static class Configuration
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        var supabaseConfig = builder.Configuration.GetSection("supabase");
        string url = supabaseConfig.GetValue<string>("URL") ?? "";
        string key = supabaseConfig.GetValue<string>("Key") ?? "";

        var options = new Supabase.SupabaseOptions
        {
            AutoConnectRealtime = true
        };

        builder.Services
            .AddEndpointsApiExplorer()
            .AddCarter()
            .AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SwitchBoard API", Description = "Collection of Mechanical Keyboard Switches", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
            })
            .AddAuthorization()
            .AddSingleton<Supabase.Client>(
                provider => new Supabase.Client(url, key, options))
            .AddCors();


        var bytes = Encoding.UTF8.GetBytes(builder.Configuration["Authentication:JwtSecret"]!);
        var validAudience = builder.Configuration["Authentication:ValidAudience"];
        var validIssuer = builder.Configuration["Authentication:ValidIssuer"];

        builder.Services
            .AddAuthentication()
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(bytes),
                    ValidateIssuerSigningKey = true,
                    ValidAudience = validAudience,
                    ValidIssuer = validIssuer
                };
            });

        builder.Configuration
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json",
                optional: true, reloadOnChange: true);
    }

    public static void RegisterMiddlewares(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SwitchBoard API V1");
                })
                .UseAuthentication()
                .UseAuthorization()
                .UseCors(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                );
        }

        app.MapCarter();

        app.UseHttpsRedirection();
    }
}