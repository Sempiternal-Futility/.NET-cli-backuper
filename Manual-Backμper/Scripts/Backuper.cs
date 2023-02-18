using System;
using System.IO;

// TODO:

// Create github repository

class Backuper : ExtraMethods
{

    public static string sourceFolder { get; set; }
    public static string destFolder { get; set; }
    public static bool copyDir { get; set; } = false;

    public static bool checkedIfDestFolderExists { get; set; } = false;


    //This asks the user if he wants to copy a folder AND the files within it
    //If the user only wants to copy the files, it will copy the files within the folder, but not the folder itself
    public static void AskUserIfHeWantsToCopyAFolder()
    {
       bool repeatSwitch = true;
       Console.WriteLine("D O   Y O U   W A N T   T O   C O P Y   A   F O L D E R ?    ( Y / N )");

       while(repeatSwitch)
       {

        switch(Console.ReadKey(true).KeyChar)
        {
            case 'y' : repeatSwitch = false; Console.Clear(); copyDir = true; AskUserForInput();
            break;

            case 'n' : repeatSwitch = false; Console.Clear(); copyDir = false; AskUserForInput();
            break;

            default :
            break;
        }

       }
    }

    //Ask inputs from user
    public static void AskUserForInput()
    {
        if (copyDir == false) { Console.WriteLine("W H A T   F I L E (S)   D O   Y O U   W A N T   T O   B A C K U P ?"); }
        else { Console.WriteLine("W H A T   F O L D E R   D O   Y O U   W A N T  T O   B A C K U P ?"); }
        sourceFolder = Console.ReadLine();

        GetFilesWithinFolder();
        AskUserForYesOrNo();
 
        if (copyDir == false) { Console.WriteLine("W H E R E   S H O U L D   T H E S E   F I L E S   B E   B A C K E D   UP   T O ?"); } 
        else { Console.WriteLine("W H E R E   S H O U L D   T H I S   F O L D E R   B E   B A C K E D   U P   T O ?"); }

        destFolder = Console.ReadLine();



        if ( Directory.Exists(destFolder) ) 
        { Console.Clear(); WorkingOnItMessage(); }

    }


    //Get the name of the files within the sourceFolder, and asks user confirmation
    static void GetFilesWithinFolder()
    {
        Console.WriteLine();
        bool noFilesFound = false;

     try
     {

        DirectoryInfo dir = new DirectoryInfo(sourceFolder);

        FileInfo[] getFiles = dir.GetFiles();
        DirectoryInfo[] getSubDirs = dir.GetDirectories();

        //If there are 0 files found in the 'sourceFolder'
        if (getFiles.Length == 0 && getSubDirs.Length == 0) 
        { 
            Console.WriteLine(); 

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("T H E R E   A R E   N O   F I L E S   O R   S U B - F O L D E R S   F O U N D   I N   T H I S   D I R E C T O R Y !"); 
            Console.WriteLine("D O   Y O U   W A N T   T O   C O P Y   A N   E M P T Y   F O L D E R ?    ( Y / N )"); 

            Console.ForegroundColor = ConsoleColor.Cyan;

            noFilesFound = true; 
        }


     if (noFilesFound == false)
     {  

       if (copyDir)
       {

        //Checks if there's any sub folders within the source folder
        if (getSubDirs.Length == 0) 
        { Console.WriteLine("N O   S U B   F O L D E R S   F O U N D !"); Console.WriteLine(); Console.WriteLine(); } 

        else
        {
        Console.WriteLine("S U B   F O L D E R S   F O U N D:");
        Console.ForegroundColor = ConsoleColor.Blue; 

        foreach(DirectoryInfo subDir in getSubDirs)
        { Console.WriteLine(subDir.Name); }
 
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine();
        Console.WriteLine();
        }

       }


        //Checks if there's any files within the source folder
        if (getFiles.Length == 0) 
        { Console.WriteLine("N O   F I L E S   F O U N D !"); Console.WriteLine(); Console.WriteLine(); }

        else
        {

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("F I L E S   F O U N D:");
        Console.ForegroundColor = ConsoleColor.Blue;

        foreach(FileInfo file in getFiles)
        { Console.WriteLine(file.Name); }

        }


        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("A R E   Y O U   S U R E   Y O U   W A N T   T O   B A C K   T H E M   U P ?    ( Y / N )"); 

     }


     }
      catch (DirectoryNotFoundException)
      {

      if (copyDir)
      {
       Console.Clear();
       HandlingExpcetions("D I R E C T O R Y   N O T   F O U N D !");
       LoopProgram(); 
      }


      else
      {
       Console.Clear();
       HandlingExpcetions("F I L E   N O T   F O U N D !");
       LoopProgram(); 
      }
      //This 'if' and 'else' statements check if you're trying to copy a folder or directory

      }


      //This catch is here if the user wants to copy a single file (not a whole folder)
      //What triggers the catch is the 'new DirectoryInfo(sourceFolder)', but if the user wants to copy a single file, 'sourceFolder' won't be a folder at all, instead it will be the single file the user wants to copy
      catch (IOException)
      { 
        CopySingleFile();
        DoneMessage();
        LoopProgram();
      }

      catch (UnauthorizedAccessException)
      {
        HandlingExpcetions("I T   S E E M S   L I K E   Y O U   D O N 'T   H A V E   E N O U G H   P E R M I S S I O N S   T O   B A C K U P   T H I S   F O L D E R !");
        LoopProgram();
      }

        Console.WriteLine();
    }



    //Copy only the FILES within a directory, but doesn't copy the directory itself
    public static void CopyFiles()
    {

      try
      {
        string[] getFiles = Directory.GetFiles(sourceFolder);

        foreach(string file in getFiles)
        {
            var fileNames = new FileInfo(file);
            File.Copy(file, $@"{destFolder}\{fileNames.Name}", true);
        }

        DoneMessage();
        LoopProgram();
      }

       catch (DirectoryNotFoundException) 
       { 
       Console.Clear();
       HandlingExpcetions("D I R E C T O R Y   N O T   F O U N D !");
       LoopProgram(); 
       }

    }

    static void CopySingleFile()
    {

      try
      {
        FileInfo fileName = new FileInfo(sourceFolder);

        Console.Clear();
        Console.WriteLine("W H E R E   S H O U L D   T H I S   F I L E   B E   B A C K E D   U P   T O ?");
        string? destFolder = Console.ReadLine();
        File.Copy(sourceFolder, $@"{destFolder}\{fileName.Name}", true);
      }

       catch (DirectoryNotFoundException) 
       { 
       Console.Clear();
       HandlingExpcetions("D I R E C T O R Y   N O T   F O U N D !");
       LoopProgram(); 
       }

    }



    //Copies a directory, subdirectories, and the files within them
    public static void CopyFolders()
    {
        
      try
      {

        if (checkedIfDestFolderExists== false) { CheckIfDestFolderExists(); }

        string[] getsubDirs = Directory.GetDirectories(sourceFolder, "*", SearchOption.AllDirectories);
        string[] getFilesInDir = Directory.GetFiles(sourceFolder);
        

        DirectoryInfo dirName = new DirectoryInfo(sourceFolder);
        Directory.CreateDirectory($@"{destFolder}\{dirName.Name}");

        //Copies the files to the root directory
        foreach(string file in getFilesInDir)
        {
            var fileNames = new FileInfo(file);
            File.Copy(file, $@"{destFolder}\{dirName.Name}\{fileNames.Name}", true);
        }


        //Copies all the sub directories and their files
        foreach (string dir in getsubDirs)
        {
            string dirPath = Path.GetFullPath(dir);
            Directory.CreateDirectory(@$"{ destFolder }\{ dirPath.Remove(0, 2) }");

            var filesWithinSubDir = Directory.GetFiles(dir);

            foreach(var file in filesWithinSubDir)
            {
                FileInfo fileName = new FileInfo(file);
                File.Copy(file, @$"{ destFolder }\{ dirPath.Remove(0,2 ) }\{ fileName.Name }", true);
            }
        }



        DoneMessage();
        LoopProgram();

      }

       catch (UnauthorizedAccessException)
       {
        HandlingExpcetions("I T   S E E M S   L I K E   Y O U   D O N 'T   H A V E   E N O U G H   P E R M I S S I O N S   T O   B A C K U P   T H I S   F O L D E R !");
        LoopProgram();
       }

    }

    static void CheckIfDestFolderExists()
    {

        bool loopSwitch = true;

        if (Directory.Exists(destFolder) == false) 
        { 
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("T H E   D E S T I N A T I O N   D I R E C T O R Y   D O E S N 'T   S E E M   T O   E X I S T !"); 
            Console.WriteLine("W O U L D   Y O U   L I K E   T O   C R E A T E   I T ?    ( Y / N )");

            Console.ForegroundColor = ConsoleColor.Cyan;

          while(loopSwitch)
          {

            switch(Console.ReadKey(true).KeyChar)
            {
                case 'y' : loopSwitch = false; checkedIfDestFolderExists = true; Console.Clear(); WorkingOnItMessage(); CopyFolders();
                break;

                case 'n' : loopSwitch = false; LoopProgram();
                break;

                default : loopSwitch = true;
                break;
            }
          }

        }
    }

}