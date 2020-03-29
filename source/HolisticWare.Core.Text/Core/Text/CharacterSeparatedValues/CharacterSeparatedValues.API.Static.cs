using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Text
{
    public partial class CharacterSeparatedValues
    {
        //============================================================================================================
        #if NETSTANDARD1_3
        public static IEnumerable<string> ParseFile
                                                (
                                                    string file,
                                                    char row_separator
                                                )
        {
            string text = System.IO.File.ReadAllText(file);

            return ParseLines(text, row_separator);
        }

        public static IEnumerable<string> ParseFile
                                                (
                                                    string file,
                                                    string row_separator
                                                )
        {
            string text = System.IO.File.ReadAllText(file);

            return ParseLines(text, row_separator);
        }

        public static IEnumerable<string> ParseFileMemory
                                                (
                                                    string file,
                                                    char row_separator
                                                )
        {
            string text = System.IO.File.ReadAllText(file);

            return ParseLinesMemory(text, row_separator);
        }

        public static IEnumerable<string> ParseFileMemory
                                                (
                                                    string file,
                                                    string row_separator
                                                )
        {
            string text = System.IO.File.ReadAllText(file);

            return ParseLinesMemory(text, row_separator);
        }
        #endif
        //============================================================================================================

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

        //============================================================================================================
        public static TypeCustom ParseAndConvertLine<TypeCustom>
                                                        (
                                                            string line,
                                                            char separator,
                                                            Func<IEnumerable<string>, TypeCustom> conversion = null
                                                        )
        {
            TypeCustom result = default(TypeCustom);
            Type type_type_custom = typeof(TypeCustom);

            if (conversion != null)
            {
                //result = conversion
                //                (
                //                    ParseAndConvertLineDefaultImplementation(line, separator)
                //                );
            }
            else if ( type_type_custom == typeof(IEnumerable<string>) )
            {
                //result = ParseAndConvertLineDefaultImplementation(line, separator);

            }

            return result;
        }

        public static IEnumerable<string> ConvertLineDefaultImplementation
                                                            (
                                                                IEnumerable<string> items
                                                            )
        {
            return items;
        }

        public static T ConvertLine<T>
                                                            (
                                                                IEnumerable<string> items,
                                                                Func<IEnumerable<string>, T> converter = null
                                                            )
        {
            return converter(items);
        }





        public static IEnumerable<string> ParseAndConvertLine
                                                (
                                                    string line,
                                                    IEnumerable<char> separators,
                                                    Func<IEnumerable<string>, Type> conversion
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