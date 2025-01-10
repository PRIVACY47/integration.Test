using KekaAdapter.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KekaAdapter.Controllers
{
    [Route("api/KekaAdapter")]
    [ApiController]
    public class KekaAdapterControllers : ControllerBase
    {
        public KekaAdapterService _kekaAdapterService { get; set; }  
        public KekaAdapterControllers(KekaAdapterService kekaAdapterService) 
        {
            _kekaAdapterService = kekaAdapterService;
        }

        [HttpPost("GetUtc")]
        public string GetUtcFromKeka([FromBody] string value)
        {
            //payload deserialization

            //call service for the output
            _kekaAdapterService.GetUtcFromKeka(value);

            //adapterlogic(in single line using automapper)

            //payload serialization
            return value;
        }

    }
}
