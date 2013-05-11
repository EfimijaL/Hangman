using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Hangman
{
    class Data
    {
        public List<String> Words { get; set; }

        public Data(String level) {
            Words = new List<string>();
            StreamReader file;
            string path = @"../../Resources/words.txt";
            if (File.Exists(path))
            {
                file = new StreamReader(path);
                string lines;
                bool flag = false;
                while ((lines = file.ReadLine()) != null)
                {
                    lines = Coding.DecryptString(lines.TrimEnd('\n','\r'));
                    if (lines.StartsWith("*") && lines.EndsWith("*"))
                    {
                        if (lines.ToLower().Equals(string.Format("*{0}*", level.ToLower())))
                            flag = true;
                        else flag = false;
                        continue;
                    }
                    if (flag && lines.Length>0)
                        Words.Add(lines);
                }
            }
        
        }
    }
}
