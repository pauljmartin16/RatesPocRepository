using RatesPoc.Api.Middleware;
using RatesPoc.Api.Models;
using RatesPoc.Api.Models.Dtos;
using RatesPoc.Api.Services;

namespace RatesPoc.Api.BusinessLayer
{
    public interface IRatesBusinessService
    {
        Task<BranchRatesResponse> BranchRates(string zipCode);
    }

    public class RatesBusinessService : IRatesBusinessService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<RatesBusinessService> _logger;
        private readonly IRatesEnvironment _ratesEnvironment;

        public RatesBusinessService(IRatesEnvironment ratesEnvironment, ILogger<RatesBusinessService> logger, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _logger = logger;
            _ratesEnvironment = ratesEnvironment;
        }

        public async Task<BranchRatesResponse> BranchRates(string zipCode)
        {
            var uriPath = $"/api/nearestbranch/{zipCode}";
            _logger.LogInformation($"Calling Locator Microservice at [{uriPath}]");

            var response = await _httpClient.GetAsync(uriPath);
            if (response.IsSuccessStatusCode == false)
            {
                throw new Exception("Locator NearestBranch API call failed", new Exception(response.ToString()));
            }
            var nearestBranchDto = await response.ReadContentAs<NearestBranchLocatorDto>();
            var ratesResponse = new BranchRatesResponse(nearestBranchDto, _ratesEnvironment);
            return ratesResponse;   
        }
    }
}
