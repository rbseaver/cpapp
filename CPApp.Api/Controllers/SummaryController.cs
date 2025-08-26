using CPApp.Lib;
using CPApp.Lib.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SummaryController(ISummaryService summaryService)
    {
        [HttpGet(Name = "summary")]
        public async Task<SummaryReading> Get()
        {
            return await summaryService.GetSummaryReading();
        }
    }
}