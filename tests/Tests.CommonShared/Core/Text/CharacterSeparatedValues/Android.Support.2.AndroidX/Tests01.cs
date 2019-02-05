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
using System.IO;
using System.Reflection;

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

using Core.Text;

namespace UnitTests.Core.Text.CharacterSeparatedValuesSamples.AndroidSupport2AndroidX
{
    public partial class Tests01
    {
#if NUNIT
        [SetUp] 
        public void Init()
        {
        TextContent = LoadDataFromFile
                                            (
                                                new string[]
                                                {
                                                    //directory_test,
                                                    $@"mappings",
                                                    $@"google-readonly-1-baseline",
                                                    $@"androidx-class-mapping.csv",
                                                }

                                            );
        }
#elif XUNIT
            public Tests01 ()
	        {
                TextContent = LoadDataFromFile
                                            (
                                                new string[]
                                                {
                                                    //directory_test,
                                                    $@"mappings",
                                                    $@"google-readonly-1-baseline",
                                                    $@"androidx-class-mapping.csv",
                                                }

                                            );
	        }
#elif MSTEST
        [TestInitialize]
        public void Init()
        {
            TextContent = LoadDataFromFile
                                            (
                                                new string[]
                                                {
                                                    //directory_test,
                                                    $@"mappings",
                                                    $@"google-readonly-1-baseline",
                                                    $@"androidx-class-mapping.csv",
                                                }

                                            );
        }
#endif
        public string TextContent { get; set; }

        private Stopwatch sw = new Stopwatch();

        private static string LoadDataFromFile(string[] path)
        {
            #if NUNIT
            string directory_test = TestContext.CurrentContext.TestDirectory;
            #elif XUNIT
            string directory_test = Environment.CurrentDirectory;
            #elif MSTEST
            string directory_test = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            #endif

            List<string> path_combined = new List<string>() { directory_test };
            path_combined.AddRange(path);
            string path_file = Path.Combine(path_combined.ToArray());

            string content = System.IO.File.ReadAllText(path_file);

            return content;
        }


        private static void ConsoleOutput(IEnumerable<IEnumerable<string>> data)
        {
            int i_row = 0;
            int n_rows = data.Count();

            foreach (IEnumerable<string> row_items in data)
            {
                Console.Write($" row[{i_row}] = ");
                int n_items = row_items.Count();
                for (int i = 0; i < n_items; i++)
                {
                    Console.Write($" {i} = {row_items.ElementAt(i)}");
                }
                Console.WriteLine();
                i_row++;
            }
        }
    }
}
