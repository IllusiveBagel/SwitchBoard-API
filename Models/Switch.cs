using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SwitchBoard.Models;

[Table("switches")]
public class Switch : BaseModel
{
    [PrimaryKey("id", false)]
    public Guid ID { get; set; }
    [Column("name")]
    public string? Name { get; set; }
    [Reference(typeof(SwitchDesign))]
    public SwitchDesign? SwitchDesign { get; set; }
    [Reference(typeof(SwitchConstruction))]
    public SwitchConstruction? SwitchConstruction { get; set; }
    [Column("actuation")]
    public int Actuation { get; set; }
    [Column("bottomOut")]
    public int BottomOut { get; set; }
    [Column("preTravel")]
    public int PreTravel { get; set; }
    [Column("totalTravel")]
    public int TotalTravel { get; set; }
    [Column("spring")]
    public SpringTypes Spring { get; set; }
    [Column("volume")]
    public VolumeTypes Volume { get; set; }
    [Column("type")]
    public SwitchTypes Type { get; set; }
    [Column("factoryLubed")]
    public bool FactoryLubed { get; set; }

}

public enum SpringTypes
{
    standard,
    goldPlated,
    Symmetric
}

public enum VolumeTypes
{
    standard,
    loud,
    quiet
}

public enum SwitchTypes
{
    linear,
    tactile,
    clicky
}