using Carter;
using SwitchBoard.Models;

namespace SwitchBoard.Modules.Switches;

public class Endpoints(Supabase.Client supabase) : CarterModule("api/v1/switches")
{
    private readonly Supabase.Client __supabase = supabase;

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("", async () => {
            var result = await __supabase.From<Switch>().Get();

            // TODO: Find a better way to do this
            List<SwitchesResponse> switchesResponse = result.Models.ConvertAll(x => new SwitchesResponse
            {
                ID = x.ID,
                Name = x.Name,
                // Change these to be a One-to-One reference
                SwitchDesign = x.SwitchDesign.ConvertAll(y => new SwitchDesignResponse
                {
                    ID = y.ID,
                    SwitchID = y.SwitchID,
                    StemColor = y.StemColor,
                    StemType = y.StemType,
                    StemConstruction = y.StemConstruction,
                    HousingTopType = y.HousingTopType,
                    HousingTopColor = y.HousingTopColor,
                    HousingBottomType = y.HousingBottomType,
                    HousingBottomColor = y.HousingBottomColor,
                    Mount = y.Mount

                }).ToList(),
                SwitchConstruction = x.SwitchConstruction.ConvertAll(z => new SwitchConstructionResponse
                {
                    ID = z.ID,
                    SwitchID = z.SwitchID,
                    Stem = z.Stem,
                    HousingTop = z.HousingTop,
                    HousingBottom = z.HousingBottom
                }).ToList(),
                Actuation = x.Actuation,
                BottomOut = x.BottomOut,
                PreTravel = x.PreTravel,
                TotalTravel = x.TotalTravel,
                Spring = x.Spring,
                Volume = x.Volume,
                Type = x.Type,
                FactoryLubed = x.FactoryLubed,
                Authenticated = x.Authenticated
            }).ToList();

            return Results.Ok(switchesResponse);
        }).RequireAuthorization();
    }
}