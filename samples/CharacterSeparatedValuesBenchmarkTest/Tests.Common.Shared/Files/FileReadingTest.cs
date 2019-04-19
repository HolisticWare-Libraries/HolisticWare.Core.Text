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
    public class FileReadingTests
    {
        string Text = null;
        string filename = $@"androidx-class-mapping.csv";

        string[] lines = null;

        [Benchmark]
        public void StreamReader()
        {
            using (StreamReader streamReader = File.OpenText(filename))
            {
                lines = streamReader.ReadToEnd()
                                    .Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }
        }

        [Benchmark]
        public void File_ReadLines()
        {
            lines = File.ReadAllLines(filename);
        }

        [Benchmark]
        public void FileStream_With_StreamReader()
        {
            lines = FileStream_With_StreamReader_Impl().ToArray();
        }

        public IEnumerable<string> FileStream_With_StreamReader_Impl()
        {
            const Int32 BufferSize = 4_096; // NTFS

            using (FileStream fs = File.OpenRead(filename))
            using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.UTF8, true, BufferSize))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    // Process line
                    yield return line;
                }
            }
        }
    }
}
