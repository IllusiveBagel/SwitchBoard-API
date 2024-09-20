namespace SwitchBoard.Models {
    public class SwitchConstruction {
        public Materials Stem { get; set; }
        public Materials HousingTop { get; set; }
        public Materials HousingBottom { get; set; }
    }

    public enum Materials {
        Nylon,
        POM,
        PC,
        Custom
    }
}