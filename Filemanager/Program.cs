using System;
using System.ComponentModel.Design;
using System.IO;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace Filemanager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("File Manager");
            var b = true;
            var c = true;
            //to repeat commands
            while (b)
            {
                Console.WriteLine();
                if (c)
                    Console.WriteLine("Enter 'help' for information about the File manager");
                if (!c)
                    Console.WriteLine("Enter the appropriate command");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "help":
                        Console.WriteLine();
                        Console.WriteLine(@"Enter 'thispc' - Browse the list of drives on your computer.
Enter 'cd' - switch to directory.
Enter 'list' - viewing a list of files in a directory.
Enter 'outtextutf8' - outputting the contents of a text file to the console in UTF-8 encoding.
Enter 'outtextutf7' - outputting the contents of a text file to the console in UTF-7 encoding.
Enter 'outtextutf32' - outputting the contents of a text file to the console in UTF-32 encoding.
Enter 'outtextascii' - outputting the contents of a text file to the console in ASCII encoding.
Enter 'copy' - copy file.
Enter 'move' - move the file to a selected directory.
Enter 'del' - delete file.
Enter 'crutf8' - creating a UTF-8 encoded text file.
Enter 'crutf7' - creating a UTF-7 encoded text file.
Enter 'crutf32' - creating a UTF-32 encoded text file.
Enter 'crascii' - creating a ASCII encoded text file.
Enter 'concatenate' - concatenate the contents of two or more text files and output the result to the console in UTF-8 encoding.");
                        break;
                    case "thispc":
                        Console.WriteLine();
                        PC();
                        break;
                    case "cd":
                        Console.WriteLine();
                        Console.WriteLine("Enter directory path.");
                        Open(Console.ReadLine());

                        break;
                    case "list":
                        Console.WriteLine();
                        Console.WriteLine("Enter directory path.");
                        List(Console.ReadLine());
                        break;
                    case "outtextutf8":
                        Outtext8();
                        break;
                    case "outtextutf7":
                        Outtext7();
                        break;
                    case "outtextutf32":
                        Outtext32();
                        break;
                    case "outtextascii":
                        Outtextascii();
                        break;
                    case "copy":
                        Copy();
                        break;
                    case "move":

                        break;
                    case "del":
                        Del();
                        break;
                    case "crutf8":
                        Crtext8();
                        break;
                    case "crutf7":
                        Crtext7();
                        break;
                    case "crutf32":
                        Crtext32();
                        break;
                    case "crascii":
                        Crtextascii();
                        break;
                    case "concatenate":
                        Concatenate();
                        break;
                    default:
                        Console.WriteLine("You selected a non-existing team.");
                        break;

                }
                Console.WriteLine("If you want to exit press Escape, if not then press enter.");
                //to repeat commands
                var button = Console.ReadKey();
                if (button.Key == ConsoleKey.Escape)
                {
                    b = false;
                }
                c = false;
            }

        }

        //Method for viewing the list of drives.
        private static void PC()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine(drive.Name);
            }
        }
        //Method for viewing a list of files in a directory.
        private static void List(string dirname)
        {
            try
            {
                DirectoryInfo files = new DirectoryInfo(dirname);
                foreach (var file in files.GetFiles())
                {
                    Console.WriteLine(file.Name);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
        //Method for selecting another directory.
        private static void Open(string dirname)
        {
            try
            {
                Directory.SetCurrentDirectory(dirname);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //Method to output the contents of a text file to the console in UTF-8 encoding.
        private static void Outtext8()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Enter file path.");
                var path = Console.ReadLine();
                var text = File.ReadAllText(path, Encoding.UTF8);
                Console.WriteLine(text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //Method to output the contents of a text file to the console in UTF-7 encoding.
        private static void Outtext7()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Enter file path.");
                var path = Console.ReadLine();
                var text = File.ReadAllText(path, Encoding.UTF7);
                Console.WriteLine(text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //Method to output the contents of a text file to the console in UTF-32 encoding.
        private static void Outtext32()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Enter file path.");
                var path = Console.ReadLine();
                var text = File.ReadAllText(path, Encoding.UTF32);
                Console.WriteLine(text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void Outtextascii()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Enter file path.");
                var path = Console.ReadLine();
                var text = File.ReadAllText(path, Encoding.ASCII);
                Console.WriteLine(text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //Method for copying the file.
        private static void Copy()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Enter the file path you want to copy.");
                var source = Console.ReadLine();
                Console.WriteLine("Enter the path where you want to copy the file.");
                var dest = Console.ReadLine();
                File.Copy(source, dest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //Method for moving the file.
        private static void Move()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Enter the file path you want to move.");
                var oldpath = Console.ReadLine();
                Console.WriteLine("Enter the path where you want to move the file.");
                var newpath = Console.ReadLine();
                File.Move(newpath, oldpath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //Method for deleate the file.
        private static void Del()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Enter the file path.");
                var path = Console.ReadLine();
                File.Delete(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //Method for creating a UTF-8 encoded text file.
        private static void Crtext8()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Enter path of your file.");
                var path = Console.ReadLine();
                Console.WriteLine("Enter your text.");
                var text = Console.ReadLine();
                File.WriteAllText(path, text, Encoding.UTF8);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //Method for creating a UTF-7 encoded text file.
        private static void Crtext7()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Enter path of your file.");
                var path = Console.ReadLine();
                Console.WriteLine("Enter your text.");
                var text = Console.ReadLine();
                File.WriteAllText(path, text, Encoding.UTF7);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //Method for creating a UTF-32 encoded text file.
        private static void Crtext32()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Enter path of your file.");
                var path = Console.ReadLine();
                Console.WriteLine("Enter your text.");
                var text = Console.ReadLine();
                File.WriteAllText(path, text, Encoding.UTF32);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //Method for creating a ASCII encoded text file.
        private static void Crtextascii()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Enter path of your file.");
                var path = Console.ReadLine();
                Console.WriteLine("Enter your text.");
                var text = Console.ReadLine();
                File.WriteAllText(path, text, Encoding.ASCII);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //Method for concatenating the contents of two or more text files.
        private static void Concatenate()   
        {
            try
            {
                var n = 0;
                Console.WriteLine();
                Console.WriteLine("Enter the quantity of files for concatenation(two or more).");
                n = int.Parse(Console.ReadLine());
                var name = new string[n];
                var text = new string[n];
                string texts = "";
                /*First we read the files then concatenate
then creating a new file at the end output to the console*/
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"Enter the path of the {i + 1} file");
                    name[i] = Console.ReadLine();
                }
                for (int i = 0; i < n; i++)
                {
                    text[i] = File.ReadAllText(name[i], Encoding.UTF8);
                    texts +=text[i];
                }
                Console.WriteLine("Enter the path of the new file.");
                var path = Console.ReadLine();
                File.WriteAllText(path, texts, Encoding.UTF8);
                Console.WriteLine(File.ReadAllText(path, Encoding.UTF8));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

}
