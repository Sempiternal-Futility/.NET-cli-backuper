Differences between ".configFile.txt" and ".configFolder.txt":

On the .configFolder, the first line in the text file should contain the path of the directory that you want to create ( a new directory that doesn't exist that will be created )
then, on the remaining lines ( 2nd, 3rd, etc.) you will be typing the path of already existing directories that you want to backup

Now everytime you fire up the program, all the directories will be backed up to the top directory ( in the first line of the txt file )

EX:
C:\newFolder ( this folder will be created )
C:\Users
C:\Program Files ( Users and Program Files will get backed up to newFolder )


===================================================================================================================================================================================

On the .configFile, you start by typing "folder:" ( without the " ) and in front of that the path of a folder you want to create ( similar to the first line of the .configFolder )
But the difference is, under this line, you type the path of files you want to backup to that directory
However, you can create as many folders as you want!
EX:

folder:C:\NewFolder ( folder will be created )
C:\myFile
C:\myFileTwo ( myFile and myFileTwo gets backed up to NewFolder )
folder:C:\AnotherFolder
C:\myFileThree ( myFileThree gets backed up to AnotherFolder )

So now everytime you spin up the program, it will copy this file to the right directories 
( If the file already exists, it will be overwritten )


===================================================================================================================================================================================

If both files are empty, you will use the manual backuper, if both files have instructions on them, both will happen!