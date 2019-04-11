using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Text
{
    public partial class CharacterSeparatedValues
    {
        //============================================================================================================
        public static IEnumerable<string> ParseLines
                                                (
                                                    string lines,
                                                    char row_separator
                                                )
        {
            return lines.Split(row_separator);
        }

        public static IEnumerable<string> ParseLines
                                                (
                                                    string lines,
                                                    IEnumerable<char> row_separators
                                                )
        {
            if (row_separators.Count() == 1)
            {
                char separator = row_separators.ElementAt(0);
                ParseLines(lines, row_separators);
            }

            return lines.Split(row_separators.ToArray());
        }

        public static IEnumerable<string> ParseLines
                                                (
                                                    string lines,
                                                    string row_separator
                                                )
        {
            return lines.Split(new string[] { row_separator }, StringSplitOptions.None);
        }
        //============================================================================================================

        //============================================================================================================
        public static IEnumerable<string> ParseLine
                                                (
                                                    string line,
                                                    char separator
                                                )
        {
            return line.Split(separator);
        }

        public static IEnumerable<string> ParseLine
                                                (
                                                    string line,
                                                    IEnumerable<char> separators
                                                )
        {
            if (separators.Count() == 1)
            {
                char separator = separators.ElementAt(0);
                ParseLines(line, separator);
            }

            return line.Split(separators.ToArray());
        }
        //============================================================================================================

    }
}