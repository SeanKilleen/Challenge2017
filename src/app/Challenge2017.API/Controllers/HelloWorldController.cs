using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Challenge2017.API.Controllers
{
    public class HelloWorldController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Index(IEnumerable<int> inputs)
        {
            var inputList = inputs as IList<int> ?? inputs.ToList();
            if (!inputList.Any()) { return BadRequest(); }

            var numberToGenerate = inputList.First();
            if (numberToGenerate < 0) { return BadRequest(); }

            var result = Enumerable.Repeat("Hello World", numberToGenerate);
            return Ok(result);
        }
    }
}
