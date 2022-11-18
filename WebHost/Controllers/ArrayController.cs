using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using WebHost.Abstractions;

namespace WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrayController : ControllerBase
    {
        private readonly IArrayOperationsService _arrayOperationsService;
        public ArrayController(IArrayOperationsService arrayOperationsService)
        {
            _arrayOperationsService = arrayOperationsService;
        }
        [SwaggerOperation(Summary = "Example [124,155,2326,436,34]")]
        [HttpGet]
        public async Task<IActionResult> GetModSumOfArrayAsync(string arrayAsJson)
        {
            IActionResult result;
            try
            {
                var array = JsonConvert.DeserializeObject<int[]>(arrayAsJson);
                var moduleSum = await _arrayOperationsService.GetModuleSumOfOddValuesAsync(array);
                result = Ok(moduleSum);
            }
            catch (Exception exception)
            {
                result = BadRequest(exception.Message);
            }

            return result;
        }
    }
}
