namespace CPApp.Lib.Models
{
    public class SummaryReading
    {
        public DateTime Date { get; set; }
        public TimeSpan UsageHours { get; set; }
        public required PressureData Pressure { get; set; }
        public required EventData Events { get; set; }
        public double LeakRate { get; set; }
    }
}