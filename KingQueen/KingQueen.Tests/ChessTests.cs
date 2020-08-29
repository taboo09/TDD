using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace KingQueen.Tests
{
    public class ChessTests
    {
        private const int COLUMNS = 8;

        [Theory]
        [MemberData(nameof(KingAndQueenValues))]
        public void CheckValues_KingAndQueenValues_ArePositiveAndLessThanColumnsNr(bool onTable, Tuple<int, int> king, Tuple<int, int> queen)
        {
            var expectedValue = Chess.CheckValues(king, queen);

            expectedValue.Should().Be(onTable);
        }

        [Fact]
        public void Check_ReturnsException_WhenValuesAreOutOfRangeOf0And7()
        {
            var king = new Tuple<int, int>(-1, 2);
            var queen = new Tuple<int, int>(8, 0);

            Action act = () => Chess.Check(king, queen);

            act.Should().Throw<ArgumentOutOfRangeException>()
                .And.ParamName.Should().Be("Values are not valid.");
        }

        [Theory]
        [InlineData(4, 2, 4, 3)]
        [InlineData(0, 7, 5, 7)]
        public void Check_ReturnsCheckMessage_WhenXOrYAreEqual(int kingX, int kingY, int queenX, int queenY)
        {
            string result = Chess.Check(new Tuple<int, int>(kingX, kingY), new Tuple<int, int>(queenX, queenY));

            result.Should().Be("Check!");
        }

        [Theory]
        [InlineData(1, 0, 4, 3)]
        [InlineData(6, 1, 4, 3)]
        [InlineData(7, 7, 4, 4)]
        [InlineData(2, 6, 4, 4)]
        public void Check_ReturnsCheckMessage_WhenKingAndQueenAreOnDiagonal(int kingX, int kingY, int queenX, int queenY)
        {
            string result = Chess.Check(new Tuple<int, int>(kingX, kingY), new Tuple<int, int>(queenX, queenY));

            result.Should().Be("Check!");
        }

        [Theory]
        [InlineData(2, 0, 4, 3)]
        [InlineData(6, 2, 4, 3)]
        [InlineData(6, 7, 4, 4)]
        [InlineData(1, 5, 4, 4)]
        public void Check_ReturnsNonekMessage_WhenKingAndQueenHaveNotEqualValuesAndAreNotOnDiagonal(int kingX, int kingY, int queenX, int queenY)
        {
            string result = Chess.Check(new Tuple<int, int>(kingX, kingY), new Tuple<int, int>(queenX, queenY));

            result.Should().Be("None");
        }

        public static IEnumerable<object[]> KingAndQueenValues()
        {
            yield return new object[] { true, new Tuple<int, int>(1, 2), new Tuple<int, int>(0, 5) };
            yield return new object[] { true, new Tuple<int, int>(3, 3), new Tuple<int, int>(1, 7) };
            yield return new object[] { false, new Tuple<int, int>(4, 0), new Tuple<int, int>(2, 8) };
            yield return new object[] { false, new Tuple<int, int>(-1, 0), new Tuple<int, int>(2, 2) };
        }
    }
}