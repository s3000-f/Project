using System;
using Microsoft.Xna.Framework;
using System.IO;

namespace Project
{
    class File
    {
        public static string[] readFile()
        {
            try
            {
                Stream stream = TitleContainer.OpenStream("saveGame.sav");
                StreamReader sreader = new StreamReader(stream);
                // use StreamReader.ReadLine or other methods to read the file data
                string line = sreader.ReadLine();

                Console.WriteLine("File Size: " + stream.Length);
                stream.Close();
                return line.Split(',');
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }
        public static bool writeFile(String data)
        {
            try
            {
                Stream stream = TitleContainer.OpenStream("saveGame.sav");
                StreamWriter swriter = new StreamWriter(stream);
                swriter.WriteLine(data);
                return true;
            }
            catch(FileNotFoundException)
            {
                return false;
            }
        }
    }
}
