using Microsoft.AspNetCore.SignalR;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SwitchBoard.Models;

[Table("SwitchConstruction")]
public class SwitchConstruction : BaseModel
{
    [PrimaryKey("id", false)]
    public string? ID { get; set; }
    [Column("switchId")]
    public string? SwitchID { get; set; }
    [Column("stem")]
    public string? Stem { get; set; }
    [Column("housingTop")]
    public string? HousingTop { get; set; }
    [Column("housingBottom")]
    public string? HousingBottom { get; set; }
}

public class SwitchConstructionResponse 
{
    public string? ID { get; set; }
    public string? SwitchID { get; set; }
    public string? Stem { get; set; }
    public string? HousingTop { get; set; }
    public string? HousingBottom { get; set; }
}