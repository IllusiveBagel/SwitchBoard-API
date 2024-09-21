using Carter;
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
            })
            .AddSingleton<Supabase.Client>(
                provider => new Supabase.Client(url, key, options));

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
                });
        }

        app.MapCarter();

        app.UseHttpsRedirection();
    }
}