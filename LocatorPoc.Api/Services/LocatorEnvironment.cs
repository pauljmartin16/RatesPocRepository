namespace LocatorPoc.Api.Services
{    
    public class LocatorEnvironment : ILocatorEnvironment
    {
        public string LocatorDbServer => Environment.GetEnvironmentVariable("LOCATORDBSERVER")?? String.Empty;
        public string LocatorDbUser => Environment.GetEnvironmentVariable("LOCATORDBUSER") ?? String.Empty;
        public string LocatorDbPwd => Environment.GetEnvironmentVariable("LOCATORDBPWD") ?? String.Empty;
    }

    public interface ILocatorEnvironment
    {
        public string LocatorDbServer { get; }
        public string LocatorDbUser { get; }
        public string LocatorDbPwd { get; }
    }
}