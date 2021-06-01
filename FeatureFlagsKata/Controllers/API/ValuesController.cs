using FeatureFlagsKata.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FeatureFlagsKata.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IFeatureManager _featureManager;

        public ValuesController(IFeatureManager featureManager) => _featureManager = featureManager;

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<string> GetAsync()
        {
            if (await _featureManager.IsEnabledAsync(FeaturesEnum.Premium.ToString()))
            {
                return "Premium";
            }
            else
            {
                return "Basic";
            }
        }
    }
}
