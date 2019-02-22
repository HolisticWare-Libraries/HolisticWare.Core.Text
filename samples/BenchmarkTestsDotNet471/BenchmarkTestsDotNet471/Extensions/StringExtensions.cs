using System;
using System.Collections.Generic;
using System.Linq;

namespace BenchmarkTestsDotNet471.Extensions
{
    public static class StringExtensions
    {
        public static IEnumerable<ReadOnlyMemory<char>> MemorySplit(this string s, string[] separators)
        {
            ReadOnlyMemory<char> readOnlyMemory = s.AsMemory();
            int length = readOnlyMemory.Span.Length;
            ReadOnlyMemory<char> separator_item = new ReadOnlyMemory<char>();
            int start_index = 0;

            for (int i = start_index; i < length; i++)
            {
                for (int j = 0; j < separators.Length; j++)
                {
                    separator_item = separators[j].AsMemory();

                    if (i + separator_item.Length < length)
                    {
                        if (readOnlyMemory.Span.Slice(i, separator_item.Length).SequenceEqual(separator_item.Span))
                        {
                            int length_of_item = i - start_index;

                            ReadOnlyMemory<char> splitted = readOnlyMemory.Slice(start_index, length_of_item);

                            if (!splitted.IsEmpty)
                                yield return splitted;

                            start_index = i + separator_item.Length;
                        }
                    }
                }

                if (i + separator_item.Length == length)
                {
                    int length_of_item = i - start_index;

                    if (length_of_item < 0)
                    {
                        length_of_item = length - start_index;
                    }

                    
                    ReadOnlyMemory<char> splitted = readOnlyMemory.Slice(start_index, length_of_item);

                    if (!splitted.IsEmpty)
                    {
                        yield return splitted;
                    }

                    start_index = i + length_of_item;
                }
            }
        }
    }
}
