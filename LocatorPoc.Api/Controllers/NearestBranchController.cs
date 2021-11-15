using LocatorPoc.Api.Models;
using LocatorPoc.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocatorPoc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NearestBranchController : ControllerBase
    {
        private ILocatorEnvironment _locatorEnvironment;
        private ILogger<NearestBranchController> _logger;
        public NearestBranchController(ILogger<NearestBranchController> logger, ILocatorEnvironment locatorEnvironment)
        {
            _logger = logger;
            _locatorEnvironment = locatorEnvironment;
        }

        [HttpGet("{zipCode}")]
        public NearestBranchResponse NearestBranch(string zipCode)
        {
            _logger.LogInformation("Starting controller action NearestBranch for Zip {zipCode}", zipCode);

            // Basic example of Validation & Global error handling
            if (int.TryParse(zipCode, out int zipResult) == false)
            {
                throw new Exception("Invalid Zip Code");
            }

            return new NearestBranchResponse
            {
                ZipCode = zipCode,
                BranchCode = "BR-ABC1",
                BranchName = "Branch on the Hill",
                LocatorDbServer = _locatorEnvironment.LocatorDbServer,
                LocatorDbUser = _locatorEnvironment.LocatorDbUser,
                LocatorDbPwd = _locatorEnvironment.LocatorDbPwd
            };
        }
    }
}