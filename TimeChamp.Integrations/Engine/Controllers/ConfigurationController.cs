
using Engine.DTOs.ApiResponseModel;
using Engine.Service.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace Engine.Controllers
{
    [Route("api/integrations")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private ConfigurationService _configurationService { get; set; }
        public  ConfigurationController(ConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        [HttpGet]
        public ApiResponse GetAllIntegrations()
        {
            try
            {
                _configurationService.GetAllIntegrations();

                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
