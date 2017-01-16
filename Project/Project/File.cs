using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.IO;

namespace Project
{
    class File
    {
        public static List<string[]> readFile()
        {
            try
            {
                Stream stream = TitleContainer.OpenStream("saveGame.sav");
                StreamReader sreader = new StreamReader(stream);
                // use StreamReader.ReadLine or other methods to read the file data
                List<string[]> data;
                data = new List<string[]>();
                string line;
                while ((line = sreader.ReadLine() )!= null)
                    data.Add(line.Split(','));
                
                stream.Close();
                return data;
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
                using (var writer = new StreamWriter(@"saveGame.sav"))
                {
                    writer.WriteLine(data);
                }
                return true;
            }
            catch(FileNotFoundException)
            {
                return false;
            }
        }
    }
}
