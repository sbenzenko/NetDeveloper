namespace EnumKeysSample
{
    public class Wine
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public WineType Type { get; set; }
        public WineTypeDetails TypeDetails { get; set; }
    }
}
