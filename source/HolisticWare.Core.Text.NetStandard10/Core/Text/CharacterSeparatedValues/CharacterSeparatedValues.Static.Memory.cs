using System;
using System.Collections.Generic;
using System.Linq;

using Core.Strings;

namespace Core.Text
{
    public partial class CharacterSeparatedValues
    {
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
    }
}
