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

        public void ZhuLiDoTheThing(DirectoryInfo something, List<FileInfo> things, string s)
        {
            FileInfo[] stuff = null;
            DirectoryInfo[] otherstuff = null;
            try
            {
                stuff = something.GetFiles(s);
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
                foreach (FileInfo otherThing in stuff)
                {
                    things.Add(otherThing);
                }
            }
            otherstuff = something.GetDirectories();

            foreach (DirectoryInfo thing in otherstuff)
            {
                ZhuLiDoTheThing(thing, things, s);
            }
        }
    }


}
