using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SwitchBoard.Models;

[Table("SwitchDesign")]
public class SwitchDesign : BaseModel
{
    [PrimaryKey("id", false)]
    public string? ID { get; set; }
    [Column("switchId")]
    public string? SwitchID { get; set; }
    [Column("stemColor")]
    public List<int>? StemColor { get; set; }
    [Column("stemType")]
    public string? StemType { get; set; }
    [Column("stemConstruction")]
    public string? StemConstruction { get; set; }
    [Column("housingTopType")]
    public string? HousingTopType { get; set; }
    [Column("housingTopColor")]
    public List<int>? HousingTopColor { get; set; }
    [Column("housingBottomType")]
    public string? HousingBottomType { get; set; }
    [Column("housingBottomColor")]
    public List<int>? HousingBottomColor { get; set; }
    [Column("mount")]
    public string? Mount { get; set; }
}

public class SwitchDesignResponse {
    public string? ID { get; set; }
    public string? SwitchID { get; set; }
    public List<int>? StemColor { get; set; }
    public string? StemType { get; set; }
    public string? StemConstruction { get; set; }
    public string? HousingTopType { get; set; }
    public List<int>? HousingTopColor { get; set; }
    public string? HousingBottomType { get; set; }
    public List<int>? HousingBottomColor { get; set; }
    public string? Mount { get; set; }
}