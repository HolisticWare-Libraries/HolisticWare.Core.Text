// /*
//    Copyright (c) 2018-4
//
//    moljac
//    SplitIntelligentlyExtensions.cs
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
using System.Diagnostics;

namespace Core.Strings
{
    public static class SplitIntelligentlyExtensions
    {
        public static List<string> SplitForBuffer
                                            (
                                                this string text, 
                                                int max
                                            )
        {
            var parts = new List<string>();

            var positionbegin = 0;
            var positionend = max;
            var position = positionbegin;
            var textlength = text.Length;

            var p = string.Empty;
            while (position != text.Length)
            {
                while (positionend > positionbegin)
                {
                    var ch = text[positionend];
                    if (char.IsWhiteSpace(ch) || char.IsPunctuation(ch))
                    {
                        p = text.Substring(positionbegin, positionend - positionbegin);
                        break;
                    }

                    if (positionend == positionbegin)
                    {
                        // no whitespace or punctuation found
                        // grab the whole buffer (max)
                        p = text.Substring(positionbegin, positionbegin + max);
                        break;
                    }

                    positionend--;
                }
                Debug.WriteLine($"------------------------------");
                Debug.WriteLine($"p                 = {p}");
                Debug.WriteLine($"p.Length          = {p.Length}");
                Debug.WriteLine($"    positionbegin = {positionbegin}");
                Debug.WriteLine($"    positionend   = {positionend}");
                Debug.WriteLine($"    position      = {position}");

                positionbegin = positionbegin + p.Length + 1;
                positionend = positionbegin + max;
                position = positionbegin;

                parts.Add(p);

                Debug.WriteLine($"....");
                Debug.WriteLine($"    positionbegin = {positionbegin}");
                Debug.WriteLine($"    positionend   = {positionend}");
                Debug.WriteLine($"    position      = {position}");
                Debug.WriteLine($"    textlength    = {textlength}");
                string s1 = text.Substring(positionbegin, positionend);
            }

            return parts;
        }

        public static string SplitWithCondition(this string text, int maxlength, Func<char, bool> conditions)
        {
            string result = string.Empty;

            return result;
        }
    }
}
