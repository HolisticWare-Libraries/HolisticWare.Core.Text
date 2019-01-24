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

#if XUNIT
using Xunit;
// NUnit aliases
using Test = Xunit.FactAttribute;
using OneTimeSetUp = HolisticWare.Core.Testing.UnitTests.UnitTestsCompatibilityAliasAttribute;
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
// XUnit aliases
using Fact = NUnit.Framework.TestAttribute;
#elif MSTEST
using Microsoft.VisualStudio.TestTools.UnitTesting;
// NUnit aliases
using Test = Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute;
using OneTimeSetUp = Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute;
// XUnit aliases
using Fact = Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute;
#endif

#if BENCHMARKDOTNET
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Attributes.Jobs;
#else
using Benchmark = HolisticWare.Core.Testing.BenchmarkTests.Benchmark;
using ShortRunJob = HolisticWare.Core.Testing.BenchmarkTests.ShortRunJob;
#endif

using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

using Core.Strings;

namespace UnitTests.Core.Text
{
    public partial class UnitTests20180416Splitting
    {
        [Test()]
        [Benchmark]
        public void Words()
        {
            // Assert
            string s =
                "Xamarin Essentials! To make Xamarin development easier!"
                +
                "Formerly known as Caboodle. Female toolbox."
                ;

            // Act
            ((string Word, int Position)[] Words, string WordLongest) words = s.Words();


            // Assert
            #if NUNIT
            Assert.AreEqual(words.WordLongest, "development");
            #elif XUNIT
            Assert.Equal(words.WordLongest, "development");
            #elif MSTEST
            #endif

            return;
        }

        [Test()]
        [Benchmark]
        public void Words_Perisan()
        {
            // Assert
            string s = "   منزل صغير" + " " +" منزل صغير";

            // Act
            ((string Word, int Position)[] Words, string WordLongest) words = s.Words();


            // Assert
            #if NUNIT
            Assert.AreEqual(words.WordLongest, "development");
            #elif XUNIT
            Assert.Equal(words.WordLongest, "development");
            #elif MSTEST
            #endif

            return;
        }

            [Test()]
        [Benchmark]
        public void Words_Arabic()
        {
            // Assert
            string s = "خانه کوچک" + " " + "خانه کوچک";

            // Act
            ((string Word, int Position)[] Words, string WordLongest) words = s.Words();


            // Assert
            #if NUNIT
            Assert.AreEqual(words.WordLongest, "development");
            #elif XUNIT
            Assert.Equal(words.WordLongest, "development");
            #elif MSTEST
            #endif

            return;
        }

        [Test()]
        [Benchmark]
        public void SplitForBufferNonOptimized_10()
        {
            // Assert
            string s =
                "Xamarin Essentials! To make Xamarin development easier!"
                +
                "Formerly known as Caboodle. Female toolbox."
                ;

            // Act
            IEnumerable<string> words = s.SplitForBufferNonOptimized(10, new string[] { " ", ".", "!" });


            // Assert
            #if NUNIT
            #elif XUNIT
            #elif MSTEST
            #endif

            return;
        }

            [Test()]
        [Benchmark]
        public void SplitForBufferNonOptimized_20()
        {
            // Assert
            string s =
                "Xamarin Essentials! To make Xamarin development easier!"
                +
                "Formerly known as Caboodle. Female toolbox."
                ;

            // Act
            IEnumerable<string> words = s.SplitForBufferNonOptimized(20, new string[] { " ", ".", "!" });


            // Assert
            #if NUNIT
            #elif XUNIT
            #elif MSTEST
            #endif

            return;
        }

        [Test()]
        [Benchmark]
        public void SplitForBufferNonOptimized_100()
        {
            // Assert
            string s =
                "Xamarin Essentials! To make Xamarin development easier!"
                +
                "Formerly known as Caboodle. Female toolbox."
                ;

            // Act
            IEnumerable<string> words = s.SplitForBufferNonOptimized(10, new string[] { " ", ".", "!" });


            // Assert
            #if NUNIT
            #elif XUNIT
            #elif MSTEST
            #endif

            return;
        }

        [Test()]
        [Benchmark]
        public void SplitForBufferNonOptimized_1000()
        {
            // Assert
            string s =
                "Xamarin Essentials! To make Xamarin development easier!"
                +
                "Formerly known as Caboodle. Female toolbox."
                ;

            // Act
            IEnumerable<string> words = s.SplitForBufferNonOptimized(1000, new string[] { " ", ".", "!" });


            // Assert
            #if NUNIT
            #elif XUNIT
            #elif MSTEST
            #endif

            return;
        }

        [Test()]
        [Benchmark]
        public void SplitForBuffer_BufferSize_200()
        {
            // Assert
            string s =
                "Xamarin Essentials! To make Xamarin development easier!"
                ;

            // Act
            List<string> parts = s.SplitForBuffer(200);


            // Assert
            #if NUNIT
            #elif XUNIT
            #elif MSTEST
            #endif

            return;
        }


        [Test()]
        public void SplitForBuffer_BufferSize_20()
        {
            // Assert
            string s =
                "Xamarin Essentials! To make Xamarin development easier!"
                ;

            // Act
            List<string> parts = s.SplitForBuffer(20);


            // Assert
            #if NUNIT
            #elif XUNIT
            #elif MSTEST
            #endif

            return;
        }

        [Test()]
        public void SplitForBuffer_BufferSize_10()
        {
            // Assert
            string s = 
                "Xamarin Essentials! To make Xamarin development easier!"
                ;

            // Act
            List<string> parts = s.SplitForBuffer(10);


            // Assert
            #if NUNIT
            #elif XUNIT
            #elif MSTEST
            #endif

            return;
        }

        [Test()]
        public void SplitForBuffer_BufferSize_5()
        {
            // Assert
            string s =
                "Xamarin Essentials! To make Xamarin development easier!"
                ;

            // Act
            List<string> parts = s.SplitForBuffer(5);


            // Assert
            #if NUNIT
            #elif XUNIT
            #elif MSTEST
            #endif

            return;
        }
    }
}
