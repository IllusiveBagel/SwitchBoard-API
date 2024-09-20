namespace SwitchBoard.Models {
    public class Switch {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public SwitchDesign? SwitchDesign { get; set; }
        public SwitchConstruction? SwitchConstruction { get; set; }
        public SwitchData? SwitchData { get; set; }
        public SpringTypes Spring { get; set; }
        public VolumeTypes Volume { get; set; }
        public SwitchTypes Type { get; set; }
        public bool FactoryLubed { get; set; }
        
    }

    public enum SpringTypes {
        standard,
        goldPlated,
        Symmetric
    }

    public enum VolumeTypes {
        standard,
        loud,
        quiet
    }

    public enum SwitchTypes {
        linear,
        tactile,
        clicky
    }
}