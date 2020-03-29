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
    [RankColumn]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class FileReadingTests : TestBase
    {
        string filename = $@"androidx-class-mapping.csv";

        string[] lines_strings = null;
        IEnumerable<ReadOnlyMemory<char>> lines_memory_of_chars;

        [Benchmark]
        public void StreamReader()
        {
            using (StreamReader streamReader = File.OpenText(filename))
            {
                lines_strings = streamReader.ReadToEnd()
                                    .Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }
        }

        [Benchmark]
        public void File_ReadAllLines()
        {
            lines_strings = File.ReadAllLines(filename);
        }

        [Benchmark]
        public void FileStream_With_StreamReader_Strings()
        {
            lines_strings = FileStream_With_StreamReader_Strings_Impl().ToArray();
        }

        [Benchmark]
        public string StreamReader_Returning_String()
        {
            using (StreamReader sr = File.OpenText(filename))
            {
                string s = sr.ReadToEnd();

                return s;
            }
        }

        [Benchmark]
        public string StreamReader_StringBuilder_Returning_String()
        {
            using (StreamReader sr = File.OpenText(filename))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(sr.ReadToEnd());

                return sb.ToString();
            }
        }

        [Benchmark]
        public void StreamReader_String_Returning_IEnumerable_Of_String()
        {
            lines_strings = StreamReader_String_Returning_IEnumerable_Of_String_Impl().ToArray();
        }

        public IEnumerable<string> StreamReader_String_Returning_IEnumerable_Of_String_Impl()
        {
            using (StreamReader sr = File.OpenText(filename))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    yield return s;
                }
            }
        }

        [Benchmark]
        public void FileStream_BufferedStream_StreamReader_String_Returning_IEnumerable_Of_String()
        {
            lines_strings = FileStream_BufferedStream_StreamReader_String_Returning_IEnumerable_Of_String_Impl().ToArray();
        }

        public IEnumerable<string> FileStream_BufferedStream_StreamReader_String_Returning_IEnumerable_Of_String_Impl()
        {
            using (FileStream fs = File.Open(filename, FileMode.Open, FileAccess.Read))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    yield return s;
                }
            }
        }

        [Benchmark]
        public void FileStream_BufferedStream_Allocated_StreamReader_String_Returning_IEnumerable_Of_String()
        {
            lines_strings = FileStream_BufferedStream_Allocated_StreamReader_String_Returning_IEnumerable_Of_String_Impl().ToArray();
        }

        public IEnumerable<string> FileStream_BufferedStream_Allocated_StreamReader_String_Returning_IEnumerable_Of_String_Impl()
        {
            char[] g = new char[1024];

            using (FileStream fs = File.Open(filename, FileMode.Open, FileAccess.Read))
            using (BufferedStream bs = new BufferedStream(fs, System.Text.ASCIIEncoding.Unicode.GetByteCount(g)))
            using (StreamReader sr = new StreamReader(bs))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    yield return s;
                }
            }
        }

        [Benchmark]
        public void StreamReader_StringBuilder_Returning_IEnumerable_Of_String()
        {
            lines_strings = StreamReader_StringBuilder_Returning_IEnumerable_Of_String_Impl().ToArray();
        }

        public IEnumerable<string> StreamReader_StringBuilder_Returning_IEnumerable_Of_String_Impl()
        {
            using (StreamReader sr = File.OpenText(filename))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                while (sb.Append(sr.ReadLine()).Length > 0)
                {
                    yield return sb.ToString();
                    sb.Clear();
                }
            }
        }

        [Benchmark]
        public void StreamReader_BufferedStream_StreamReader_String_Returning_IEnumerable_Of_String()
        {
            lines_strings = StreamReader_BufferedStream_StreamReader_String_Returning_IEnumerable_Of_String_Impl().ToArray();
        }

        public IEnumerable<string> StreamReader_BufferedStream_StreamReader_String_Returning_IEnumerable_Of_String_Impl()
        {
            char[] g = new char[1024];

            using (StreamReader sr = File.OpenText(filename))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(g.Length);
                while (sb.Append(sr.ReadLine()).Length > 0)
                {
                    yield return sb.ToString();
                    sb.Clear();
                }
            }
        }

        int MAX = 4096;

        [Benchmark]
        public string[] FStreamReader_BufferedStream_StreamReader_String_Returning_Arrayixed()
        {
            var AllLines = new string[MAX];
            using (StreamReader sr = File.OpenText(filename))
            {
                int i = 0;
                while (!sr.EndOfStream)
                {
                    //we're just testing read speeds
                    AllLines[i] = sr.ReadLine();
                    i += 1;
                }
            }

            return AllLines;
        }

        [Benchmark]
        public string[] File_Returning_ArrayFixed()
        {
            var AllLines = new string[MAX];
            AllLines = File.ReadAllLines(filename);

            return AllLines;
        }

        public IEnumerable<string> FileStream_With_StreamReader_Strings_Impl()
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

        //----------------------------------------------------------------------------------------------------
        [Benchmark]
        public void FileStream_With_StreamReader()
        {
            lines_strings = FileStream_With_StreamReader_Strings_Impl().ToArray();
        }

        public IEnumerable<ReadOnlyMemory<char>> FileStream_With_StreamReader_MemoryOfChar_Impl()
        {
            const Int32 BufferSize = 4_096; // NTFS

            using (FileStream fs = File.OpenRead(filename))
            using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.UTF8, true, BufferSize))
            {
                string line;
                while ( (line = sr.ReadLine()) != null )
                {
                    yield return line.AsMemory();
                }
            }
        }
        //----------------------------------------------------------------------------------------------------

        //----------------------------------------------------------------------------------------------------
        [Benchmark]
        public void FileStream_BufferedStream_StreamReader_Strings()
        {
            lines_strings = FileStream_With_StreamReader_Strings_Impl().ToArray();
        }

        public IEnumerable<string> FileStream_BufferedStream_StreamReader_Strings_Impl()
        {
            using (FileStream fs = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
        //----------------------------------------------------------------------------------------------------

        //----------------------------------------------------------------------------------------------------
        [Benchmark]
        public void FileStream_BufferedStream_StreamReader_ReadLine_MemoryOfChar()
        {
            lines_memory_of_chars = FileStream_BufferedStream_StreamReader_ReadLine_MemoryOfChar_Impl().ToArray();
        }

        public IEnumerable<ReadOnlyMemory<char>> FileStream_BufferedStream_StreamReader_ReadLine_MemoryOfChar_Impl()
        {
            using (FileStream fs = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    yield return line.AsMemory();
                }
            }
        }
        //----------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------
        [Benchmark]
        public void FileStream_BufferedStream_StreamReader_ReadBlock_MemoryOfChar()
        {
            lines_memory_of_chars = FileStream_BufferedStream_StreamReader_ReadBlock_MemoryOfChar_Impl();
        }

        public IEnumerable<ReadOnlyMemory<char>> FileStream_BufferedStream_StreamReader_ReadBlock_MemoryOfChar_Impl()
        {
            using (FileStream fs = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                Memory<char> line = new Memory<char>();
                int length = sr.ReadBlock(line.Span);
                while ( length > 0 )
                {
                    yield return line.ToArray().AsMemory();
                }
            }
        }
        //----------------------------------------------------------------------------------------------------

        /*
        private const char CR = '\r';  
        private const char LF = '\n';  
        private const char NULL = (char)0;


        public static long CountLinesSmarter(Stream stream)  
        {
            //Ensure.NotNull(stream, nameof(stream));

            var lineCount = 0L;

            byte[] byteBuffer = new byte[1024 * 1024];
            char detectedEOL = NULL;
            char currentChar = NULL;

            int bytesRead;
            while ((bytesRead = stream.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
            {
                for (var i = 0; i < bytesRead; i++)
                {
                    currentChar = (char)byteBuffer[i];

                    if (detectedEOL != NULL)
                    {
                        if (currentChar == detectedEOL)
                        {
                            lineCount++;
                        }
                    }
                    else if (currentChar == LF || currentChar == CR)
                    {
                        detectedEOL = currentChar;
                        lineCount++;
                    }
                }
            }

            // We had a NON-EOL character at the end without a new line
            if (currentChar != LF && currentChar != CR && currentChar != NULL)
            {
                lineCount++;
            }
            return lineCount;
        }
        */
        /*
        private int _bufferSize = 16384;

        private void ReadFile(string filename)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);

            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                char[] fileContents = new char[_bufferSize];
                int charsRead = streamReader.Read(fileContents, 0, _bufferSize);

                // Can't do much with 0 bytes
                if (charsRead == 0)
                    throw new Exception("File is 0 bytes");

                while (charsRead > 0)
                {
                    stringBuilder.Append(fileContents);
                    charsRead = streamReader.Read(fileContents, 0, _bufferSize);
                }
            }
        }


        public static IEnumerable<int> LoadFileWithProgress(string filename, StringBuilder stringData)
        {
            const int charBufferSize = 4096;
            using (FileStream fs = File.OpenRead(filename))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    long length = fs.Length;
                    int numberOfChunks = Convert.ToInt32((length / charBufferSize)) + 1;
                    double iter = 100 / Convert.ToDouble(numberOfChunks);
                    double currentIter = 0;
                    yield return Convert.ToInt32(currentIter);
                    while (true)
                    {
                        char[] buffer = br.ReadChars(charBufferSize);
                        if (buffer.Length == 0) break;
                        stringData.Append(buffer);
                        currentIter += iter;
                        yield return Convert.ToInt32(currentIter);
                    }
                }
            }
        }
        */
    }
}
