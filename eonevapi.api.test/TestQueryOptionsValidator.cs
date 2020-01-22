using System;
using Xunit;
using eonevapi.api.Validators;
using eonevapi.core.QueryOptions;

namespace eonevapi.api.test
{
    public class TestQueryOptionsValidator
    {
        [Fact]
        public void TestBasic()
        {
            EventQueryOptionsValidator validator = new EventQueryOptionsValidator();
            var result = validator.validate(null, null, null, 0, null);
            Assert.Null(result.SearchStart);
            Assert.Null(result.SearchEnd);
            Assert.Null(result.SortingOptions);
            Assert.Equal("open", result.FilterStatus);
            Assert.Equal(-1, result.FilterCategory);
        }

        [Fact]
        public void TestWithOptions()
        {
            EventQueryOptionsValidator validator = new EventQueryOptionsValidator();
            var result = validator.validate(DateTime.Now.AddDays(-1), null, "closed", 3, "statusdesc");
            Assert.True(result.SearchStart <= DateTime.Now.AddDays(-1));
            Assert.Null(result.SearchEnd);
            Assert.Equal("closed", result.FilterStatus);
            Assert.Equal(3, result.FilterCategory);
            Assert.True(result.SortingOptions.OrderingOption == EventOrderingOptions.OrderByStatus && result.SortingOptions.Direction == OrderingDirection.DESC);
        }

        [Fact]
        public void TestWithBadOptions()
        {
            EventQueryOptionsValidator validator = new EventQueryOptionsValidator();
            Assert.ThrowsAny<Exception>(() =>
            {
                var result = validator.validate(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-2), "bla", 3, "statusdesc");
            });
            var result = validator.validate(DateTime.Now.AddDays(-1), null, "bla", -8, "blabla");
            Assert.True(result.SearchStart <= DateTime.Now.AddDays(-1));
            Assert.Null(result.SearchEnd);
            Assert.Equal("open", result.FilterStatus);
            Assert.Equal(-1, result.FilterCategory);
            Assert.True(result.SortingOptions.OrderingOption == EventOrderingOptions.OrderByDate && result.SortingOptions.Direction == OrderingDirection.ASC);
        }
    }
}
