using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Challenge2017.API.Controllers
{
    /// <summary>
    /// The HelloWorld question for the 2017 Coding Challenge. Excella is nice!
    /// </summary>

    public class HelloWorldController : ApiController
    {
        /// <summary>
        /// The default action, so excutes at /api/HelloWorld. Receives an integer as a single-item array, and returns an array that includes "Hello World" exactly that number of times. Returns a bad request if the array is empty or the number is negative.
        /// </summary>
        /// <param name="input">The input from the coding challenge bot. Should be an array with one integer.</param>
        /// <returns>An http result. BadRequest for empty array or negative number; otherwise, an array with "Hello World" the specified number of times.</returns>
        [HttpPost]
        public IHttpActionResult Index(IEnumerable<int> input)
        {
            var inputList = input as IList<int> ?? input.ToList();
            if (!inputList.Any()) { return BadRequest(); }

            var numberToGenerate = inputList.First();
            if (numberToGenerate < 0) { return BadRequest(); }

            var result = Enumerable.Repeat("Hello World", numberToGenerate);
            return Ok(result);
        }
    }
}
