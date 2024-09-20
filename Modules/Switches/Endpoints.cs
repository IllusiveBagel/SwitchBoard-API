using Carter;

namespace SwitchBoard.Modules.Switches;

public class Endpoints : CarterModule
{
    public Endpoints() : base("api/v1/switches")
    {
        RequireRateLimiting("fixedWindow").WithCacheOutput("CacheOutput");
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("", () => "List Switches");
    }
}