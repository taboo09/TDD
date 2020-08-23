using System;

namespace TDDapp
{
    public static class Time
    {
        public static string TimeConversion(string s)
        {
            var format = s.Substring(8);

            var time = s.Substring(0,8).Split(':');

            if(format == "AM" && time[0] == "12") return $"00:{time[1]}:{time[2]}";
            else if(format == "PM" && time[0] != "12") return $"{Int32.Parse(time[0]) + 12}:{time[1]}:{time[2]}";
            else return $"{time[0]}:{time[1]}:{time[2]}";
        }
    }
}