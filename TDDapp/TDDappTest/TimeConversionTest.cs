using System;
using TDDapp;
using Xunit;

namespace TDDappTest
{
    public class TimeConversionTest
    {
        [Fact]
        public void TimeConversion_StringInput_StringReturn()
        {
            var test = "hh:mm:ss:AM";

            var result = Time.TimeConversion(test);

            Assert.IsType<string>(result);
        }

        [Fact]
        public void TimeConversion_Time12AMInput_StringTime()
        {
            var time = "12:00:00AM";

            var result = Time.TimeConversion(time);

            Assert.Equal("00:00:00", result);
        }

        [Fact]
        public void TimeConversion_TimeAMnot12Input_StringTime()
        {
            var time = "11:00:00AM";

            var result = Time.TimeConversion(time);

            Assert.Equal("11:00:00", result);
        }

        [Fact]
        public void TimeConversion_TimePMnot12Input_StringTime()
        {
            var time = "05:00:00PM";

            var result = Time.TimeConversion(time);

            Assert.Equal("17:00:00", result);
        }

        [Fact]
        public void TimeConversion_Time12PMInput_StringTime()
        {
            var time = "12:00:00PM";

            var result = Time.TimeConversion(time);

            Assert.Equal("12:00:00", result);
        }        
    }
}
