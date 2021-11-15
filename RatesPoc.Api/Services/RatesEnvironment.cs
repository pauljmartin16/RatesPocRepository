namespace RatesPoc.Api.Services
{   
    // Note - there's also the LOCATOR HOST and LOCATOR PORT variables. There's are handled
    // in the Program.cs bootstrap to build a Locator Uri so not including here
    public class RatesEnvironment : IRatesEnvironment
    {
        public string RatesDbServer => Environment.GetEnvironmentVariable("RATESDBSERVER")?? String.Empty;
        public string RatesDbUser => Environment.GetEnvironmentVariable("RATESDBUSER") ?? String.Empty;
        public string RatesDbPwd => Environment.GetEnvironmentVariable("RATESDBPWD") ?? String.Empty;
    }

    public interface IRatesEnvironment
    {
        public string RatesDbServer { get; }
        public string RatesDbUser { get; }
        public string RatesDbPwd { get; }
    }
}