using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Text
{
    public partial class CharacterSeparatedValues
    {
        public IEnumerable<IEnumerable<string>> ParseUsingMemory
                                                        (
                                                            char column_delimiter,
                                                            string row_delimiter
                                                        )
        {
            return this.ParseUsingMemory(column_delimiter, row_delimiter.ToCharArray());
        }

        public IEnumerable<IEnumerable<string>> ParseUsingMemory
                                                        (
                                                            char column_delimiter,
                                                            char[] row_delimiters
                                                        )
        {
            throw new NotImplementedException("netstandard1.0 - Span<T> and Memory<T> not available");
        }


        public IEnumerable<string> ParseRowUsingMemory
                                        (
                                            string text_row,
                                            char column_delimiter
                                        )
        {
            throw new NotImplementedException("netstandard1.0 - Span<T> and Memory<T> not available");
        }

        public IEnumerable<string> ParseRowUsingMemory
                                        (
                                            ReadOnlyMemory<char> text_row,
                                            char column_delimiter
                                        )
        {
            throw new NotImplementedException("netstandard1.0 - Span<T> and Memory<T> not available");
        }

        public IEnumerable<string> ParseRowUsingString
                                        (
                                            ReadOnlyMemory<char> text_row,
                                            char column_delimiter
                                        )
        {
            throw new NotImplementedException("netstandard1.0 - Span<T> and Memory<T> not available");
        }


        public IEnumerable<IEnumerable<string>> ParseUsingString
                                                        (
                                                            char column_delimiter,
                                                            char[] row_delimiters
                                                        )
        {
            throw new NotImplementedException("netstandard1.0 - Span<T> and Memory<T> not available");
        }

        public IEnumerable<IEnumerable<string>> ParseUsingString
                                                       (
                                                           char column_delimiter,
                                                           char row_delimiter
                                                       )
        {
            throw new NotImplementedException("netstandard1.0 - Span<T> and Memory<T> not available");
        }

        public class ReadOnlyMemory<T>
        {
        }
    }
}
