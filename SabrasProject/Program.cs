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

        public void ZhuLiDoTheThing(DirectoryInfo something, List<FileInfo> purple, string searchPattern)
        {
            FileInfo[] stuff = null;
            DirectoryInfo[] subDirectories = null;
            try
            {
                stuff = something.GetFiles(searchPattern);
            }
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
                    purple.Add(fi);
                }
            }
            subDirectories = something.GetDirectories();

            foreach (DirectoryInfo dirInfo in subDirectories)
            {
                ZhuLiDoTheThing(dirInfo, purple, searchPattern);
            }
        }
    }


}
