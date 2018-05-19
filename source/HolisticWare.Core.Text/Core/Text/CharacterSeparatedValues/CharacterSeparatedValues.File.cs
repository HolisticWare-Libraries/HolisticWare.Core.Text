// /*
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
using System.Linq;

namespace Core.Text
{
    public partial class CharacterSeparatedValues
    {
        /// <summary>
        /// Parse the specified csv data (character separated values) 
        ///     with given newline_separaqtors, number_format_info and separators.
        /// </summary>
        /// <returns>The parse.</returns>
        /// <param name="csv_content">Csv content.</param>
        /// <param name="newline_separators">Newline separators.</param>
        /// <param name="number_format_info">Number format info.</param>
        /// <param name="separators">Separators.</param>
        public IEnumerable<string[]> Parse
                                        (
                                            string csv_content,
                                            IEnumerable<string> newline_separators = null,
                                            NumberFormatInfo number_format_info = null,
                                            string[] separators = null
                                        )
        {
            if (string.IsNullOrEmpty(csv_content))
            {
                throw new ArgumentException($"Empty or null string (input): {nameof(csv_content)}");
            }

            string[] nl = null;
            int n_snl = -1;

            if (null == newline_separators || newline_separators.Count() == 0)
            {
                n_snl = this.SeparatorsNewLine.Length;
                if (null == this.SeparatorsNewLine || n_snl == 0)
                {
                    nl = new string[n_snl];
                    Array.Copy(this.SeparatorsNewLine, 0, nl, 0, n_snl);
                }
                else
                {
                    nl = new string[] { Environment.NewLine };
                    this.SeparatorsNewLine = nl;
                }
            }

            string[] lines = csv_content.Split(nl, StringSplitOptions.None);

            return this.Parse(lines, number_format_info, separators);
        }

        /// <summary>
        /// Parse the specified collection of csv data (character separated values) 
        ///     with given number_format_info and separators.
        /// </summary>
        /// <returns>The parse.</returns>
        /// <param name="csv_contents">Csv contents.</param>
        /// <param name="newline_separators">Newline separators.</param>
        /// <param name="number_format_info">Number format info.</param>
        /// <param name="separators">Separators.</param>
        public IEnumerable<IEnumerable<string[]>> Parse
                                        (
                                            IEnumerable<string> csv_contents,
                                            IEnumerable<string> newline_separators = null,
                                            NumberFormatInfo number_format_info = null,
                                            string[] separators = null
                                        )
        {
            foreach(string csv_content in csv_contents)
            {
                yield return this.Parse
                                    (
                                        csv_content,
                                        newline_separators,
                                        number_format_info,
                                        separators
                                    );
            }
        }


        /// <summary>
        /// Parse the specified lines of csv (character separated values) 
        ///     with given number_format_info and separators.
        /// </summary>
        /// <returns>The parse.</returns>
        /// <param name="csv">Csv.</param>
        /// <param name="number_format_info">Number format info.</param>
        /// <param name="separators">Separators.</param>
        public IEnumerable<string[]> Parse
                                         (
                                             string[] csv,
                                             NumberFormatInfo number_format_info = null,
                                             string[] separators = null
                                         )
        {
            string[] s = null;
            int n_s = -1;

            NumberFormatInfo nfi_current = NumberFormatInfo.CurrentInfo;
            NumberFormatInfo nfi_en_us = (new CultureInfo("en-US")).NumberFormat;

            if (null == separators || separators.Length == 0)
            {
                if (null == this.Separators || this.Separators.Length == 0)
                {
                    s = new string[n_s];
                    Array.Copy(this.Separators, 0, s, 0, n_s);
                }
                else
                {
                    if (null == number_format_info && nfi_current == nfi_en_us)
                    {
                        // not using "."
                        s = new string[] { ";", ",", " ", "#", "-" };
                    }
                    else
                    {
                        // not using "."
                        s = new string[] { ";", ".", " ", "#", "-" };

                    }
                }
            }

            string[] keys = null;
            int i = 0;

            if (this.IsHeader(csv[0]))
            {
                keys = this.ParseCommentLine(csv[0]);
                i = 1;
            }

            while (i < csv.Length)
            {
                string[] row_items = csv[i].Split(separators, StringSplitOptions.None);

                i++;

                yield return row_items;
            }
        }
   }
}
