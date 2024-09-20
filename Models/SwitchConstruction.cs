using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SwitchBoard.Models {
    [Table("SwitchConstruction")]
    public class SwitchConstruction: BaseModel {
        [PrimaryKey("id", false)]
        public Guid ID { get; set; }
        [Column("stem")]
        public Materials Stem { get; set; }
        [Column("housingTop")]
        public Materials HousingTop { get; set; }
        [Column("housingBottom")]
        public Materials HousingBottom { get; set; }
    }

    public enum Materials {
        Nylon,
        POM,
        PC,
        Custom
    }
}