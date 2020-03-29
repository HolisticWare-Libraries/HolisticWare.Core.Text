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
using HolisticWare.Core.Testing.BenchmarkTests;

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
        public class CustomType
        {
            public string   S00;
            public string   S01;
            public string   S02;
            public string   S03;
            public string   S04;
            public string   S05;
            public int      i01;
        }

        string line = null;
        
        IEnumerable<string>     line_parts = null;
        IEnumerable<string>     strongly_typed_line_01 = null;
        CustomType              strongly_typed_line_02 = null;

        [Benchmark]
        public IEnumerable<string> CharacterSeparatedValues_API_static_ConvertLine_01_Atomic()
        {
            line_parts = CharacterSeparatedValues.ParseLine(line,',');
            strongly_typed_line_01 = CharacterSeparatedValues
                                                    .ConvertLine<IEnumerable<string>>
                                                                            (
                                                                                line_parts
                                                                            );

            return strongly_typed_line_01;
        }

        [Test()]
        public void CharacterSeparatedValues_API_static_ConvertLine_01()
        {
            //-----------------------------------------------------------------------------------------
            // Arrange
            line = "1,2,3,4,5,6,7,8,9,10,11,12,13";
            //-----------------------------------------------------------------------------------------
            // Act
            sw.Start();

            IEnumerable<string> result = CharacterSeparatedValues_API_static_ConvertLine_01_Atomic();

            sw.Reset();
            //ConsoleOutput(csv_parsed);
            //-----------------------------------------------------------------------------------------
            // Assert
            int count = result.Count();
            #if NUNIT
            Assert.AreEqual(count, 13);
            #elif XUNIT
            Assert.Equal(count, 13);
            #elif MSTEST
            Assert.AreEqual(count, 14);
            #endif

            string[] line_parts_assert = new string[]
            {
                "1", "2", "3", "4", "5", "6", "7",
                "8", "9", "10", "11", "12", "13", 
            };
            #if NUNIT && !NUNIT_LITE
            CollectionAssert.AreEquivalent
                        (
                            line_parts_assert.ToList(),
                            result
                        );
            #elif XUNIT
            Assert.Equal
                        (
                            line_parts_assert.ToList(),
                            result
                        );
            #elif MSTEST
            CollectionAssert.AreEquivalent
                        (
                            line_parts_assert.ToList(),
                            result.ToArray()
                        );
            #endif
            //-----------------------------------------------------------------------------------------

            return;
        }

        [Benchmark]
        public CustomType CharacterSeparatedValues_API_static_ConvertLine_02_Atomic()
        {
            line_parts = CharacterSeparatedValues.ParseLine(line,',');
            strongly_typed_line_02 = CharacterSeparatedValues
                                                    .ConvertLine<CustomType>
                                                                            (
                                                                                line_parts,
                                                                                items =>
                                                                                {
                                                                                    return new CustomType
                                                                                    {
                                                                                        S00 = items.ElementAt(0),
                                                                                        S01 = items.ElementAt(1),
                                                                                        S02 = items.ElementAt(2),
                                                                                        S03 = items.ElementAt(3),
                                                                                        i01 = int.Parse(items.ElementAt(1))
                                                                                    };                                                                                         
                                                                                }
                                                                            );

            return strongly_typed_line_02;
        }

        [Test()]
        public void CharacterSeparatedValues_API_static_ConvertLine_02()
        {
            //-----------------------------------------------------------------------------------------
            // Arrange
            line = "1,2,3,4,5,6,7,8,9,10,11,12,13";
            //-----------------------------------------------------------------------------------------
            // Act
            sw.Start();

            CustomType result = CharacterSeparatedValues_API_static_ConvertLine_02_Atomic();

            sw.Reset();
            //ConsoleOutput(csv_parsed);
            //-----------------------------------------------------------------------------------------
            // Assert
            #if NUNIT
            Assert.AreEqual(2, result.i01);
            Assert.AreEqual("1", result.S00);
            Assert.AreEqual("2", result.S01);
            Assert.AreEqual("3", result.S02);
            Assert.AreEqual("4", result.S03);
            #elif XUNIT
            Assert.Equal(2, result.i01);
            Assert.Equal("1", result.S00);
            Assert.Equal("2", result.S01);
            Assert.Equal("3", result.S02);
            Assert.Equal("4", result.S03);
            #elif MSTEST
            Assert.AreEqual(2, result.i01);
            Assert.AreEqual("1", result.S00);
            Assert.AreEqual("2", result.S01);
            Assert.AreEqual("3", result.S02);
            Assert.AreEqual("4", result.S03);
            #endif
            //-----------------------------------------------------------------------------------------

            return;
        }

        [Benchmark]
        public IEnumerable<string> CharacterSeparatedValues_API_static_ConvertLine_11_Atomic()
        {
            line_parts = CharacterSeparatedValues.ParseLine(line, ',');
            strongly_typed_line_01 = CharacterSeparatedValues
                                                                .ConvertLine<IEnumerable<string>>
                                                                                        (
                                                                                            line_parts
                                                                                        );

            return strongly_typed_line_01;
        }

        [Test()]
        public void CharacterSeparatedValues_API_static_ConvertLine_11()
        {
            //-----------------------------------------------------------------------------------------
            // Arrange
            line = "1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0,11.0,12.2,13.3";
            //-----------------------------------------------------------------------------------------
            // Act
            sw.Start();

            IEnumerable<string> result = CharacterSeparatedValues_API_static_ConvertLine_11_Atomic();

            sw.Reset();
            //ConsoleOutput(csv_parsed);
            //-----------------------------------------------------------------------------------------
            // Assert
            int count = result.Count();
            #if NUNIT
            Assert.AreEqual(count, 13);
            #elif XUNIT
            Assert.Equal(count, 13);
            #elif MSTEST
            Assert.AreEqual(count, 14);
            #endif

            string[] line_parts_assert = new string[]
            {
                "1.0", "2.0", "3.0", "4.0", "5.0", "6.0", "7.0",
                "8.0", "9.0", "10.0", "11.0", "12.2", "13.3", 
            };
            #if NUNIT && !NUNIT_LITE
            CollectionAssert.AreEquivalent
                        (
                            line_parts_assert.ToList(),
                            result
                        );
            #elif XUNIT
            Assert.Equal
                        (
                            line_parts_assert.ToList(),
                            result
                        );
            #elif MSTEST
            CollectionAssert.AreEquivalent
                        (
                            line_parts_assert.ToList(),
                            result.ToArray()
                        );
            #endif
            //-----------------------------------------------------------------------------------------

            return;
        }

        [Benchmark]
        public CustomType CharacterSeparatedValues_API_static_ConvertLine_12_Atomic()
        {
            line_parts = CharacterSeparatedValues.ParseLine(line, ',');
            strongly_typed_line_02 = CharacterSeparatedValues
                                                        .ConvertLine<CustomType>
                                                                                (
                                                                                    line_parts,
                                                                                    items =>
                                                                                    {
                                                                                        return new CustomType
                                                                                        {
                                                                                            S00 = items.ElementAt(0),
                                                                                            S01 = items.ElementAt(1),
                                                                                            S02 = items.ElementAt(2),
                                                                                            S03 = items.ElementAt(3),
                                                                                            i01 = int.Parse(items.ElementAt(1))
                                                                                        };                                                                                         
                                                                                    }
                                                                                );

            return strongly_typed_line_02;
        }

        [Test()]
        public void CharacterSeparatedValues_API_static_ConvertLine_12()
        {
            //-----------------------------------------------------------------------------------------
            // Arrange
            line = "1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0,11.0,12.2,13.3";
            //-----------------------------------------------------------------------------------------
            // Act
            sw.Start();

            CustomType result = CharacterSeparatedValues_API_static_ConvertLine_12_Atomic();

            sw.Reset();
            //ConsoleOutput(csv_parsed);
            //-----------------------------------------------------------------------------------------
            // Assert
            #if NUNIT
            Assert.AreEqual(2, result.i01);
            Assert.AreEqual("1", result.S00);
            Assert.AreEqual("2", result.S01);
            Assert.AreEqual("3", result.S02);
            Assert.AreEqual("4", result.S03);
            #elif XUNIT
            Assert.Equal(2, result.i01);
            Assert.Equal("1", result.S00);
            Assert.Equal("2", result.S01);
            Assert.Equal("3", result.S02);
            Assert.Equal("4", result.S03);
            #elif MSTEST
            Assert.AreEqual(2, result.i01);
            Assert.AreEqual("1", result.S00);
            Assert.AreEqual("2", result.S01);
            Assert.AreEqual("3", result.S02);
            Assert.AreEqual("4", result.S03);
            #endif
            //-----------------------------------------------------------------------------------------


            return;
        }

    }
}
