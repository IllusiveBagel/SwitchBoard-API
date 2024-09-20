using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SwitchBoard.Models {
    [Table("SwitchData")]
    public class SwitchData: BaseModel {
        [PrimaryKey("id", false)]
        public Guid ID { get; set; }
        [Column("actuation")]
        public int Actuation { get; set; }
        [Column("bottomOut")]
        public int BottomOut { get; set; }
        [Column("preTravel")]
        public int PreTravel { get; set; }
        [Column("totalTravel")]
        public int TotalTravel { get; set; }
    }
}