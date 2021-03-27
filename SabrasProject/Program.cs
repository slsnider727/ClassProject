using System;
using System.Collections.Generic;
using System.IO;

namespace SabrasProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var methods = new Methods();

            var fileInfoList = new List<FileInfo>();
            var searchPattern = methods.GetSearchPatternFromUser();
            var directoryInfo = methods.GetDirectoryFromUser();
            methods.GetFileListFromRecursiveDirectorySearch(directoryInfo, fileInfoList, searchPattern);
            foreach (var fileInfo in fileInfoList)
            {
                Console.WriteLine("I found these files based on your search pattern:");
                Console.WriteLine(fileInfo.ToString());
            }
            Console.ReadKey();
        }
    }

    public class Methods
    {
        public void GetFileListFromRecursiveDirectorySearch(DirectoryInfo directoryInfo, List<FileInfo> fileInfoList, string searchPattern)
        {
            FileInfo[] fileInfoArray = null;
            DirectoryInfo[] initialDirectoryInfo = null;
            try
            {
                //throw random comment in to explain
                fileInfoArray = directoryInfo.GetFiles(searchPattern);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            if (fileInfoArray != null)
            {
                foreach (FileInfo fileInfo in fileInfoArray)
                {
                    fileInfoList.Add(fileInfo);
                }
            }
            initialDirectoryInfo = directoryInfo.GetDirectories();
            foreach (DirectoryInfo dirInfo in initialDirectoryInfo)
            {
                GetFileListFromRecursiveDirectorySearch(dirInfo, fileInfoList, searchPattern);
            }
        }

        public DirectoryInfo GetDirectoryFromUser()
        {
            Console.WriteLine("What directory do you want to search?");
            var directoryChoice = Console.ReadLine();
            return new DirectoryInfo(directoryChoice);
        }

        public string GetSearchPatternFromUser()
        {
            Console.WriteLine("What is your search pattern?");
            return Console.ReadLine();
        }
    }


}
