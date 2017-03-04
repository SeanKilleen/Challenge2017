using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Http.Results;
using Challenge2017.API.Controllers;
using FluentAssertions;
using Xunit;

namespace Challenge2017.Tests
{
    public class HelloWorldControllerTests
    {
        public class Index
        {
            [Fact]
            public void EmptyArray_ReturnsBadResult()
            {
                var sut = new HelloWorldController();
                var emptyIntArray = new int []{};

                var result = sut.Index(emptyIntArray);

                result.Should().BeAssignableTo<BadRequestResult>();
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(100)]
            public void WithArrayNumberXInFirstPosition_ShouldReturnXHelloWorlds(int count)
            {
                var sut = new HelloWorldController();
                var emptyIntArray = new int[] { count };

                var result = sut.Index(emptyIntArray);

                result.Should().BeAssignableTo<OkNegotiatedContentResult<IEnumerable<string>>>();

                var okResult = result as OkNegotiatedContentResult<IEnumerable<string>>;

                var content = okResult.Content;

                content.Count(x => x == "Hello World").Should().Be(count);
            }

            [Fact]
            public void ArrayWithNegativeNumber_ReturnsBadRequest()
            {
                var sut = new HelloWorldController();
                var arrayWithNegativeNumber = new int[] { -1 };

                var result = sut.Index(arrayWithNegativeNumber);

                result.Should().BeAssignableTo<BadRequestResult>();
            }
        }
    }
}
