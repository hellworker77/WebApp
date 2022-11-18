using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebHost.Abstractions;

namespace WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StringController : ControllerBase
    {
        private readonly IStringOperationsService _stringOperationsService;

        public StringController(IStringOperationsService stringOperationsService)
        {
            _stringOperationsService = stringOperationsService;
        }
        [SwaggerOperation(Summary = "Example а роза упала на лапу Азора")]
        [HttpGet]
        public async Task<bool> IsPalindromeAsync(string source)
        {
            var result = await _stringOperationsService.IsPalindromeAsync(source);
            return result;
        }
    }
}
