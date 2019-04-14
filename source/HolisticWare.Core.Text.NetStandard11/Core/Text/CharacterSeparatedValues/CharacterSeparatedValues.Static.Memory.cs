using Core.Strings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Text
{
    public partial class CharacterSeparatedValues
    {
        public static IEnumerable<string> ParseLineMemory(string line, char separator)
        {
            return line.FastSplit(separator);
        }

        public static IEnumerable<string> ParseLineMemory(string line, IEnumerable<char> separators)
        {
            if (separators.Count() == 1)
            {
                char separator = separators.ElementAt(0);
                ParseLinesMemory(line, separator);
            }

            return line.FastSplit(separators.ToArray());
        }

        public static IEnumerable<string> ParseLinesMemory(string lines, char row_separator)
        {
            return lines.FastSplit(row_separator);
        }
    }
}
