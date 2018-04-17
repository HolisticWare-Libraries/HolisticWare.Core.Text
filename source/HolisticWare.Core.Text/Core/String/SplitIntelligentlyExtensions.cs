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
        public static string[] Words
                                (
                                    this string text,
                                    string[] delimiters = null
                                )
        {
            if (null == delimiters)
            {
                delimiters = new string[]
                {
                    " ",
                    Environment.NewLine,
                    @"\t",
                    @".",
                    @",",
                    @"|",
                    @"?",
                    @":",
                    @";",
                    @"!",
                    "\"",
                };    
            }

            string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            return words;
        }

        public static List<string> SplitForBuffer
                                            (
                                                this string text, 
                                                int max
                                            )
        {
            var parts = new List<string>();
            var textlength = text.Length;

            if (max > textlength)
            {
                parts.Add(text);
                return parts;
            }

            var positionbegin = 0;
            var positionend = max;
            var position = positionbegin;
            var p = string.Empty;

            while (position < textlength)
            {
                Debug.WriteLine($"------------------------------");
                Debug.WriteLine($"positionbegin     = {positionbegin}");
                Debug.WriteLine($"positionend       = {positionend}");
                Debug.WriteLine($"position          = {position}");
                while (positionend > positionbegin)
                {
                    // positionend < textlength
                    var ch = text[positionend];
                    if (char.IsWhiteSpace(ch) || char.IsPunctuation(ch))
                    {
                        break;
                    }

                    positionend--;
                }





                char ch_begin = text[positionbegin];
                char ch_end = text[positionend];

                if (positionend != positionbegin)
                {
                    // whitespace or punctuation found

                    p = text.Substring(positionbegin, positionend - positionbegin);
                    parts.Add(p);

                    if ((positionbegin + max) <= textlength)
                    {
                        // end not in sight

                        string s1 = text.Substring(positionbegin, max);
                        string s2 = text.Substring(positionbegin, positionend - positionbegin);

                        // far from the end
                        if (p.Length < max)
                        {
                            // p.Length < max (buffer length)
                            positionbegin = positionbegin + p.Length + 1;
                            positionend = positionbegin + max;
                            if (positionend > textlength)
                            {
                                positionend = textlength - 1;
                            }
                            position = positionbegin;
                        }
                        else
                        {
                            // small buffer fixup
                            // p.Length == max (buffer length) 
                            // word is the length of buffer or longer
                            if (positionbegin != positionend)
                            {
                                positionbegin = positionbegin + p.Length + 1;
                                positionend = positionbegin + max;
                                position = positionbegin;
                            }
                            else
                            {
                                positionbegin = positionbegin + p.Length + 2;
                                positionend = textlength - 1;
                                position = positionend;
                            }
                        }
                    }
                    else
                    {
                        // end in sight - less than buffer away


                        // close to the end - fix indices
                        positionbegin = textlength - max + 1;
                        positionend = positionbegin + max;
                        position = positionbegin;

                        if (positionend > textlength)
                        {
                            positionend = textlength - 1;
                            parts.Add(p);
                            break;
                        }
                    }
                }
                else
                {
                    // NO whitespace or punctuation found
                    // full buffer read (single word is the size of buffer or longer)

                    // no whitespace or punctuation found
                    // grab the whole buffer (max)

                    string s1 = text.Substring(positionbegin, max);
                    string s2 = text.Substring(positionbegin, positionend - positionbegin);

                    p = text.Substring(positionbegin, max);
                    positionbegin = positionbegin + max + 1;
                    positionend = positionbegin + max;
                    if (positionend > textlength)
                    {
                        positionend = textlength - 1;
                    }
                    position = positionbegin;
                    parts.Add(p);
                    continue;
                }




                Debug.WriteLine($"p                 = {p}");
                Debug.WriteLine($"p.Length          = {p.Length}");

                Debug.WriteLine($"....");
                Debug.WriteLine($"    positionbegin = {positionbegin}");
                Debug.WriteLine($"    positionend   = {positionend}");
                Debug.WriteLine($"    position      = {position}");
                Debug.WriteLine($"    textlength    = {textlength}");
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
