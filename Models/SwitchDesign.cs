namespace SwitchBoard.Models {
    public class SwitchDesign {
        public int[]? StemColor { get; set; }
        public Types StemType { get; set; }
        public Types StemConstruction { get; set; }
        public Types HousingTopType { get; set; }
        public int[]? HousingTopColor { get; set; }
        public Types HousingBottomType { get; set; }
        public int[]? HousingBottomColor { get; set; }
        public MountTypes Mount { get; set; }
    }

    public enum Types {
        standard,
        milky
    }

    public enum MountTypes {
        pcb,
        plate,
        both
    }
}