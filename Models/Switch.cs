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
    [Reference(typeof(SwitchData))]
    public SwitchData? SwitchData { get; set; }
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