namespace EnumKeysSample
{
    public class WineTypeDetails
    {
        public WineType Type { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<Wine>? Wines { get; set; }
    }
}
