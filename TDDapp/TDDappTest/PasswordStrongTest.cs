using System.Linq;
using TDDapp;
using Xunit;

namespace TDDappTest
{
    public class PasswordStrongTest
    {
        [Fact]
        public void PasswordStrong_StringInput_ReturnInt()
        {
            //Given
            var password = "abc";

            //When
            var result = Password.PasswordStrong(password);
            
            //Then
            Assert.IsType<int>(result);
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("ab")]
        [InlineData("A")]
        public void PasswordStrong_StringInput2And3_ReturnMinCharacters(string password)
        {
            var result = Password.PasswordStrong(password);

            var expected = 6 - password.Length;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("abcdef")]
        [InlineData("0123456")]
        [InlineData("ABCDEF")]
        [InlineData("!£$?+*")]
        public void PasswordStrong_StringInputMin6WithOneRequirement_Return3Characters(string password)
        {
            var result = Password.PasswordStrong(password);

            var expected = 3;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("abcdE222")]
        [InlineData("01234Ab")]
        [InlineData("ABCD!1")]
        [InlineData("!£$?a2")]
        public void PasswordStrong_StringInputMin6WithOneMissingRequirement_Return1Characters(string password)
        {
            var result = Password.PasswordStrong(password);

            var expected = 1;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("abcd!")]
        [InlineData("0123AB")]
        [InlineData("ABCD!")]
        [InlineData("!£$?aa")]
        public void PasswordStrong_StringInputMin5With2MissingRequirement_Return2Characters(string password)
        {
            var result = Password.PasswordStrong(password);

            var expected = 2;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("ab2")]
        public void PasswordDigits_StringInput_ContainsAtLeast1Digit(string password)
        {
            var result = Password.PasswordDigits(password);

            var expected = password.Any(char.IsDigit);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("ABc")]
        [InlineData("ABC")]
        public void PasswordLowerCase_StringInput_ContainsAtLeast1Lower(string password)
        {
            var result = Password.PasswordLowerCase(password);

            var expected = password.Any(char.IsLower);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Abc")]
        [InlineData("abc")]
        public void PasswordUpperCase_StringInput_ContainsAtLeast1Upper(string password)
        {
            var result = Password.PasswordUpperCase(password);

            var expected = password.Any(char.IsUpper);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Abc")]
        [InlineData("abD")]
        [InlineData("ab1D")]
        [InlineData("ab1D?")]
        [InlineData("1.2a")]
        public void PasswordSpecialCharacters_StringInput_ContainsAtLeast1Special(string password)
        {
            var result = Password.PasswordSpecialCharacters(password);

            var expected = !password.All(char.IsLetterOrDigit);

            Assert.Equal(expected, result);
        }
    }
}