using System;

class Program : ExtraMethods
{
    public static void Main()
    {
       if ( CheckIfdotConfigFolderExists() )
       {

        if (CheckIfFilesAreEmpty() == false)
        {
 

          Console.Clear();

           Console.Title = "=======| B A C K μ P E R |=======";
           WorkingOnItMessage();

           AutoBackuper.CopyFilesConfig();
           AutoBackuper.CopyFoldersConfig();

           Console.Clear();

           if (AutoBackuper.exceptionTriggered == false)
           { Console.ForegroundColor = ConsoleColor.Green; }

           else
           { Console.ForegroundColor = ConsoleColor.Magenta; }

           Console.WriteLine(
            @"
██████╗      ██████╗     ███╗   ██╗    ███████╗    ██╗    ██╗    ██╗
██╔══██╗    ██╔═══██╗    ████╗  ██║    ██╔════╝    ██║    ██║    ██║
██║  ██║    ██║   ██║    ██╔██╗ ██║    █████╗      ██║    ██║    ██║
██║  ██║    ██║   ██║    ██║╚██╗██║    ██╔══╝      ╚═╝    ╚═╝    ╚═╝
██████╔╝    ╚██████╔╝    ██║ ╚████║    ███████╗    ██╗    ██╗    ██╗
╚═════╝      ╚═════╝     ╚═╝  ╚═══╝    ╚══════╝    ╚═╝    ╚═╝    ╚═╝
            ");

           System.Threading.Thread.Sleep(1500);
           //Here I didn't use the 'ExtraMethods.DoneMessage()' because that method ends with console.readkey, and i want the program to close on its own here
        }
 

        else
        {
           EmptyFilesMessage();
        }


       }


       else 
       { 
          Console.Title = "=======| B A C K μ P E R |=======";
          Console.Clear();

          Console.ForegroundColor = ConsoleColor.Magenta; 
          Console.WriteLine(".c o n f i g   F O L D E R   N O T   F O U N D !"); 
          Console.WriteLine("P R E S S   A N Y   K E Y   T O   C R E A T E   I T !");
          
          Console.ReadKey(true);
          CreatingdotConfigFolder();
      }

    }
}