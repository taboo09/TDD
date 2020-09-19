using FluentAssertions;
using Xunit;

namespace Fraudulent.Tests
{
    public class ClientTests
    {
        [Fact]
        public void Median_ReturnsInt_WhenArrayIsPassed()
        {
            var arr = new[] { 2, 3, 1, 4 };

            var result = ArrayCountSortSolution.Median(arr, 3);

            result.Should().BeOfType(typeof(double));
        }

        [Fact]
        public void ActivityNotifications_ReturnsInt_WhenParameterArePAssed()
        {
            var arr = new[] { 2, 3, 1, 4 };

            var result = ArrayCountSortSolution.ActivityNotifications(arr, 3);

            result.Should().BeOfType(typeof(int));
        }

        [Theory]
        [InlineData(new int[] {1, 2, 3}, 2, 1)]
        [InlineData(new int[] {2, 3, 1}, 2, 0)]
        [InlineData(new int[] {2, 3, 4, 2, 3}, 3, 0)]
        [InlineData(new int[] {5, 3, 4, 2, 2, 1, 3}, 3, 0)]
        [InlineData(new int[] {2, 3, 4, 2, 3, 6, 8, 4, 5}, 5, 2)]
        [InlineData(new int[] {1, 2, 3, 4, 4}, 4, 0)]
        [InlineData(new int[] {10, 20, 30, 40, 50}, 3, 1)]
        public void ActivityNotifications_ReturnsValue_WhenParameterArePAssed(int[] arr, int d, int expected)
        {
            var result = ArrayCountSortSolution.ActivityNotifications(arr, d);
            
            result.Should().Be(expected);
        }
    }
}