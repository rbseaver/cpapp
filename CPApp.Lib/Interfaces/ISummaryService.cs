using CPApp.Lib.Models;

namespace CPApp.Lib.Interfaces
{
    public interface ISummaryService
    {
        Task<SummaryReading> GetSummaryReading();
    }
}