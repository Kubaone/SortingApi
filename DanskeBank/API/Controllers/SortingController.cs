using Core.Helpers;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SortingController: ControllerBase
    {
        private IBubbleSorter _bubbleSorter;

        public SortingController(IBubbleSorter bubbleSorter)
        {
            _bubbleSorter = bubbleSorter;
        }

        [HttpPost]
        public IActionResult BubbleSort([FromBody] int[] numbers)
        {
            var sortedNumbers = _bubbleSorter.SortNumbers(numbers);
            return Ok(sortedNumbers);
        }
    }
}
