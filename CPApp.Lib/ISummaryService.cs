using CPApp.Lib.Models;

namespace CPApp.Lib
{
    public interface ISummaryService
    {
        Task<SummaryReading> GetSummaryReading();
    }
}