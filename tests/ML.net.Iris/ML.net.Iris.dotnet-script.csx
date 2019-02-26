#r "nuget: System.Memory"
// #r "nuget: System.ValueTuple"
#r "nuget: Microsoft.ML"
#r "nuget: Microsoft.Data.DataView"

#r "../../source/HolisticWare.Core.Text.NetStandard13/bin/Debug/netstandard1.3/HolisticWare.Core.Text.NetStandard13.dll"

//ScriptEnvironment.Default.OverrideTargetFramework("net461");

/*
    ./scriptcs_nuget.config
    scriptcs -install Microsoft.ML
    scriptcs -install Microsoft.Data.DataView
    scriptcs -install System.Memory

    https://en.wikipedia.org/wiki/Iris_flower_data_set

    https://archive.ics.uci.edu/ml/datasets/Iris

    https://raw.githubusercontent.com/dotnet/machinelearning/master/test/data/iris.data

 */
using Core.Text;
using System;
using System.IO;
// using Microsoft.ML;
// using Microsoft.Data.DataView;
// using Microsoft.ML.Data;

// public class IrisData
// {
//     [LoadColumn(0)]
//     public float SepalLength;

//     [LoadColumn(1)]
//     public float SepalWidth;

//     [LoadColumn(2)]
//     public float PetalLength;

//     [LoadColumn(3)]
//     public float PetalWidth;
// }

// public class ClusterPrediction
// {
//     [ColumnName("PredictedLabel")]
//     public uint PredictedClusterId;

//     [ColumnName("Score")]
//     public float[] Distances;
// }


string file = "iris.data.csv";
CharacterSeparatedValues csv = new CharacterSeparatedValues();
string content = await csv.LoadAsync(file);

var mapping = csv
                .ParseTemporaryImplementation()
                .ToList()
                ;
foreach(string[] row in mapping)
{
    foreach(string c in row)
    {
        Console.Write($"csv = {c}    ");
    }
    Console.WriteLine($"");
}



// static readonly string _dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "iris.data");
// static readonly string _modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "IrisClusteringModel.zip");
