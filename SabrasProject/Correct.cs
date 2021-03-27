using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SabrasProject
{
    public class Correct
    {
        public void WalkDirectoryTree(DirectoryInfo directorySelected, List<FileInfo> allFoundFiles)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirectories = null;

            // First, process all the files directly under this folder
            try
            {
                files = directorySelected.GetFiles("*.gz*");
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException e)
            {
                // Just writes out the message and continues to recurse, doesn't try anything fancy.
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            if (files != null)
            {
                foreach (FileInfo fi in files)
                {
                    allFoundFiles.Add(fi);
                }
            }

            // Now find all the subdirectories under this directory.
            subDirectories = directorySelected.GetDirectories();

            foreach (DirectoryInfo dirInfo in subDirectories)
            {
                // Recursive call for each subdirectory.
                WalkDirectoryTree(dirInfo, allFoundFiles);
            }
        }

    }
}
