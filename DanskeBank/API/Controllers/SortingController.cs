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
        public SortingController()
        {

        }

        [HttpPost]
        public void BubbleSort([FromBody] double[] numbers)
        {
        }
    }
}
