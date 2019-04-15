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
    class MainClass
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmarks.CharacterSeparatedValuesTest>();


            // var data = LoadDataFromFile(new string[] { $@"androidx-class-mapping.csv", });
            // var test = CharacterSeparatedValues.ParseLine(data, ',');

            // Console.WriteLine("***************************** PARSE LINE");
            // Console.WriteLine(string.Join(Environment.NewLine, test));
            // var testMemory = CharacterSeparatedValues.ParseLineMemory(data, ',');
            // Console.WriteLine("***************************** PARSE LINE MEMORY");
            // Console.WriteLine(string.Join(Environment.NewLine, testMemory));
            Console.ReadKey();
        }
    }
}

