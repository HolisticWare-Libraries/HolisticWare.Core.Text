using System;
using System.Collections.Generic;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;

using Core.Text;

namespace Benchmarks
{
    public class TextFieldParserTest
    {
        private string Text { get; set; }
        private readonly Consumer consumer = new Consumer();

        [GlobalSetup]
        public void Setup()
        {
            Text = LoadDataFromFile(new string[] { $@"androidx-class-mapping.csv", });
        }

        [Benchmark]
        public void Parse_File()
        {
            #if !NETCOREAPP
            using
                (
                    Microsoft.VisualBasic.FileIO.TextFieldParser parser =
                            new Microsoft.VisualBasic.FileIO.TextFieldParser(@"androidx-class-mapping.csv")
                )
            {
                parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Process row
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        //TODO: Process field
                    }
                }
            }
            #endif
        }

        /// <summary>
        /// Loads the data from file.
        /// </summary>
        /// <returns>The data from file.</returns>
        /// <param name="path">Path.</param>
        public static string LoadDataFromFile(string[] path)
        {
            // string directory_test = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string directory_test = System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString();

            List<string> path_combined = new List<string>() { directory_test };
            path_combined.AddRange(path);
            string path_file = Path.Combine(path_combined.ToArray());

            string content = System.IO.File.ReadAllText(path_file);

            return content;
        }

    }
}
