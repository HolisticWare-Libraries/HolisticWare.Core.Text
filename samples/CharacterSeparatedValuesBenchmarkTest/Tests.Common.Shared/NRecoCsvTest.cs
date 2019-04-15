using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;

using Core.Text;


namespace Benchmarks
{
    /// <summary>
    /// https://bytefish.de/blog/tinycsvparser/
    /// </summary>
    public class NRecoCsvTest
    {
        private string TextContent { get; set; }
        private string TextResource { get; set; }        
        private string Text { get; set; }

        private readonly Consumer consumer = new Consumer();

        [GlobalSetup]
        public void Setup()
        {
            TextContent = LoadDataFromFile(new string[] { $@"androidx-class-mapping.csv", });
            TextResource = LoadDataFromEmbeddedResource($@"androidx-class-mapping.1.csv");

            #if !NETCOREAPP
            Text = TextContent;
            #else
            Text = TextResource;
            #endif
        }

        [Benchmark]
        public void Parse_File()
        {
            using (TextReader sr = new StringReader(Text))
            {
                var csvReader = new NReco.Csv.CsvReader(sr, ",");
                while (csvReader.Read())
                {
                    for (int i = 0; i < csvReader.FieldsCount; i++)
                    {
                        string val = csvReader[i];
                    }
                }
            }
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

        public static string LoadDataFromEmbeddedResource(string name)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var resourceName = "MyCompany.MyProduct.MyFile.txt";

            string result = null;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }

    }
}
