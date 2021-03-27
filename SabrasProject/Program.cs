using System;
using System.Collections.Generic;
using System.IO;

namespace SabrasProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public void WalkDirectoryTree(DirectoryInfo directorySelected, List<FileInfo> allFoundFiles, string searchPattern)
        {
            FileInfo[] stuff = null;
            DirectoryInfo[] subDirectories = null;
            try
            {
                stuff = directorySelected.GetFiles(searchPattern);
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException e)
            {
                // TODO: Add a password prompt
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            if (stuff != null)
            {
                foreach (FileInfo fi in stuff)
                {
                    allFoundFiles.Add(fi);
                }
            }

            // Now find all the subdirectories under this directory.
            subDirectories = directorySelected.GetDirectories();

            foreach (DirectoryInfo dirInfo in subDirectories)
            {
                // Recursive call for each subdirectory.
                WalkDirectoryTree(dirInfo, allFoundFiles, searchPattern);
            }
        }
    }


}
