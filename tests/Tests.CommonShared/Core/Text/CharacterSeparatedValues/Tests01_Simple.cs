// /*
//    Copyright (c) 2017-12
//
//    moljac
//    Test.cs
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
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Globalization;

#if XUNIT
using Xunit;
// NUnit aliases
using Test = Xunit.FactAttribute;
// XUnit aliases
using TestClass = HolisticWare.Core.Testing.UnitTests.UnitTestsCompatibilityAliasAttribute;
#elif NUNIT
using NUnit.Framework;
// MSTest aliases
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestProperty = NUnit.Framework.PropertyAttribute;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
using TestContext = System.Object;
// XUnit aliases
using Fact=NUnit.Framework.TestAttribute;
#elif MSTEST
using Microsoft.VisualStudio.TestTools.UnitTesting;
// NUnit aliases
using Test = Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute;
// XUnit aliases
using Fact = Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute;
#endif

using Core.Text;

namespace UnitTests.Core.Text
{
    public partial class Tests01_Simple
    {
        [Test()]
        public void CharacterSeparatedValues_Header()
        {
            //-----------------------------------------------------------------------------------------
            // Arrange
            CharacterSeparatedValues csv = new CharacterSeparatedValues()
            {
                Text = TextContent,
                Separators = new string[] { "." },
                NumberFormatInfo = new System.Globalization.NumberFormatInfo()
                {
                    CurrencyDecimalSeparator = ","
                }
            };
            //-----------------------------------------------------------------------------------------
            // Act
            sw.Start();
            IEnumerable<IEnumerable<string>> lines = csv.Parse();  //(text);
            csv.Parse(); //(text);
            sw.Reset();
            //ConsoleOutput(csv_parsed);
            //-----------------------------------------------------------------------------------------
            // Assert
            #if NUNIT
            Assert.AreEqual(lines.Count(), 2);
            #elif XUNIT
            Assert.Equal(lines.Count(), 2);
            #elif MSTEST
            Assert.AreEqual(lines.Count(), 2);
            #endif
            //-----------------------------------------------------------------------------------------

            return;
        }

        [Test()]
		public void CharacterSeparatedValues_Parse()
        {
            //-----------------------------------------------------------------------------------------
            // Arrange
            CharacterSeparatedValues csv = new CharacterSeparatedValues()
            {
                Text = TextContent,
                Separators = new string[] { "." },
                HasHeader = false,
            };
            IEnumerable<IEnumerable<string>> csv_parsed = null;

            //-----------------------------------------------------------------------------------------
            // Act
            sw.Start();
            csv_parsed = csv.Parse
                                (
                                    //FileTextContent,
                                    //newline_separators: null,
                                    //number_format_info: NumberFormatInfo.CurrentInfo
                                );
            sw.Reset();
            //ConsoleOutput(csv_parsed);
            //-----------------------------------------------------------------------------------------
            // Assert
#if NUNIT
            Assert.AreEqual(csv_parsed.Count(), 2);
#elif XUNIT
            Assert.Equal(csv_parsed.Count(), 2);
#elif MSTEST
            Assert.AreEqual(csv_parsed.Count(), 2);
            #endif
            //-----------------------------------------------------------------------------------------

            return;
        }

    }
}
