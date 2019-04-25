using System;
using BenchmarkDotNet.Running;


namespace CharacterSeparatedValuesBenchmarkTest.dotnetcore
{
    class Program
    {
        static void Main(string[] args)

        {
            BenchmarkSwitcher.FromAssembly
                                        (
                                            typeof(Program).Assembly
                                        )
                                        .Run
                                            (
                                                args,
                                                new BenchmarkDotNet.Configs.DebugInProcessConfig()
                                            );

            BenchmarkRunner.Run<Benchmarks.FileReadingTests>();

            //BenchmarkRunner.Run<Benchmarks.CharacterSeparatedValuesTest>();
            //BenchmarkRunner.Run<Benchmarks.MLnet>();
            //BenchmarkRunner.Run<Benchmarks.AngaraTableTest>();
            //BenchmarkRunner.Run<Benchmarks.ChoETLTest>();
            //BenchmarkRunner.Run<Benchmarks.CsvHelperTest>();
            //BenchmarkRunner.Run<Benchmarks.FileHelpersTest>();

            // https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualbasic.fileio.textfieldparser?redirectedfrom=MSDN&view=netframework-4.7.2
            //BenchmarkRunner.Run<Benchmarks.TextFieldParserTest>();
            //BenchmarkRunner.Run<Benchmarks.TinyCsvParserTest>();

            return;
        }
    }
}
