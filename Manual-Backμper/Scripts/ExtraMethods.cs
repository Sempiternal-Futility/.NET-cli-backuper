using System;
using System.IO;


//This class contains methods that are not directly related to the the file system (i.g copying)
class ExtraMethods
{
    public static void LookOfTheProgram()
    {
       Console.ForegroundColor = ConsoleColor.Cyan;
       Console.BackgroundColor = ConsoleColor.Black;
       Console.Title = "=======| B A C K μ P E R |=======";

       ExtraMethods.BackuperASCII();
    }


    // If the copyDir bool is true, it will copy the whole folder! 
    // If the copyDir bool is false, it will copy only the FILES within that folder, not the folder itself
    public static void DecidingWhatToCopy()
    {
        if (Backuper.copyDir) { Backuper.CopyFolders(); }
        else { Backuper.CopyFiles(); }
    }


    //Ask a confirmation from the user if he really wants to back up the files
    public static void AskUserForYesOrNo()
    {
       bool repeatSwitch = true;

       while (repeatSwitch)
       {
 
         switch (Console.ReadKey(true).KeyChar)
         {
             case 'y' : repeatSwitch = false; Console.Clear();
             break;

             case 'n' : repeatSwitch = false; Console.Clear(); Backuper.AskUserForInput();
             break;

             default :
             break;
         }
       }

    }


    public static void DoneMessage()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(
            @"
██████╗      ██████╗     ███╗   ██╗    ███████╗    ██╗    ██╗    ██╗
██╔══██╗    ██╔═══██╗    ████╗  ██║    ██╔════╝    ██║    ██║    ██║
██║  ██║    ██║   ██║    ██╔██╗ ██║    █████╗      ██║    ██║    ██║
██║  ██║    ██║   ██║    ██║╚██╗██║    ██╔══╝      ╚═╝    ╚═╝    ╚═╝
██████╔╝    ╚██████╔╝    ██║ ╚████║    ███████╗    ██╗    ██╗    ██╗
╚═════╝      ╚═════╝     ╚═╝  ╚═══╝    ╚══════╝    ╚═╝    ╚═╝    ╚═╝
            ");
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.ReadKey(true);
    }

    public static void LoopProgram()
    {
         Backuper.copyDir = false;
         Backuper.checkedIfDestFolderExists = false;
         Backuper.sourceFolder = string.Empty;
         Backuper.destFolder = string.Empty;

         Program.Main();
    }

    public static void BackuperASCII()
    {
        Console.WriteLine(
            @"
██████╗      █████╗      ██████╗    ██╗  ██╗    ██╗   ██╗    ██████╗     ███████╗    ██████╗ 
██╔══██╗    ██╔══██╗    ██╔════╝    ██║ ██╔╝    ██║   ██║    ██╔══██╗    ██╔════╝    ██╔══██╗
██████╔╝    ███████║    ██║         █████╔╝     ██║   ██║    ██████╔╝    █████╗      ██████╔╝
██╔══██╗    ██╔══██║    ██║         ██╔═██╗     ██║   ██║    ██╔═══╝     ██╔══╝      ██╔══██╗
██████╔╝    ██║  ██║    ╚██████╗    ██║  ██╗    ╚██████╔╝    ██║         ███████╗    ██║  ██║
╚═════╝     ╚═╝  ╚═╝     ╚═════╝    ╚═╝  ╚═╝     ╚═════╝     ╚═╝         ╚══════╝    ╚═╝  ╚═╝


            ");

        Console.WriteLine("P R E S S   A N Y   K E Y   T O   B E G I N   B A C K I N G   S T U F F   U P !");
        Console.ReadKey(true);
        Console.Clear();

    }

    public static void WorkingOnItMessage()
    {
       Console.ForegroundColor = ConsoleColor.Cyan;
       Console.WriteLine(
        @"
██╗    ██╗     ██████╗     ██████╗     ██╗  ██╗    ██╗    ███╗   ██╗     ██████╗ 
██║    ██║    ██╔═══██╗    ██╔══██╗    ██║ ██╔╝    ██║    ████╗  ██║    ██╔════╝ 
██║ █╗ ██║    ██║   ██║    ██████╔╝    █████╔╝     ██║    ██╔██╗ ██║    ██║  ███╗
██║███╗██║    ██║   ██║    ██╔══██╗    ██╔═██╗     ██║    ██║╚██╗██║    ██║   ██║
╚███╔███╔╝    ╚██████╔╝    ██║  ██║    ██║  ██╗    ██║    ██║ ╚████║    ╚██████╔╝
 ╚══╝╚══╝      ╚═════╝     ╚═╝  ╚═╝    ╚═╝  ╚═╝    ╚═╝    ╚═╝  ╚═══╝     ╚═════╝ 
                                                                                 
       ");

       Console.WriteLine(
        @"
 ██████╗     ███╗   ██╗            ██╗    ████████╗    ██╗
██╔═══██╗    ████╗  ██║            ██║    ╚══██╔══╝    ██║
██║   ██║    ██╔██╗ ██║            ██║       ██║       ██║
██║   ██║    ██║╚██╗██║            ██║       ██║       ╚═╝
╚██████╔╝    ██║ ╚████║            ██║       ██║       ██╗
 ╚═════╝     ╚═╝  ╚═══╝            ╚═╝       ╚═╝       ╚═╝

        ");
    }


    public static void HandlingExpcetions(string messageToEndUser)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(messageToEndUser);
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.ReadKey(true);
    }


    //Checks if the .config files are empty, if they are, the program will start the manual backup process
    public static bool CheckIfFilesAreEmpty()
    {
        string[] configFile= File.ReadAllLines(@".config\.configFile.txt");
        string[] configFolder = File.ReadAllLines(@".config\.configFolder.txt");


        if (configFile.Length == 0 && configFolder.Length == 0)
        { return true; }

        else { return false; }
    }

    public static bool CheckIfdotConfigFolderExists()
    {
        if ( Directory.Exists(".config") )
        { return true; }

        else { return false; }
    }

    public static void CreatingdotConfigFolder()
    {
        Directory.CreateDirectory(".config");

        File.Create(@".config\.configFile.txt");
        File.Create(@".config\.configFolder.txt");


        DoneMessage();
    }
}