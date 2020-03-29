using System;
using System.Collections.Generic;
using System.IO;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;

using Microsoft.Data.DataView;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class MLnet :TestBase
    {
        public class AndroidX
        {
            [LoadColumn(0)]
            public string AndroidSupportType { get; set; }
 
            [LoadColumn(1)]
            public string AndroidXType{ get; set; }

        }

        private string Text { get; set; }
        private readonly Consumer consumer = new Consumer();

        [Benchmark]
        public void MLnet_Parse_File()
        {
            // https://docs.microsoft.com/en-us/dotnet/machine-learning/how-to-guides/load-data-ml-net
            //Create MLContext
            Microsoft.ML.MLContext mlContext = new Microsoft.ML.MLContext();

            //Load Data
            IDataView data = mlContext.Data.LoadFromTextFile<AndroidX>
                                                                (
                                                                    "androidx-class-mapping.csv",
                                                                    separatorChar: ',',
                                                                    hasHeader: true
                                                                );
        }

    }
}
