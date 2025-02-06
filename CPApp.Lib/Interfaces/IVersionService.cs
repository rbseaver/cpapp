namespace CPApp.Lib.Interfaces
{
    public interface IVersionService
    {
        Task<string> GetFullVersion();
    }
}