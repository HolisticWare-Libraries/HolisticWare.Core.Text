
//---------------------------------------------------------------------------------------
Task("nuget-restore")
    .Does
    (
        () =>
        {
            FilePathCollection files = null;

            files = GetFiles("./externals/**/source/*.sln");
            foreach(FilePath file in files)
            {
                Information("File: {0}", file);
                NuGetRestore(file);
            }
            files = GetFiles("./source/**/*.sln");
            foreach(FilePath file in files)
            {
                Information("File: {0}", file);
                NuGetRestore(file);
            }
            files = GetFiles("./samples/**/*.sln");
            foreach(FilePath file in files)
            {
                Information("File: {0}", file);
                NuGetRestore(file);
            }
            files = GetFiles("./tests/**/*.sln");
            foreach(FilePath file in files)
            {
                Information("File: {0}", file);
                NuGetRestore(file);
            }

            return;
        }
    );
//---------------------------------------------------------------------------------------
