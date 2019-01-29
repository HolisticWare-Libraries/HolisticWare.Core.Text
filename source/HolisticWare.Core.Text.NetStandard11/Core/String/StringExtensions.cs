using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Text.Core.String
{
    public static class StringExtensions
    {
        public static IEnumerable<string> SplitWithMemory(this string s, char character)
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

            var lastItem = memory.Span.LastIndexOf(character);
            if (lastItem != -1)
            {
                yield return memory.Span.Slice(lastItem + 1).ToString();
            }
        }
    }
}
