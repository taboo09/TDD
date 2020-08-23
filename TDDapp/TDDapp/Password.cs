using System.Linq;

namespace TDDapp
{
    public static class Password
    {
        #region Problem
            // https://www.hackerrank.com/challenges/strong-password/problem
            /*
            Its length is at 6 least.
            It contains at least one digit.
            It contains at least one lowercase English character.
            It contains at least one uppercase English character.
            It contains at least one special character. The special characters are: !@#$%^&*()-+ 
            */
        #endregion

        public static int PasswordStrong(string password)
        {
            var remainingCharacters = 0;

            if(!PasswordLowerCase(password)) remainingCharacters++;
            if(!PasswordDigits(password)) remainingCharacters++;
            if(!PasswordUpperCase(password)) remainingCharacters++;
            if(!PasswordSpecialCharacters(password)) remainingCharacters++;

            if(password.Length + remainingCharacters >= 6) return remainingCharacters;

            return 6 - password.Length;
        }

        // for the simplicity, methods are set to public
        public static bool PasswordDigits(string password)
        {
            return password.Any(char.IsDigit);
        }

        public static bool PasswordLowerCase(string password)
        {
            return password.Any(char.IsLower);
        }

        public static bool PasswordUpperCase(string password)
        {
            return password.Any(char.IsUpper);
        }

        public static bool PasswordSpecialCharacters(string password)
        {
            return !password.All(char.IsLetterOrDigit);
        }
    }
}