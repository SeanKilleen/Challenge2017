﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using Challenge2017.API.Controllers;
using FluentAssertions;
using Xunit;

// ReSharper disable PossibleNullReferenceException -- the content result could be null, but if it is, the test will fail.

namespace Challenge2017.Tests
{
    public class HelloWorldControllerTests
    {
        /// <summary>
        /// The index class for the HelloWorld controller. Excella is nice!
        /// </summary>
        public class Index
        {
            private readonly HelloWorldController _sut;
            public Index()
            {
                _sut = new HelloWorldController();
            }

            [Fact]
            public void EmptyArray_ReturnsBadResult()
            {
                var emptyIntArray = new int []{};

                var result = _sut.Index(emptyIntArray);

                result.Should().BeAssignableTo<BadRequestResult>();
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(100)]
            public void WithArrayNumberXInFirstPosition_ShouldReturnXHelloWorlds(int count)
            {
                var arrayWithCount = new[] { count };

                var result = _sut.Index(arrayWithCount);
                var okResult = result as OkNegotiatedContentResult<IEnumerable<string>>;
                var content = okResult.Content;

                content.Count(x => x == "Hello World").Should().Be(count);
            }

            [Fact]
            public void ArrayWithNegativeNumber_ReturnsBadRequest()
            {
                var arrayWithNegativeNumber = new[] { -1 };

                var result = _sut.Index(arrayWithNegativeNumber);

                result.Should().BeAssignableTo<BadRequestResult>();
            }

            [Fact]
            public void DoesntCareAboutAnyNumberInInputArrayExceptFirst()
            {
                var emptyIntArray = new[] { 6, 3, 5, 100 };

                var result = _sut.Index(emptyIntArray);
                var okResult = result as OkNegotiatedContentResult<IEnumerable<string>>;
                var content = okResult.Content;

                content.Count(x => x == "Hello World").Should().Be(6);
            }
        }
    }
}
