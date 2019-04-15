using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;

using Core.Text;
using TinyCsvParser;

namespace Benchmarks
{
    /// <summary>
    /// https://bytefish.de/blog/tinycsvparser/
    /// </summary>
    public class TinyCsvParserTest
    {
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime BirthDate { get; set; }
        }

        public class CsvPersonMapping : TinyCsvParser.Mapping.CsvMapping<Person>
        {
            public CsvPersonMapping()
                : base()
            {
                MapProperty(0, x => x.FirstName);
                MapProperty(1, x => x.LastName);
                MapProperty(2, x => x.BirthDate);
            }
        }

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
            TinyCsvParser.CsvParserOptions csvParserOptions = new TinyCsvParser.CsvParserOptions(true, ';');
            TinyCsvParser.CsvReaderOptions csvReaderOptions = new TinyCsvParser.CsvReaderOptions(new[] { Environment.NewLine });
            CsvPersonMapping csvMapper = new CsvPersonMapping();
            TinyCsvParser.CsvParser<Person> csvParser = new TinyCsvParser.CsvParser<Person>(csvParserOptions, csvMapper);

            var stringBuilder = new System.Text.StringBuilder()
                .AppendLine("FirstName;LastName;BirthDate")
                .AppendLine("Philipp;Wagner;1986/05/12")
                .AppendLine("Max;Mustermann;2014/01/01");

            var result = csvParser
                            .ReadFromString(csvReaderOptions, stringBuilder.ToString())
                            .ToList();
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
