﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            private HelloWorldController sut;
            public Index()
            {
                sut = new HelloWorldController();
            }

            [Fact]
            public void EmptyArray_ReturnsBadResult()
            {
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
                var arrayWithNegativeNumber = new int[] { -1 };

                var result = sut.Index(arrayWithNegativeNumber);

                result.Should().BeAssignableTo<BadRequestResult>();
            }

            [Fact]
            public void DoesntCareAboutAnyNumberInInputArrayExceptFirst()
            {
                var emptyIntArray = new int[] { 6, 3, 5, 100 };

                var result = sut.Index(emptyIntArray);
                var okResult = result as OkNegotiatedContentResult<IEnumerable<string>>;
                var content = okResult.Content;

                content.Count(x => x == "Hello World").Should().Be(6);
            }
        }
    }
}
