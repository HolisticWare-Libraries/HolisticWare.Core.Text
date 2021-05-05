//    Copyright (c) 2018-4
//
//    moljac
//    CharacterSeparatedValues.cs
//
//    Permission is hereby granted, free of charge, to any person
//    obtaining a copy of this software and associated documentation
//    files (the "Software"), to deal in the Software without
//    restriction, including without limitation the rights to use,
//    copy, modify, merge, publish, distribute, sublicense, and/or sell
//    copies of the Software, and to permit persons to whom the
//    Software is furnished to do so, subject to the following
//    conditions:
//
//    The above copyright notice and this permission notice shall be
//    included in all copies or substantial portions of the Software.
//
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
//    OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
//    NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
//    HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
//    WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
//    FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace Core.Text
{
    public partial class CharacterSeparatedValues
    {
        #if NETSTANDARD1_1
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public
            void
                Parse
                    (
                        string csv_content,
                        string[] data_separators = null,
                        IEnumerable<string> newline_separators = null,
                        NumberFormatInfo number_format_info = null
                    )
        {
            if (string.IsNullOrEmpty(csv_content))
            {
                throw new ArgumentException($"Empty or null string (input): {nameof(csv_content)}");
            }

            #if DEBUG
            StringBuilder sb = new StringBuilder();
            #endif

            ReadOnlySpan<char> csv_content_span = csv_content.AsSpan();

            int position = 0;

            while (position < csv_content_span.Length)
            {
                char ch_at_position = csv_content_span[position];

                if(char.IsWhiteSpace(ch_at_position))
                {
                    position++;
                    continue;
                }



                #if DEBUG
                sb.Append(ch_at_position);
                System.Diagnostics.Debug.WriteLine(sb.ToString());
                #endif
            }

        }
        #endif

    }
}
