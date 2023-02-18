using System;
using System.IO;


//This class contains methods that are not directly related to the the file system (i.g copying)
class ExtraMethods
{

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


    //Checks if the .config files are empty, if they are, the program will start the manual backup process
    public static bool CheckIfFilesAreEmpty()
    {
        string[] configFile= File.ReadAllLines(@".config\.configFile.txt");
        string[] configFolder = File.ReadAllLines(@".config\.configFolder.txt");


        if (configFile.Length == 0 && configFolder.Length == 0)
        { return true; }

        else { return false; }
    }

    public static void EmptyFilesMessage()
    {
        Console.Clear();
        Console.Title = "=======| B A C K μ P E R |=======";

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(
            @"
    ██████╗     ██████╗     ███╗   ██╗    ███████╗    ██╗     ██████╗           ███████╗    ██╗    ██╗         ███████╗    ███████╗
   ██╔════╝    ██╔═══██╗    ████╗  ██║    ██╔════╝    ██║    ██╔════╝           ██╔════╝    ██║    ██║         ██╔════╝    ██╔════╝
   ██║         ██║   ██║    ██╔██╗ ██║    █████╗      ██║    ██║  ███╗          █████╗      ██║    ██║         █████╗      ███████╗
   ██║         ██║   ██║    ██║╚██╗██║    ██╔══╝      ██║    ██║   ██║          ██╔══╝      ██║    ██║         ██╔══╝      ╚════██║
██╗╚██████╗    ╚██████╔╝    ██║ ╚████║    ██║         ██║    ╚██████╔╝          ██║         ██║    ███████╗    ███████╗    ███████║
╚═╝ ╚═════╝     ╚═════╝     ╚═╝  ╚═══╝    ╚═╝         ╚═╝     ╚═════╝           ╚═╝         ╚═╝    ╚══════╝    ╚══════╝    ╚══════╝
                                                                                                                                                 
            ");

        Console.WriteLine(
            @"
 █████╗     ██████╗     ███████╗            ███████╗    ███╗   ███╗    ██████╗     ████████╗    ██╗   ██╗    ██╗
██╔══██╗    ██╔══██╗    ██╔════╝            ██╔════╝    ████╗ ████║    ██╔══██╗    ╚══██╔══╝    ╚██╗ ██╔╝    ██║
███████║    ██████╔╝    █████╗              █████╗      ██╔████╔██║    ██████╔╝       ██║        ╚████╔╝     ██║
██╔══██║    ██╔══██╗    ██╔══╝              ██╔══╝      ██║╚██╔╝██║    ██╔═══╝        ██║         ╚██╔╝      ╚═╝
██║  ██║    ██║  ██║    ███████╗            ███████╗    ██║ ╚═╝ ██║    ██║            ██║          ██║       ██╗
╚═╝  ╚═╝    ╚═╝  ╚═╝    ╚══════╝            ╚══════╝    ╚═╝     ╚═╝    ╚═╝            ╚═╝          ╚═╝       ╚═╝
            ");


        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.ReadKey(true);
    }
}