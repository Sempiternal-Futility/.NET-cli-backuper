using System;
using System.IO;

sealed class AutoBackuper : ExtraMethods
{

    static DirectoryInfo dirName;
    public static bool exceptionTriggered = false;

    private static bool forExceptoinTriggered = false;


    //Gets the specfied sourceFiles in the ".configFiles.txt" and copies them to the destFolder specified in the ".configFiles.txt"
    public static void CopyFilesConfig()
    {

      try
      {
        
        string[] configFile= File.ReadAllLines(@".config\.configFile.txt");

       //"configFile.Lenght > 0" is here to avoid an exception that may trigger if you only have text inside ".configFolder.txt"
       if (configFile.Length > 0)
       {

        foreach(string line in configFile)
        {
            if (line.StartsWith("folder:"))
            { 
                Directory.CreateDirectory(line.Remove(0, 7)); 
                dirName = new DirectoryInfo(line.Remove(0, 7));
            }

            else
            {
                FileInfo fileName = new FileInfo(line);
                File.Copy(line, @$"{ dirName.FullName }\{ fileName.Name }", true);
            }

        }

       }

      }
       catch (ArgumentException)
       { 
        HandlingExpcetions("Y O U   L E F T   S O M E   F I E L D S   E M P T Y !");
        exceptionTriggered = true;
       }

       catch (FileNotFoundException)
       {
         HandlingExpcetions("O N E   O R   M O R E   O F   T H E   F I L E S   W E R E   N O T   F O U N D !");
         exceptionTriggered = true;
       }

       catch (UnauthorizedAccessException)
       {
         HandlingExpcetions("I T   S E E M S   L I K E   Y O U   D O N 'T   H A V E   E N O U G H\nP E R M I S S I O N S   T O   R E A L I Z E   O N E   O F   T H E   A C T I O N S !");
         exceptionTriggered = true;
       }

       catch (NullReferenceException)
       {
         HandlingExpcetions(".C O N F I G   F I L E   V A L U E S   A R E   N O T   V A L I D !");
         exceptionTriggered = true;
       }
       
       catch (DirectoryNotFoundException)
       {
         HandlingExpcetions("Y O U   A R E   T R Y I N G   T O   C O P Y   A   F O L D E R   W I T H   .C O N F I G F I L E .T X T !");
         exceptionTriggered = true;
       }

 
       //This catch "everything" exception is here to guarantee that no expcetions will be possible
       catch (Exception)
       { exceptionTriggered = true; }

    }






    //Creates a folder with a location and name specified in the first line of ".configFolder.txt" and that folder becomes an exact replica of the second line specified in the ".configFolder.txt"
    public static void CopyFoldersConfig()
    {

      try
      {

        string[] configFolder = File.ReadAllLines(@".config\.configFolder.txt");

       //"configFolder.Lenght > 0" is here to avoid an exception that may trigger if you only have text inside ".configFile.txt"
       if (configFolder.Length > 0)
       {

        Directory.CreateDirectory(configFolder[0]);

        for (ushort i = 1; i < configFolder.Length; i++)
        {
          Directory.CreateDirectory(@$"{ configFolder[0] }\{ configFolder[i].Remove(0, 2) } ");


          string[] filesWithinFolder = Directory.GetFiles(configFolder[i]);
          foreach(string file in filesWithinFolder)
          { 
             FileInfo fileName = new FileInfo(file);
             File.Copy(file, @$"{ configFolder[0] }\{ configFolder[i].Remove(0, 2) }\{ fileName.Name }", true); 
          }

        CreateSubDirsConfigFolder();

        }

       }


      }
       catch (ArgumentException)
       { 
        HandlingExpcetions("Y O U   L E F T   S O M E   F I E L D S   E M P T Y !");
        exceptionTriggered = true;
       }

       catch (FileNotFoundException)
       {
         HandlingExpcetions("O N E   O R   M O R E   O F   T H E   F I L E S   W E R E   N O T   F O U N D !");
         exceptionTriggered = true;
       }

       catch (UnauthorizedAccessException)
       {
         HandlingExpcetions("I T   S E E M S   L I K E   Y O U   D O N 'T   H A V E   E N O U G H\nP E R M I S S I O N S   T O   R E A L I Z E   O N E   O F   T H E   A C T I O N S !");
         exceptionTriggered = true;
       }

       catch (NullReferenceException)
       {
         HandlingExpcetions(".C O N F I G   F I L E   V A L U E S   A R E   N O T   V A L I D !");
         exceptionTriggered = true;
       }
 
       //This catch "everything" exception is here to guarantee that no expcetions will be possible
       catch (Exception)
       {
        HandlingExpcetions("S O M E T H I N G   W E N T   W R O N G !"); 
        exceptionTriggered = true; 
       }



    }



    static void CreateSubDirsConfigFolder()
    {
        string[] configFolder = File.ReadAllLines(@".config\.configFolder.txt");

  try
  {
      for (ushort i = 1; i <= configFolder.Length; i++)
      {
        string[] getSubDirs = Directory.GetDirectories(configFolder[i], "*", SearchOption.AllDirectories);

        foreach (string dir in getSubDirs)
        {
            if (forExceptoinTriggered) { break; }

            string dirPath = Path.GetFullPath(dir);
            Directory.CreateDirectory(@$"{ configFolder[0] }\{ dirPath.Remove(0, 2) }");

            var filesWithinSubDir = Directory.GetFiles(dir);

            foreach(var file in filesWithinSubDir)
            {
                FileInfo fileName = new FileInfo(file);
                File.Copy(file, @$"{ configFolder[0] }\{ dirPath.Remove(0,2 ) }\{ fileName.Name }", true);
            }
        }

      }

  }
   catch (IndexOutOfRangeException)
          { forExceptoinTriggered = true; }
   //This try-catch is here because of a weird bug, it will copy the same folder multiple times, so this fixes it

    }
}