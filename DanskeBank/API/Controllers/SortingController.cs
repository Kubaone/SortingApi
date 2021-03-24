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
        private IQuickSorter _quickSorter;

        public SortingController(IFileWriter fileWriter, IBubbleSorter bubbleSorter, IQuickSorter quickSorter)
        {
            _bubbleSorter = bubbleSorter;
            _fileWriter = fileWriter;
            _quickSorter = quickSorter;
        }

        [HttpGet]
        public IActionResult GetLatestSortingResult()
        {
            return Ok(_fileWriter.GetLatestFileWritten());
        }

        [HttpPost]
        public IActionResult SortIntegerArray([FromBody] int[] numbers)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var sortedNumbersByBubble = _bubbleSorter.SortNumbers(numbers);
            watch.Stop();
            var bubbleSortExecutionTime = watch.ElapsedMilliseconds;

            watch.Restart();
            var sortedNumbersByQuick = _quickSorter.SortNumbers(numbers);
            watch.Stop();
            var quickSortExecutionTime = watch.ElapsedMilliseconds;

            var executionTimeDiff = Math.Abs(bubbleSortExecutionTime - quickSortExecutionTime);

            var fileContent = String.Join(" ", sortedNumbersByQuick.Select(n => n.ToString()));
            _fileWriter.Write(fileContent);

            return Ok(sortedNumbersByQuick);
        }
    }
}
