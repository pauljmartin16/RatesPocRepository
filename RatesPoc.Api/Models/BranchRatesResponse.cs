using RatesPoc.Api.Models.Dtos;
using RatesPoc.Api.Services;

namespace RatesPoc.Api.Models
{
    // Note - Microservice patterns recommend each gets its own copy so they can
    // differentiate as 'bounded contexts'
    public class BranchRatesResponse
    {
        public BranchRatesResponse(NearestBranchLocatorDto dto, IRatesEnvironment ratesEnvironment)
        {
            // Just making the point here that DTOs should be copied to local (non-DTO) objects
            // Recommend Automapper over manual assignments
            BranchCode = dto.BranchCode;
            BranchName = dto.BranchName;
            LocatorDbServer = dto.LocatorDbPwd;
            LocatorDbUser = dto.LocatorDbUser;
            LocatorDbPwd = dto.LocatorDbPwd;
            ZipCode = dto.ZipCode;
            RatesDbServer = ratesEnvironment.RatesDbServer;
            RatesDbUser = ratesEnvironment.RatesDbUser;
            RatesDbPwd = ratesEnvironment.RatesDbPwd;
        }

        public string RatesDbServer { get; set; }
        public string RatesDbUser { get; set; }
        public string RatesDbPwd { get; set; }
        public string ZipCode { get; set; } = string.Empty;
        public string BranchCode { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public string LocatorDbServer { get; set; } = string.Empty;
        public string LocatorDbUser { get; set; } = string.Empty;
        public string LocatorDbPwd { get; set; } = string.Empty;

    }
}