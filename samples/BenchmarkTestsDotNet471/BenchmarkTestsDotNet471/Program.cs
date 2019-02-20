using System;
using System.Collections.Generic;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;
using BenchmarkTestsDotNet471.Extensions;

namespace BenchmarkTestsDotNet471
{
    [MemoryDiagnoser]
    public class SplitTests
    {
        private string Text { get; set; }
        private readonly Consumer consumer = new Consumer();

        [GlobalSetup]
        public void Setup()
        {
            Text = LoadDataFromFile(new string[] { $@"androidx-packagename-mapping.csv", });
        }

        [Benchmark]
        public void SplitStringWithStringParametersOriginal()
        {
            Text.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Consume(consumer);
        }

        [Benchmark]
        public void SplitWithMemoryWithStringParametersCustom()
        {
            Text.MemorySplit(new string[] { "," }).Consume(consumer);
        }

        [Benchmark]
        public void SplitStringOriginal()
        {
            Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Consume(consumer);
        }

        [Benchmark]
        public void SplitWithSpan()
        {
            Text.AsSpan().Split(new char[] { ',' });
        }

        [Benchmark]
        public void SplitWithMemory()
        {
            Text.AsMemory().Split(new char[] { ',' });
        }

        /// <summary>
        /// Load data from file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string LoadDataFromFile(string[] path)
        {
            // Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string directory_test = System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString(); 

            List<string> path_combined = new List<string>() { directory_test };
            path_combined.AddRange(path);
            string path_file = Path.Combine(path_combined.ToArray());

            string content = System.IO.File.ReadAllText(path_file);

            return content;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<SplitTests>();
            
            Console.ReadKey();
        }
    }
}
