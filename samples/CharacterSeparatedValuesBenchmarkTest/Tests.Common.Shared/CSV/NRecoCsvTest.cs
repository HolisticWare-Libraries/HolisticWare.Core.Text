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

    }
}
