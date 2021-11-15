using RatesPoc.Api.Models;
using RatesPoc.Api.Services;
using Microsoft.AspNetCore.Mvc;
using RatesPoc.Api.BusinessLayer;

namespace RatesPoc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        private IRatesEnvironment _ratesEnvironment;
        private ILogger<RatesController> _logger;
        private IRatesBusinessService _ratesBusinessService;
        public RatesController(ILogger<RatesController> logger, IRatesEnvironment ratesEnvironment, IRatesBusinessService ratesBusinessService)
        {
            _logger = logger;
            _ratesEnvironment = ratesEnvironment;
            _ratesBusinessService = ratesBusinessService;
        }

        [HttpGet("{zipCode}")]
        public Task<BranchRatesResponse> BranchRates(string zipCode)
        {
            _logger.LogInformation("Starting controller action NearestBranch for Zip {zipCode}", zipCode);

            // Basic example of Validation & Global error handling
            if (int.TryParse(zipCode, out int zipResult) == false)
            {
                throw new Exception("Invalid Zip Code");
            }

            return _ratesBusinessService.BranchRates(zipCode);
        }
    }
}