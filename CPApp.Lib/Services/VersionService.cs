using CPApp.Lib.Interfaces;
using System.Reflection;

namespace CPApp.Lib.Services
{
    public class VersionService : IVersionService
    {
        public async Task<string> GetFullVersion()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var version = assembly
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? assembly.GetName().Version.ToString();

            return await Task.FromResult(version);
        }
    }
}