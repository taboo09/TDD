using System;

namespace KingQueen
{
    public class Chess
    {
        private const int COLUMNS = 8;
        public static bool CheckValues(Tuple<int, int> king, Tuple<int, int> queen)
        {
            // king
            if ((king.Item1 < 0 || king.Item1 >= COLUMNS) || (king.Item2 < 0 || king.Item2 >= COLUMNS)) return false;

            // Queen
            if ((queen.Item1 < 0 || queen.Item1 >= COLUMNS) || (queen.Item2 < 0 || queen.Item2 >= COLUMNS)) return false;

            return true;
        }

        public static string Check(Tuple<int, int> king, Tuple<int, int> queen)
        {
            if (!CheckValues(king, queen))
                throw new ArgumentOutOfRangeException("Values are not valid.");

            if (((king.Item1 == queen.Item1) || (king.Item2 == queen.Item2)) ||  
                (Math.Abs(king.Item1 - queen.Item1) == Math.Abs(king.Item2 - queen.Item2))) return "Check!";

            return "None";
        }
    }
}