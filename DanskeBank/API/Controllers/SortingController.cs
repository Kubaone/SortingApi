using Core.Helpers;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SortingController: ControllerBase
    {
        private IBubbleSorter _bubbleSorter;
        private IFileWriter _fileWriter;

        public SortingController(IFileWriter fileWriter, IBubbleSorter bubbleSorter)
        {
            _bubbleSorter = bubbleSorter;
            _fileWriter = fileWriter;
        }

        [HttpGet]
        public IActionResult GetLatestSortingResult()
        {
            return Ok(_fileWriter.GetLatestFileWritten());
        }

        [HttpPost]
        public IActionResult BubbleSortArray([FromBody] int[] numbers)
        {
            var sortedNumbers = _bubbleSorter.SortNumbers(numbers);
            var fileContent = String.Join(" ", sortedNumbers.Select(n => n.ToString()));

            _fileWriter.Write(fileContent);
            return Ok(sortedNumbers);
        }
    }
}
