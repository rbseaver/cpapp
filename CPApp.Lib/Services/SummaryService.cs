using CPApp.Lib.Interfaces;
using CPApp.Lib.Models;

namespace CPApp.Lib.Services
{
    public class SummaryService : ISummaryService
    {
        public async Task<SummaryReading> GetSummaryReading()
        {
            return await Task.FromResult(new SummaryReading
            {
                Pressure = new PressureData(),
                Events = new EventData()
            });
        }
    }
}