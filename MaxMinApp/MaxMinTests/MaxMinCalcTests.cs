using System;
using System.Linq;
using FluentAssertions;
using MaxMin;
using Xunit;

namespace MaxMinTests
{
    public class MaxMinCalcTests
    {
        private readonly int[] _arr;
        private readonly int _k;
        public MaxMinCalcTests()
        {
            _arr = new int[] { 10, 100, 300, 200, 1000, 20, 30 };
            _k = 3;
        }

        [Theory]
        [InlineData(new int[] {1, 2, 3, 4, 5})]
        [InlineData(new int[] { 2, 3, 4 })]
        [InlineData(new int[] { 10, 30, 20 })]
        public void MaxMinCalc_ReturnsIntegerGreaterOrEqualToZero(int[] subArr)
        {
            var max = subArr.Max();
            var min = subArr.Min();

            var output = App.MaxMinCalc(subArr);

            output.Should().BeOfType(typeof(Int32), "result must be an integer greater than 0.");
            output.Should().BeGreaterOrEqualTo(0);
            output.Should().Be(max - min);
        }

        [Fact]
        public void GetSubArr_ReturnsSubArrFromArr_WhenOutputIsASubarray()
        {
            var subArr = App.GetSubArr(_arr, _k);

            subArr.Should().BeOfType(typeof(int[]));
            subArr.Should().HaveCountLessOrEqualTo(subArr.Length);
            subArr.Should().HaveCount(c => c == _k);
            // doesn't check for unique values
            subArr.Should().BeSubsetOf(_arr);
        }

        [Fact]
        public void GetSubArr_ReturnsArr_WhenArrLengthIsEqualToK()
        {
            var newArray = new int[] { 10, 100, 20, 200 };
            var expected = new int[] { 10, 20, 100, 200 };

            var subArr = App.GetSubArr(newArray, 4);

            subArr.Should().HaveCount(expected.Length);
        }

        [Theory]
        [InlineData(new int[] { 10, 100, 20, 200 }, new int[] { 10, 20 })]
        [InlineData(new int[] { 10, 100, 300, 200, 1000, 20, 30 }, new int[] { 10, 20, 30 })]
        [InlineData(new int[] { 1, 2, 3, 4, 10, 20, 30, 40, 100, 200 }, new int[] { 1, 2, 3, 4 })]
        [InlineData(new int[] { 1, 2, 1, 2, 1 }, new int[] { 1, 1 })]
        public void GetSubArr_ReturnsSubArrFromArr_WhenElemetsSubtractIsMinimum(int[] arr, int[] expectedArr)
        {
            var subArr = App.GetSubArr(arr, expectedArr.Length);

            subArr.Should().BeEquivalentTo(expectedArr);
        }
    }
}