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
using TestContext = HolisticWare.Core.Testing.UnitTests.TestContext;
#elif NUNIT
using NUnit.Framework;
// MSTest aliases
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestProperty = NUnit.Framework.PropertyAttribute;
using TestClass = HolisticWare.Core.Testing.UnitTests.UnitTestsCompatibilityAliasAttribute;
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
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Attributes.Jobs;
#else
using Benchmark = HolisticWare.Core.Testing.BenchmarkTests.Benchmark;
using ShortRunJob = HolisticWare.Core.Testing.BenchmarkTests.ShortRunJob;
#endif

using System.Linq;

using Core.Text.Transformations;

namespace UnitTests.Core.Text.Transformations
{
    [TestClass] // for MSTest - NUnit [TestFixture] and XUnit not needed
    public partial class Test_PascalCase
    {
        [Test]
        public void Test_string_extension_method_ToPascalCase_01()
        {
            string pascal_case = "com.google.android.material".ToPascalCase();

            #if MSTEST
            Assert.AreEqual("ComGoogleAndroidMaterial", pascal_case);
            #elif NUNIT
            Assert.AreEqual("ComGoogleAndroidMaterial", pascal_case);
            #elif XUNIT
            Assert.Equal("ComGoogleAndroidMaterial", pascal_case);
            #endif

            return;
        }

        [Test]
        public void Test_string_array_extension_method_ToPascalCase_01()
        {
            string[] pascal_case = "com.google.android.material"
                                    .Split(new string[] { "." }, System.StringSplitOptions.RemoveEmptyEntries )
                                    .ToPascalCase()
                                    .ToArray();

            #if MSTEST
            CollectionAssert.AreEqual
                    (
                        new string[] { "Com", "Google", "Android", "Material" },
                        pascal_case
                    );
            #elif NUNIT
            Assert.AreEqual
                    (
                        new string[] { "Com", "Google", "Android", "Material" },
                        pascal_case
                    );
            #elif XUNIT
            Assert.Equal
                    (
                        new string[] { "Com", "Google", "Android", "Material" },
                        pascal_case
                    );
            #endif

            return;
        }


        [Test]
        public void Test_string_extension_method_ToPascalCase_02()
        {
            string pascal_case = "androidx.activity".ToPascalCase();

            #if MSTEST
            Assert.AreEqual("AndroidxActivity", pascal_case);
            #elif NUNIT
            Assert.AreEqual("AndroidxActivity", pascal_case);
            #elif XUNIT
            Assert.Equal("AndroidxActivity", pascal_case);
            #endif

            return;
        }

        [Test]
        public void Test_string_array_extension_method_ToPascalCase_02()
        {
            string[] pascal_case = "androidx.activity"
                                    .Split(new string[] { "." }, System.StringSplitOptions.RemoveEmptyEntries)
                                    .ToPascalCase()
                                    .ToArray();

            #if MSTEST
            CollectionAssert.AreEqual
                    (
                        new string[] { "Androidx", "Activity" },
                        pascal_case
                    );
            #elif NUNIT
            Assert.AreEqual
                    (
                        new string[] { "Androidx", "Activity" },
                        pascal_case
                    );
            #elif XUNIT
            Assert.Equal
                    (
                        new string[] { "Androidx", "Activity" },
                        pascal_case
                    );
            #endif

            return;
        }



        [Test]
        public void Test_string_extension_method_ToPascalCase_03()
        {
            string pascal_case = "com.google.crypto.tink.tink-android".ToPascalCase();

            #if MSTEST
            Assert.AreEqual("ComGoogleCryptoTinkTinkAndroid", pascal_case);
            #elif NUNIT
            Assert.AreEqual("ComGoogleCryptoTinkTinkAndroid", pascal_case);
            #elif XUNIT
            Assert.Equal("ComGoogleCryptoTinkTinkAndroid", pascal_case);
            #endif

            return;
        }

        [Test]
        public void Test_string_array_extension_method_ToPascalCase_03()
        {
            string[] pascal_case = "com.google.crypto.tink.tink-android"
                                    .Split(new string[] { "." }, System.StringSplitOptions.RemoveEmptyEntries)
                                    .ToPascalCase()
                                    .ToArray();

            #if MSTEST
            CollectionAssert.AreEqual
                    (
                        new string[] { "Com", "Google", "Crypto", "Tink", "TinkAndroid" },
                        pascal_case
                    );
            #elif NUNIT
            Assert.AreEqual
                    (
                        new string[] { "Com", "Google", "Crypto", "Tink", "TinkAndroid" },
                        pascal_case
                    );
            #elif XUNIT
            Assert.Equal
                    (
                        new string[] { "Com", "Google", "Crypto", "Tink", "TinkAndroid" },
                        pascal_case
                    );
            #endif

            return;
        }
    }
}
