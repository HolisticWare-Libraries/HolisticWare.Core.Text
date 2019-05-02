string[] folders = new string[]
{
    "./externals/",
    "./source/**/bin/",
    "./source/**/obj/",
};

//---------------------------------------------------------------------------------------
Task ("clean")
    .Does
    (
        () =>
        {
            foreach(string folder in folders)
            {
                DirectoryPathCollection directories = GetDirectories(folder);
                foreach(DirectoryPath dp in directories)
                {
                    Information($"Directory: {dp}");

                    if (DirectoryExists (dp))
                    {
                        DeleteDirectory 
                                    (
                                        dp, 
                                        new DeleteDirectorySettings 
                                        {
                                            Recursive = true,
                                            Force = true
                                        }
                                    );
                    }
                }                
            }


            return;
        }
    );
//---------------------------------------------------------------------------------------

