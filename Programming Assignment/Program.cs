using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Programming_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentFolder = ("C:\\Windows"); //This string holds the current folder path which is used later in the code to display what the current folder is that you're viewing

            WaitForEnter(); //Calls the Method before any other Method so it's display first
            FolderDirectory(currentFolder); //Calls the Method which displays the menu and all the files/folders
        }

        //This method is purely for aesthetics, it loads up before the menu screen method and is a simple line of text
        static void WaitForEnter() //It begins before the main program telling you to press enter to begin
        {
            //Displays text on the screen and waits for a key press before displaying the main loop
            Console.Write("Please press Enter to begin");
            Console.ReadLine();
            Console.Clear();
        }

        //This methods holds the menu screen with the options that the user selects from 1-4
        static void MenuOptions(string currentFolder)
        {

            string[] MenuOptions = new string[4] { "1", "2", "3", "4" }; //Creates a 4 string array with numbers to be used for the options below

            //This is the main block of text that display, welcoming you to the program, tell you which folder you're currently in and the options you have to choose from
            Console.WriteLine("Welcome, you are now viewing the File Path Finder. Please follow instructions below.");
            Console.WriteLine("The current folder you are viewing is {0}", currentFolder); //Here is where the string in the Main Method is called to display the current folder path
            Console.WriteLine("");
            Console.WriteLine("Please enter a number between 1-4 corresponding to what you need.");
            Console.WriteLine("");
            Console.WriteLine("{0}. Full File Listing", MenuOptions[0]);
            Console.WriteLine("{0}. Filtered File Listing", MenuOptions[1]);
            Console.WriteLine("{0}. Folder Statistics", MenuOptions[2]);
            Console.WriteLine("{0}. Quit Application", MenuOptions[3]);
            Console.WriteLine("");
        }

        //This method holds the main do loop and all the variables which tracks the users input
        static void FolderDirectory(string currentFolder)
        {
            DirectoryInfo folderInfo = new DirectoryInfo(currentFolder); //Sets the default drive and/or subfolders to search in
            FileInfo[] files = folderInfo.GetFiles(); //Gets all the files that are currently in the default location

            //This holds the value that the user input for later when it's needed
            string filter;

            //fileName is used to display the names of the files which are in the folder you're currently in, it doesn't hold value that the user inputs
            string fileName = "";

            int input; //Used to convert the userInput to a integer
            int numberIncrease; //Used as a counter to display a number before the file name
            int totalFiles = 0; //Keeps track of the number of files 

            long largestFile = 0; //Stores the largest size of the files in the directory
            long total = 0; //Stores the total size of all the files in the directory
            long average; //Stories of the average of the two long variables above

            //////////Main Do Loop\\\\\\\\\\
            //////////Main Do Loop\\\\\\\\\\
            //////////Main Do Loop\\\\\\\\\\
            do
            {
                totalFiles = 0; //Resets the value the variable had stored back to 0 after each loop
                MenuOptions(currentFolder); //Fetches the code from the MenuOptions Method

                bool number = int.TryParse(Console.ReadLine(), out input);
                while (number == false || input < 1 || input > 4) //if the number is less than 1 or higher than 4 or not even a number then the text will appear until a valid number is entered
                {
                    Console.WriteLine("Try again, please only enter a number from 1-4");
                    number = int.TryParse(Console.ReadLine(), out input);
                }

                if (input == 1)
                {
                    Console.Clear();

                    files = folderInfo.GetFiles();
                    numberIncrease = 1; //Sets this value to 1

                    Console.WriteLine("Files in {0}", folderInfo);
                    Console.WriteLine("");

                    //Numerically displays the results in alphabetical order with the size of the file. i.e - 1.explorer.exe 23783
                    for (int index = 0; index < files.Length; index++)
                    {
                        Console.Write("{0}. ", numberIncrease);
                        numberIncrease++;
                        Console.WriteLine("{0} - {1}", files[index].Name, files[index].Length); 
                    }

                    Console.WriteLine("");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                }
                if (input == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a File Filter, for example: *.exe");

                    //Filters out results that don't contain the letters/numbers that were inputted. i.e - if you type .exe then all the results that don't have that combination of text won't be displayed
                    filter = Console.ReadLine();
                    files = folderInfo.GetFiles(filter);
                    numberIncrease = 1;

                    Console.WriteLine("Files in {0}", folderInfo);
                    Console.WriteLine("");
                    
                    //Numerically displays the results in alphabetical order with the size of the file. i.e - 1.explorer.exe 23783
                    for (int index = 0; index < files.Length; index++)
                    {
                        Console.Write("{0}. ", numberIncrease);
                        numberIncrease++;
                        Console.WriteLine("{0} - {1}", files[index].Name, files[index].Length);
                    }

                    Console.WriteLine("");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                }
                if (input == 3)
                {
                    Console.Clear();
                    for (int index = 0; index < files.Length; index++)
                    {
                        total += files[index].Length;
                        totalFiles++;
                        
                        if (largestFile < files[index].Length)
                        {
                            largestFile = files[index].Length;
                            fileName = files[index].Name;
                        }
                    }

                    //Adds the total file size of all the files and then divides that number by the amount of files to get the average files size
                    average = total / totalFiles;

                    //Block of text that displays information on files size, amount of files, average file size, etc.
                    Console.WriteLine("Current Folder: {0}", currentFolder);
                    Console.WriteLine("");
                    Console.WriteLine("TotalFiles: {0}", totalFiles);
                    Console.WriteLine("Total File Size: {0}", total);
                    Console.WriteLine("Largest File: {0} {1}", fileName, largestFile);
                    Console.WriteLine("Average File Size: {0}", average);
                    Console.WriteLine("");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (input != 4); //Closes the program if the number 4 is entered
        }
    }
}