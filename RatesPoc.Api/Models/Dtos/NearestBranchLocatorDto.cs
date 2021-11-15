namespace RatesPoc.Api.Models.Dtos
{
    // Note - Microservice patterns recommend each gets its own copy so they can
    // differentiate as 'bounded contexts'
    public class NearestBranchLocatorDto
    {
        public string ZipCode { get; set; } = string.Empty;
        public string BranchCode { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;       
        public string LocatorDbServer { get; set; } = string.Empty;
        public string LocatorDbUser { get; set; } = string.Empty;
        public string LocatorDbPwd { get; set; } = string.Empty;
    }
}