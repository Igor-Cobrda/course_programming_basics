namespace Homework
{
    internal class Location
    {
        internal string name {  get; set; }
        internal string region { get; set; }
        internal string country { get; set; }
        internal double lat { get; set; }
        internal double lon { get; set; }
        internal string tz_id { get; set; }
        internal long localtime_epoch { get; set; }
        internal DateTime localtime_time { get; set; }
    }
}
