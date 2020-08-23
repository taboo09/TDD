using TDDapp;
using Xunit;

namespace TDDappTest
{
    public class ArrayCircularRotationTest
    {
        [Fact]
        public void ArrayRotation_InputArray_ReturnArray()
        {
            int[] a = new int[] { 1, 2, 3 };
            int k = 1;
            int[] q = new int[] { 0, 1 };

            var result = ArrayCircularRotation.ArrayRotation(a, k, q);

            Assert.IsType<int[]>(result);
        }

        [Theory]
        [InlineData(new int[] {1, 2, 3}, 2, new int[] {0, 2})]
        public void ArrayRotation_InputArrayAndRotationKlessThanN_ReturnRotatedArray(int[] a, int k, int[] q)
        {
            var result = ArrayCircularRotation.ArrayRotation(a, k, q);

            Assert.Equal(new int[] { 2, 1 }, result);
        }

        [Theory]
        [InlineData(new int[] {1, 2, 3, 4, 5}, 3, new int[] {1, 3, 4})]
        public void ArrayRotation_InputArrayAndRotationKlessThanNAgain_ReturnRotatedArray(int[] a, int k, int[] q)
        {
            var result = ArrayCircularRotation.ArrayRotation(a, k, q);

            Assert.Equal(new int[] { 4, 1, 2 }, result);
        }

        // [Theory]
        // [InlineData(new int[] {1, 2, 3, 4, 5}, 5, new int[] {1, 0, 3})]
        // public void ArrayRotation_InputArrayAndRotationKequalsN_ReturnRotatedArray(int[] a, int k, int[] q)
        // {
        //     var result = ArrayCircularRotation.ArrayRotation(a, k, q);

        //     Assert.Equal(new int[] { 2, 1, 4 }, result);
        // }

        // [Theory]
        // [InlineData(new int[] {1, 2, 3, 4, 5}, 7, new int[] {2, 3, 4})]
        // public void ArrayRotation_InputArrayAndRotationKgreaterN_ReturnRotatedArray(int[] a, int k, int[] q)
        // {
        //     var result = ArrayCircularRotation.ArrayRotation(a, k, q);

        //     Assert.Equal(new int[] { 1, 2, 3 }, result);
        // }
    }
}