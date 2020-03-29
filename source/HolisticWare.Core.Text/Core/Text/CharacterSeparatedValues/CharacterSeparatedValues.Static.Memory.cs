using System;
using System.Collections.Generic;
using System.Linq;

using Core.Strings;

namespace Core.Text
{
    public partial class CharacterSeparatedValues
    {
        #if NETSTANDARD1_0
        public static IEnumerable<string> ParseLineMemory(string line, char separator)
        {
            throw new NotImplementedException("netstandard1.0 - Span<T> and Memory<T> not available");
        }

        public static IEnumerable<string> ParseLineMemory(string line, IEnumerable<char> separators)
        {
            throw new NotImplementedException("netstandard1.0 - Span<T> and Memory<T> not available");
        }

        public static IEnumerable<string> ParseLinesMemory(string lines, char row_separator)
        {
            throw new NotImplementedException("netstandard1.0 - Span<T> and Memory<T> not available");
        }

        public static IEnumerable<string> ParseLinesMemory(string lines, string row_separator)
        {
            throw new NotImplementedException("netstandard1.0 - Span<T> and Memory<T> not available");
        }
        #else
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

        public static IEnumerable<string> ParseLinesMemory(string lines, IEnumerable<char> row_separators)
        {
            if (row_separators.Count() == 1)
            {
                char separator = row_separators.ElementAt(0);
                ParseLinesMemory(lines, row_separators);
            }

            return lines.FastSplit(row_separators.ToArray());
        }
        #endif

        #if NETSTANDARD1_3
        #endif
    }
}
