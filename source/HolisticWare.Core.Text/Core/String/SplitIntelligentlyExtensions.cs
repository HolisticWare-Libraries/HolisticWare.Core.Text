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
        public static ((string Word, int Position)[] Words, string WordLongest) Words
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
                    @"!",
                    @".",
                    @"?",
                    @",",
                    @"\t",
                    @"\r",
                    @"\n",
                    @":",
                    @";",
                    "\"",
                };    
            }

            string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            (string Word, int Position)[] words_positions;

            words_positions = new (string Word, int Position)[words.Length];
            string word = null;
            int length_max = -1;
            int position_search_start = 0;
            int position_found = 0;

            for (int i = 0; i < words.Length; i++)
            {
                string w = words[i];
                position_found = text.IndexOf(w, position_search_start, StringComparison.CurrentCulture);
                words_positions[i] = (Word: w, Position: position_found);

                int length = w.Length;
                if (length > length_max)
                {
                    word = w;
                    length_max = length;
                }
                position_search_start = position_found;
            }

            return (Words: words_positions, WordLongest: word);
        }

        public static List<string> SplitForBufferNonOptimized
                                            (
                                                this string text,
                                                int max = int.MaxValue,
                                                string[] delimiters = null
                                            )
        {
            // TODO: coroutine / yield / enumerator function

            List<string> parts = new List<string>();

            if (text.Length <= max)
            {
                parts.Add(text);
            }

            ((string Word, int Position)[] Words, string WordLongest) words_positions = text.Words(delimiters);

            int word_longest_length = words_positions.WordLongest.Length;

            if (word_longest_length <= max)
            {
                int position_total_part_end = 0;
                int position_begin = 0;
                int position_end = 0;
                int word_count = words_positions.Words.Length;

                for (int i = 0; i < word_count - 1; i++)
                {
                    string word = words_positions.Words[i].Word;
                    int j = i + 1;

                    string word_next;
                    // if ()
                    word_next = words_positions.Words[i+1].Word;

                    int position = words_positions.Words[i].Position;
                    int position_next = words_positions.Words[i + 1].Position;

                    position_end = words_positions.Words[i].Position + word.Length;
                    position_total_part_end += position_end;

                    int part_length = position_next - position_begin;
                    int part_length_next = part_length + word_next.Length;

                    if (part_length_next >= max)
                    {
                        string part = null;
                        if(part_length <= max)
                        {
                            part = text.Substring(position_begin, part_length);
                        }
                        else
                        {
                            part = text.Substring(position_begin, max);
                        }
                        parts.Add(part);
                        position_begin = position_next;
                    }
                }
            }
            else
            {
                throw new ArgumentException($"Unsupported: Largest word length {word_longest_length} is longer than buffer {max}");   
            }

            return parts;
        }

        public static List<string> SplitForBuffer
                                            (
                                                this string text, 
                                                int max,
                                                string[] delimiters = null
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
