using System;
using System.Collections.Generic;
using System.IO;

namespace Benchmarks
{
    public class TestBase
    {
        protected string TextContent { get; set; }
        protected string TextResource { get; set; }        
        protected string Text { get; set; }
        protected readonly BenchmarkDotNet.Engines.Consumer consumer = new BenchmarkDotNet.Engines.Consumer();

        public TestBase()
        {
        }

        [BenchmarkDotNet.Attributes.GlobalSetup]
        public void Setup()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            string result = null;
            var f = assembly.GetManifestResourceNames();
            using (Stream stream = assembly.GetManifestResourceStream($@"Benchmarks.androidx-class-mapping.1.csv"))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            TextResource = result;

            TextContent = File.ReadAllText($@"androidx-class-mapping.csv");

            #if !NETCOREAPP
            Text = TextContent;
            #else
            Text = TextResource;
            #endif

            return;
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

            string content = null;
            try
            {
                content = System.IO.File.ReadAllText(path_file);
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            return content;
        }

        public static string LoadDataFromEmbeddedResource(string name)
        {
            return "result";
        }

    }
}
