using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Text
{
    public partial class CharacterSeparatedValues
    {
        #if NETSTANDARD1_0
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
                                                           char row_delimiter
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


        public IEnumerable<IEnumerable<string>> ParseUsingString
                                                       (
                                                           char column_delimiter,
                                                           char row_delimiter
                                                       )
        {
            throw new NotImplementedException("netstandard1.0 - Span<T> and Memory<T> not available");
        }
#else
        /* 
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
            ReadOnlyMemory<char> text = this.Text.AsMemory();

            int i_end = text.Length;
            int i = 0;
            int i_0 = i;
            char row_delimiter = row_delimiters[0];

            if (row_delimiters.Length == 1)
            {
                while (i != i_end)
                {
                    char ch = text.Span[i];

                    if (ch == row_delimiter)
                    {
                        yield return this.ParseRowUsingMemory(text.Slice(i_0, i), column_delimiter);
                    }

                    i++;
                }
            }
            else if (row_delimiters.Length > 1)
            {
                while (i != i_end)
                {
                    char ch = text.Span[i];

                    if (ch == row_delimiter)
                    {
                        yield return this.ParseRowUsingMemory(text.Slice(i_0, i), column_delimiter);
                    }

                    i++;
                }
            }
        }

        public IEnumerable<IEnumerable<string>> ParseUsingMemory
                                                       (
                                                           char column_delimiter,
                                                           char row_delimiter
                                                       )
        {
            ReadOnlyMemory<char> text = this.Text.AsMemory();

            int i_end = text.Length;
            int i = 0;
            int i_0 = i;

            while (i != i_end)
            {
                char ch = text.Span[i];

                if (ch == row_delimiter)
                {
                    yield return this.ParseRowUsingMemory(text.Slice(i_0, i), column_delimiter);
                }

                i++;
            }
        }
        */

        public IEnumerable<string> ParseRowUsingMemory
                                                        (
                                                            string text_row,
                                                            char column_delimiter
                                                        )
        {
            ReadOnlyMemory<char> memory = text_row.AsMemory();

            return ParseRowUsingMemory(memory, column_delimiter);
        }

        public IEnumerable<string> ParseRowUsingMemory
                                                        (
                                                            ReadOnlyMemory<char> text_row,
                                                            char column_delimiter
                                                        )
        {
            int i_end = text_row.Length;
            int i = 0;
            int i_0 = i;

            while (i != i_end)
            {
                char ch = text_row.Span[i];

                if (ch == column_delimiter)
                {
                    string value = "n/a";
                    yield return value;
                }

                i++;
            }

        }

        public IEnumerable<string> ParseRowUsingString
                                                    (
                                                        ReadOnlyMemory<char> text_row,
                                                        char column_delimiter
                                                    )
        {
            int i_end = text_row.Length;
            int i = 0;
            int i_0 = i;

            while (i != i_end)
            {
                char ch = text_row.Span[i];

                if (ch == column_delimiter)
                {
                    string value = "n/a";
                    yield return value;
                }

                i++;
            }
        }


        public IEnumerable<IEnumerable<string>> ParseUsingString
                                                        (
                                                            char column_delimiter,
                                                            char[] row_delimiters
                                                        )
        {
            ReadOnlyMemory<char> text = this.Text.AsMemory();

            int i_end = text.Length;
            int i = 0;
            int i_0 = i;
            char row_delimiter = row_delimiters[0];

            if (row_delimiters.Length == 1)
            {
                while (i != i_end)
                {
                    char ch = text.Span[i];

                    if (ch == row_delimiter)
                    {
                        yield return this.ParseRowUsingString(text.Slice(i_0, i), column_delimiter);
                    }

                    i++;
                }
            }
            else if (row_delimiters.Length > 1)
            {
                while (i != i_end)
                {
                    char ch = text.Span[i];

                    if (ch == row_delimiter)
                    {
                        yield return this.ParseRowUsingString(text.Slice(i_0, i), column_delimiter);
                    }

                    i++;
                }
            }
        }

        public IEnumerable<IEnumerable<string>> ParseUsingString
                                                       (
                                                           char column_delimiter,
                                                           char row_delimiter
                                                       )
        {
            ReadOnlyMemory<char> text = this.Text.AsMemory();

            int i_end = text.Length;
            int i = 0;
            int i_0 = i;

            while (i != i_end)
            {
                char ch = text.Span[i];

                if (ch == row_delimiter)
                {
                    yield return this.ParseRowUsingString(text.Slice(i_0, i), column_delimiter);
                }

                i++;
            }
        }
#endif

#if NETSTANDARD1_3
#endif


    }
}
