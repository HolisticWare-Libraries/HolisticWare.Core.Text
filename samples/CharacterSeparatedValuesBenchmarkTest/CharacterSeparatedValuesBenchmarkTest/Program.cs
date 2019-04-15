using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;
using Core.Text;

namespace CharacterSeparatedValuesBenchmarkTest
{
    [MemoryDiagnoser]
    public class CharacterSeparatedValuesTest
    {
        private string Text { get; set; }
        private readonly Consumer consumer = new Consumer();

        [GlobalSetup]
        public void Setup()
        {
            Text = LoadDataFromFile(new string[] { $@"androidx-class-mapping.csv", });
        }

        [Benchmark]
        public void CSV_ParseLine()
        {
            CharacterSeparatedValues.ParseLine(Text, ',');
        }

        [Benchmark]
        public void CSV_ParseLine_Memory()
        {
            CharacterSeparatedValues.ParseLineMemory(Text, ',');
        }

        [Benchmark]
        public void CSV_ParseLines()
        {
            CharacterSeparatedValues.ParseLines(Text, '\n');
        }

        [Benchmark]
        public void CSV_ParseLines_Memory()
        {
            CharacterSeparatedValues.ParseLinesMemory(Text, '\n');
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
    class MainClass
    {
        public static void Main(string[] args)
        {
            // var data = LoadDataFromFile(new string[] { $@"androidx-class-mapping.csv", });
            BenchmarkRunner.Run<CharacterSeparatedValuesTest>();
            // var test = CharacterSeparatedValues.ParseLine(data, ',');

            // Console.WriteLine("***************************** PARSE LINE");
            // Console.WriteLine(string.Join(Environment.NewLine, test));
            // var testMemory = CharacterSeparatedValues.ParseLineMemory(data, ',');
            // Console.WriteLine("***************************** PARSE LINE MEMORY");
            // Console.WriteLine(string.Join(Environment.NewLine, testMemory));
            Console.ReadKey();
        }

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

