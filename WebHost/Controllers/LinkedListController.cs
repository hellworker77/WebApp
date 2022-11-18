using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebHost.Abstractions;

namespace WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkedListController : ControllerBase
    {
        private readonly ILinkedListOperationsService _linkedListOperationsService;
        private readonly IValidator<String> _stringValidator;

        public LinkedListController(ILinkedListOperationsService linkedListOperationsService,
            IValidator<String> stringValidator)
        {
            _linkedListOperationsService = linkedListOperationsService;
            _stringValidator = stringValidator;
        }
        [SwaggerOperation(Summary = "Example 125,1852")]
        [HttpGet]
        public async Task<IActionResult> GetSumOfListsAsync(string originForFirstList, 
            string originForSecondString)
        {
            IActionResult result;
            var validateFirstOrigin = await _stringValidator.ValidateAsync(originForFirstList);
            var validateSecondOrigin = await _stringValidator.ValidateAsync(originForSecondString);
            if (validateFirstOrigin.IsValid && validateSecondOrigin.IsValid)
            {
                var firstLinkedList =
                    await _linkedListOperationsService.GetLinkedListFromStringAsync(originForFirstList);
                var secondLinkedList =
                    await _linkedListOperationsService.GetLinkedListFromStringAsync(originForSecondString);

                var resultLinkedList =
                    await _linkedListOperationsService.GetSumOfTwoLinkedListsAsync(firstLinkedList, secondLinkedList);

                result = Ok(resultLinkedList);
            }
            else
            {
                result = BadRequest($"{originForFirstList} valid is {validateFirstOrigin.IsValid}\n" +
                                    $"{originForSecondString} valid is {validateSecondOrigin.IsValid}");

            }
            

            return result;
        }
    }
}
