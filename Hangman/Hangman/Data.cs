using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Hangman
{
    class Data
    {
        public List<String> Easy { get; set; }
        public List<String> Normal { get; set; }
        public List<String> Hard { get; set; }

        public Data() {
            Easy = new List<string>();
            Normal = new List<string>();
            Hard = new List<string>();
            bool easy=false;
            bool normal=false;
            bool hard = false;
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
                        if (lines.ToLower().Equals(string.Format("*easy*")))
                        {
                            easy = true;
                            normal = false;
                            hard = false;
                            flag = true;
                        }
                        else if (lines.ToLower().Equals(string.Format("*normal*")))
                        {
                            easy = false;
                            normal = true;
                            hard = false;
                            flag = true;
                        }
                        else if (lines.ToLower().Equals(string.Format("*hard*")))
                        {
                            easy = false;
                            normal = false;
                            hard = true;
                            flag = true;
                        }
                    }
                    else
                        flag = false;
                    if (!flag && lines.Length > 0)
                    {
                        if(easy)
                            Easy.Add(lines);
                        if (normal)
                            Normal.Add(lines);
                        if (hard)
                            Hard.Add(lines);
                    }
                }
                file.Close();
            }           
        }

        public List<String> getWords(String level) { 
            if(level.ToLower().Equals("easy"))
                return Easy;
            else if(level.ToLower().Equals("normal"))
                return Normal;
            else
                return Hard;
        }
    }
}
