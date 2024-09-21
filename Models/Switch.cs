using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SwitchBoard.Models;

[Table("Switches")]
public class Switch : BaseModel
{
    [PrimaryKey("id", false)]
    public string? ID { get; set; }
    [Column("name")]
    public string? Name { get; set; }
    [Reference(typeof(SwitchDesign))]
    public List<SwitchDesign> SwitchDesign { get; set; } = new();
    [Reference(typeof(SwitchConstruction))]
    public List<SwitchConstruction> SwitchConstruction { get; set; } = new();
    [Column("actuation")]
    public int Actuation { get; set; }
    [Column("bottomOut")]
    public int BottomOut { get; set; }
    [Column("preTravel")]
    public int PreTravel { get; set; }
    [Column("totalTravel")]
    public int TotalTravel { get; set; }
    [Column("spring")]
    public string? Spring { get; set; }
    [Column("volume")]
    public string? Volume { get; set; }
    [Column("type")]
    public string? Type { get; set; }
    [Column("factoryLubed")]
    public bool FactoryLubed { get; set; }
    [Column("authenticated")]
    public bool Authenticated { get; set; }

}

public class SwitchesResponse {
    public string? ID { get; set; }
    public string? Name { get; set; }
    public List<SwitchDesignResponse>? SwitchDesign { get; set; }
    public List<SwitchConstructionResponse>? SwitchConstruction { get; set; }
    public int Actuation { get; set; }
    public int BottomOut { get; set; }
    public int PreTravel { get; set; }
    public int TotalTravel { get; set; }
    public string? Spring { get; set; }
    public string? Volume { get; set; }
    public string? Type { get; set; }
    public bool FactoryLubed { get; set; }
    public bool Authenticated { get; set; }
}