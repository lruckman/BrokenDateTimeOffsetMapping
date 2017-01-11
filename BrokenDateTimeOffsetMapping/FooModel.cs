namespace BrokenDateTimeOffsetMapping
{
    public class FooModel
    {
        public int Key { get; set; }
        public string MyDate { get; set; }
        //this one will succeed
        //public DateTimeOffset MyDate { get; set; }
    }
}
