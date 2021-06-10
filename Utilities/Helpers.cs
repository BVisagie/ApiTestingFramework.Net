using System;
using System.Text.RegularExpressions;

namespace ApiTestingFramework.Net.Utilities
{
    public class Helpers
    {
        /// <summary>
        /// Creates a short mostly unique id composed of only alphanumeric characters.
        /// https://stackoverflow.com/a/42026123/3324415
        /// </summary>
        public string GetRandomShortUid()
        {
            return Regex.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "[/+=]", "");
        }

        public string[] StringToArray(string targetString, string delimiter)
        {
            return targetString.Split(delimiter);
        }

        /// <summary>
        /// https://stackoverflow.com/a/40653822/3324415
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="allowDiff"></param>
        public bool AlmostEqualTo(double value1, double value2, double allowDiff)
        {
            return Math.Abs(value1 - value2) < allowDiff;
        }

        public bool NextBoolean()
        {
            Random randomSeed = new(Guid.NewGuid().GetHashCode());
            return randomSeed.Next() > (int.MaxValue / 2);
        }

        /// <summary>
        /// https://stackoverflow.com/a/4980896/3324415
        /// </summary>
        public int ResolveBoolAsBinary(bool input)
        {
            return input ? 1 : 0;
        }

        ///<summary>
        ///Based on given Enum returns a random value from it.
        ///</summary>
        public T GetRandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(new Random(Guid.NewGuid().GetHashCode()).Next(v.Length));
        }

        public int GetRandomNumber(int min, int max)
        {
            return new Random(Guid.NewGuid().GetHashCode()).Next(min, max);
        }

        public int GetRandomValidExcess()
        {
            int[] excessOptions = { 1000, 3000, 5000, 7000, 10000, 15000, 20000, 30000 };
            int randomIndexPosition = new Random(Guid.NewGuid().GetHashCode()).Next(0, excessOptions.Length - 1);
            return excessOptions[randomIndexPosition];
        }

        //https://stackoverflow.com/a/14511053
        public DateTime GetRandomDate(DateTime fromDate, DateTime toDate, bool doNotAllowRandomDatesInTheCurrentYear = true)
        {
            var range = toDate - fromDate;

            var randomTimeSpan = new TimeSpan((long)(new Random(Guid.NewGuid().GetHashCode()).NextDouble() * range.Ticks));

            var randomResult = fromDate + randomTimeSpan;

            if (doNotAllowRandomDatesInTheCurrentYear && randomResult.Year == DateTime.Now.Year)
            {
                randomResult.AddYears(-1);
            }

            return randomResult;
        }

        /// <summary>
        /// https://www.rapidtables.com/convert/power/kw-to-hp.html
        /// </summary>
        /// <param name="kilowatt"></param>
        public decimal ConvertKwToHp(int kilowatt)
        {
            decimal hpResult = (decimal)(kilowatt / 0.745699872);
            return Math.Round(hpResult, 2, MidpointRounding.ToEven);
        }
    }
}