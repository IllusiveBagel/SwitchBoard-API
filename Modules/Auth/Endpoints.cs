using Carter;

namespace SwitchBoard.Modules.Auth;

public class Endpoints(Supabase.Client supabase) : CarterModule("api/v1/auth")
{
    private readonly Supabase.Client __supabase = supabase;

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("signup", async (string email, string password) =>
        {
            try {
                var session = await __supabase.Auth.SignUp(email, password);
                return Results.Ok(session);
            }
            catch {
                return Results.BadRequest();
            }
        });

        app.MapPost("signin", async (string email, string password) =>
        {
            try {
                var session = await __supabase.Auth.SignIn(email, password);
                return Results.Ok(session);
            }
            catch {
                return Results.BadRequest();
            }
        });

        app.MapPost("signout", async () =>
        {
            try {
                await __supabase.Auth.SignOut();
                return Results.SignOut();
            }
            catch {
                return Results.BadRequest();
            }
        });
    }
}