using System;
using System.Collections.Generic;
using System.IO;

namespace SabrasProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var something = new Methods();
            Console.WriteLine("Hello World!");
            var green = new List<FileInfo>();
            var pink = something.Beep();
            var thing = something.Boop();
            //This is where Zhu Li does the thing.
            something.ZhuLiDoTheThing();
        }
    }

    public class Methods
    {
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

        public DirectoryInfo Boop()
        {
            Console.WriteLine("Where are we?");
            var thing = Console.ReadLine();
            return new DirectoryInfo(thing);
        }

        public string Beep()
        {
            Console.WriteLine("So tell me what you want, what you really really want.");
            return Console.ReadLine();
        }
    }


}
