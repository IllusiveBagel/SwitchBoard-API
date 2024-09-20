using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SwitchBoard.Models;

[Table("SwitchDesign")]
public class SwitchDesign : BaseModel
{
    [PrimaryKey("id", false)]
    public Guid ID { get; set; }
    [Column("stemColor")]
    public int[]? StemColor { get; set; }
    [Column("stemType")]
    public Types StemType { get; set; }
    [Column("stemConstruction")]
    public Types StemConstruction { get; set; }
    [Column("housingTopType")]
    public Types HousingTopType { get; set; }
    [Column("housingTopColor")]
    public int[]? HousingTopColor { get; set; }
    [Column("housingBottomType")]
    public Types HousingBottomType { get; set; }
    [Column("housingBottomColor")]
    public int[]? HousingBottomColor { get; set; }
    [Column("mount")]
    public MountTypes Mount { get; set; }
}

public enum Types
{
    standard,
    milky
}

public enum MountTypes
{
    pcb,
    plate,
    both
}