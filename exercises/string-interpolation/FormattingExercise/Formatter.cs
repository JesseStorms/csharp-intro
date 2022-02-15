using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormattingExercise
{
    internal class Formatter
    {
        public static String Greet(String name)
        {
            return $"Hello, {name}";
        }

        public static String FormatDate(int d, int m, int y)
        {
            string day = d.ToString().PadLeft(2, '0');
            string month = m.ToString().PadLeft(2, '0');
            return $"{day}/{month}/{y}";
        }

    }
}
