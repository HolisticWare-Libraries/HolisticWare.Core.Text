using System;
using System.Collections.Generic;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;

using Core.Text;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class CharacterSeparatedValuesTest : TestBase
    {

        [Benchmark]
        public void CharacterSeparatedValues_Parse_File_String()
        {
            CharacterSeparatedValues.ParseFile("androidx-class-mapping.csv", '\n');
        }

        [Benchmark]
        public void CharacterSeparatedValues_Parse_File_Memory()
        {
            CharacterSeparatedValues.ParseFileMemory("androidx-class-mapping.csv", '\n');
        }

        IEnumerable<string> Lines = null;

        [Benchmark]
        public void CharacterSeparatedValues_ParseLines_String()
        {
            Lines = CharacterSeparatedValues.ParseLines(Text, '\n');
        }

        [Benchmark]
        public void CharacterSeparatedValues_ParseLines_Memory()
        {
            Lines = CharacterSeparatedValues.ParseLinesMemory(Text, '\n');
        }

    }
}
