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

namespace Core.Text
{
    public partial class CharacterSeparatedValues
    {
        public IEnumerable<string[]> Parse
                                        (
                                            string csv,
                                            NumberFormatInfo number_format_info = null,
                                            string[] newline_separators = null,
                                            string[] separators = null
                                        )
        {
            if (string.IsNullOrEmpty(csv))
            {
                throw new ArgumentException($"Empty or null string (input): {nameof(csv)}");
            }

            int n_snl = newline_separators.Length;
            string[] nl = null;

            if (null == newline_separators || n_snl == 0)
            {
                if (null == this.SeparatorsNewLine || this.SeparatorsNewLine.Length == 0)
                {
                    nl = new string[n_snl];
                    Array.Copy(this.SeparatorsNewLine, 0, nl, 0, n_snl);
                }
                else
                {
                    nl = new string[] { Environment.NewLine };
                }
            }

            NumberFormatInfo nfi_current = CultureInfo.CurrentCulture.NumberFormat;
            NumberFormatInfo nfi_en = new CultureInfo("en").NumberFormat;

            int n_s = separators.Length;
            string[] s = null;

            if (null == separators || n_s == 0)
            {
                if (null == this.Separators || this.Separators.Length == 0)
                {
                    s = new string[n_s];
                    Array.Copy(this.Separators, 0, s, 0, n_s);
                }
                else
                {
                    if (null == number_format_info && nfi_current == nfi_en)
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

            return this.Parse(csv, number_format_info, this.SeparatorsNewLine);
        }

    }
}
