using System;
using System.IO;
using System.Linq;

namespace MLNetShared
{
    public class MLNetUtilities
    {
        public static string GetDataPathByDatasetName(string datasetName)
        {
            string appPath = Path.GetDirectoryName(Environment.GetCommandLineArgs().First());
            DirectoryInfo parentDir = Directory.GetParent(appPath).Parent.Parent.Parent.Parent;

            string datasetPath = Path.Combine(parentDir.FullName, "datasets", datasetName);

            return datasetPath;
        }

        public static string GetModelFilePath(string fileName)
        {
            string appPath = Path.GetDirectoryName(Environment.GetCommandLineArgs().First());
            DirectoryInfo parentDir = Directory.GetParent(appPath).Parent.Parent.Parent.Parent;

            string fileDir = Path.Combine(parentDir.FullName, "models");

            if(!Directory.Exists(fileDir))
            {
                Directory.CreateDirectory(fileDir);
            }

            string filePath = Path.Combine(parentDir.FullName, "models", fileName);

            return filePath;
        }
    }
}
