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

namespace UnitTests.Core_Text_CharacterSeparatedValues
{
    public partial class TestsStaticAPI
    {
        [Test()]
        public void CharacterSeparatedValues_API_static_ParseLinesMemory_01()
        {
            //-----------------------------------------------------------------------------------------
            // Arrange
            string content =
                @"
                11,12,13,14,15,16,17,18,19,110,111,112,113
                11,12,13,14,15,16,17,18,19,110,111,112,113
                21,22,23,24,25,26,27,28,29,210,211,212,213
                31,32,33,34,35,36,37,38,39,310,311,312,313
                31,32,33,34,35,36,37,38,39,310,311,312,313
                31,32,33,34,35,36,37,38,39,310,311,312,313
                41,42,43,44,45,46,47,48,49,410,411,412,413
                ";
            //-----------------------------------------------------------------------------------------
            // Act
            sw.Start();
            IEnumerable<string> lines = CharacterSeparatedValues.ParseLines
                                                                        (
                                                                            content,
                                                                            '\n'
                                                                        );

            sw.Reset();
            //ConsoleOutput(csv_parsed);
            //-----------------------------------------------------------------------------------------
            // Assert
            int count = lines.Count();
            int count_correct = 9;
#if NUNIT
            Assert.AreEqual(count, count_correct);
#elif XUNIT
            Assert.Equal(count, count_correct);
#elif MSTEST
            Assert.AreEqual(count, count_correct);
#endif

            string[] lines_assert = new string[]
            {
                "\r",
                "                11,12,13,14,15,16,17,18,19,110,111,112,113\r",
                "                11,12,13,14,15,16,17,18,19,110,111,112,113\r",
                "                21,22,23,24,25,26,27,28,29,210,211,212,213\r",
                "                31,32,33,34,35,36,37,38,39,310,311,312,313\r",
                "                31,32,33,34,35,36,37,38,39,310,311,312,313\r",
                "                31,32,33,34,35,36,37,38,39,310,311,312,313\r",
                "                41,42,43,44,45,46,47,48,49,410,411,412,413\r",
                "                "
            };
#if NUNIT && !NUNIT_LITE
            CollectionAssert.AreEquivalent
                        (
                            lines_assert.ToList(),
                            lines
                        );
#elif XUNIT
            Assert.Equal
                        (
                            lines_assert.ToList(),
                            lines
                        );
#elif MSTEST
            CollectionAssert.AreEquivalent
                        (
                            lines_assert.ToList(),
                            lines.ToArray()
                        );
#endif
            //-----------------------------------------------------------------------------------------

            return;
        }

        [Test()]
        public void CharacterSeparatedValues_API_static_ParseLinesMemory_02()
        {
            //-----------------------------------------------------------------------------------------
            // Arrange
            string content =
                @"
                11,12,13,14,15,16,17,18,19,110,111,112,113
                11,12,13,14,15,16,17,18,19,110,111,112,113
                21,22,23,24,25,26,27,28,29,210,211,212,213
                31,32,33,34,35,36,37,38,39,310,311,312,313
                31,32,33,34,35,36,37,38,39,310,311,312,313
                31,32,33,34,35,36,37,38,39,310,311,312,313
                41,42,43,44,45,46,47,48,49,410,411,412,413
                ";
            //-----------------------------------------------------------------------------------------
            // Act
            sw.Start();
            IEnumerable<string> lines = CharacterSeparatedValues.ParseLinesMemory
                                                                        (
                                                                            content,
                                                                            '\r'
                                                                        );

            sw.Reset();
            //ConsoleOutput(csv_parsed);
            //-----------------------------------------------------------------------------------------
            // Assert
            int count = lines.Count();
            int count_correct = 9;

#if NUNIT
            Assert.AreEqual(count, count_correct);
#elif XUNIT
            Assert.Equal(count, count_correct);
#elif MSTEST
            Assert.AreEqual(count, count_correct);
#endif

            //string[] lines_assert = new string[]
            //{
            //    @"
            //    11,12,13,14,15,16,17,18,19,110,111,112,113
            //    11,12,13,14,15,16,17,18,19,110,111,112,113
            //    21,22,23,24,25,26,27,28,29,210,211,212,213
            //    31,32,33,34,35,36,37,38,39,310,311,312,313
            //    31,32,33,34,35,36,37,38,39,310,311,312,313
            //    31,32,33,34,35,36,37,38,39,310,311,312,313
            //    41,42,43,44,45,46,47,48,49,410,411,412,413
            //    ",
            //};

            string[] lines_assert = new string[]
            {
                "",
                "\n                11,12,13,14,15,16,17,18,19,110,111,112,113",
                "\n                11,12,13,14,15,16,17,18,19,110,111,112,113",
                "\n                21,22,23,24,25,26,27,28,29,210,211,212,213",
                "\n                31,32,33,34,35,36,37,38,39,310,311,312,313",
                "\n                31,32,33,34,35,36,37,38,39,310,311,312,313",
                "\n                31,32,33,34,35,36,37,38,39,310,311,312,313",
                "\n                41,42,43,44,45,46,47,48,49,410,411,412,413",
                "\n                "
            };

#if NUNIT && !NUNIT_LITE
            CollectionAssert.AreEquivalent
                        (
                            lines_assert.ToList(),
                            lines
                        );
#elif XUNIT
            Assert.Equal
                        (
                            lines_assert.ToList(),
                            lines
                        );
#elif MSTEST
            CollectionAssert.AreEquivalent
                        (
                            lines_assert.ToList(),
                            lines.ToArray()
                        );
#endif
            //-----------------------------------------------------------------------------------------

            return;
        }

        [Test()]
        public void CharacterSeparatedValues_API_static_ParseLinesMemory_03()
        {
            //-----------------------------------------------------------------------------------------
            // Arrange
            string content =
                @"
                11,12,13,14,15,16,17,18,19,110,111,112,113
                11,12,13,14,15,16,17,18,19,110,111,112,113
                21,22,23,24,25,26,27,28,29,210,211,212,213
                31,32,33,34,35,36,37,38,39,310,311,312,313
                31,32,33,34,35,36,37,38,39,310,311,312,313
                31,32,33,34,35,36,37,38,39,310,311,312,313
                41,42,43,44,45,46,47,48,49,410,411,412,413
                ";
            //-----------------------------------------------------------------------------------------
            // Act
            sw.Start();
            IEnumerable<string> lines = CharacterSeparatedValues.ParseLinesMemory
                                                                        (
                                                                            content,
                                                                            Environment.NewLine
                                                                        );
            var t = lines.ToArray();

            sw.Reset();
            //ConsoleOutput(csv_parsed);
            //-----------------------------------------------------------------------------------------
            // Assert
            int count = lines.Count();
            int count_correct = 17;
            #if NUNIT
            Assert.AreEqual(count, count_correct);
            #elif XUNIT
            Assert.Equal(count, count_correct);
            #elif MSTEST
            Assert.AreEqual(count, count_correct);
            #endif

            string[] lines_assert = new string[]
            {
                "",
                "",
                "                11,12,13,14,15,16,17,18,19,110,111,112,113",
                "",
                "                11,12,13,14,15,16,17,18,19,110,111,112,113",
                "",
                "                21,22,23,24,25,26,27,28,29,210,211,212,213",
                "",
                "                31,32,33,34,35,36,37,38,39,310,311,312,313",
                "",
                "                31,32,33,34,35,36,37,38,39,310,311,312,313",
                "",
                "                31,32,33,34,35,36,37,38,39,310,311,312,313",
                "",
                "                41,42,43,44,45,46,47,48,49,410,411,412,413",
                "",
                "                "
            };
            #if NUNIT && !NUNIT_LITE
            CollectionAssert.AreEquivalent
                        (
                            lines_assert.ToList(),
                            lines
                        );
#elif XUNIT
            Assert.Equal
                        (
                            lines_assert.ToList(),
                            lines
                        );
#elif MSTEST
            CollectionAssert.AreEquivalent
                        (
                            lines_assert.ToList(),
                            lines.ToArray()
                        );
#endif
            //-----------------------------------------------------------------------------------------

            return;
        }
    }
}
