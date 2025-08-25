namespace CPApp.Lib.Models
{
    public class EventData
    {
        public int ObstructiveApneaEvents { get; set; }
        public int CentralApneaEvents { get; set; }
        public int HypopneaEvents { get; set; }
        public double AHI { get; set; } // Apnea-Hypopnea Index
    }
}