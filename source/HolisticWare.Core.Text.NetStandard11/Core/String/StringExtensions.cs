using System;
using System.Collections.Generic;

namespace Core.Strings
{
    public static class StringExtensions
    {
        public static IEnumerable<string> SplitWithCharacter(this string s, char character)
        {
            ReadOnlyMemory<char> memory = s.AsMemory();

            if (memory.Span.IndexOf(character) == -1)
            {
                yield return s;
                yield break;
            }

            int length = memory.Span.Length;

            int start_index = 0;

            for (int i = start_index; i < length; i++)
            {
                char character_i = memory.Span[i];

                if (character_i == character)
                {
                    int length_of_item = i - start_index;

                    yield return memory.Span.Slice(start_index, length_of_item).ToString();

                    start_index = i + 1;
                }
            }

            int last_item = memory.Span.LastIndexOf(character);
            if (last_item != -1)
            {
                yield return memory.Span.Slice(last_item + 1).ToString();
            }
        }

        public static IEnumerable<string> SplitWithoutEmptySpaces(this string s, string[] separators)
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
                            ReadOnlySpan<char> splitted = readOnlyMemory.Span.Slice(start_index, length_of_item);
                            if (!splitted.IsEmpty)
                            {
                                yield return splitted.ToString();
                            }
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
                    ReadOnlySpan<char> splitted = readOnlyMemory.Span.Slice(start_index, length_of_item);
                    if (!splitted.IsEmpty)
                    {
                        yield return splitted.ToString();
                    }

                    start_index = i + length_of_item;
                }
            }
        }

    }
}
