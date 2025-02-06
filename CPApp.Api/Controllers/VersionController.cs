using CPApp.Lib.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CPApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VersionController(IVersionService versionService)
    {
        [HttpGet(Name = "version")]
        public async Task<string> Get()
        {
            return await versionService.GetFullVersion();
        }
    }
}