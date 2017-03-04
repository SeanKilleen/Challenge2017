using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Challenge2017.API.Controllers
{
    public class HelloWorldController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Index(IEnumerable<int> inputs)
        {
            if (!inputs.Any()) { return BadRequest(); }
            var numberToGenerate = inputs.First();
            if (numberToGenerate < 0) { return BadRequest(); }

            var result = Enumerable.Repeat("Hello World", numberToGenerate);
            return Ok(result);
        }
    }
}
