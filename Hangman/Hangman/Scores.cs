using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Hangman
{
    class Scores
    {
        public int LowestScore { get; set; }
        public List<String> Results { get; set; }
        public Scores() {
            StreamReader file;
            Results = new List<string>();
            string path =@"../../scores.txt";
            if (File.Exists(path))
            {
                file = new StreamReader(path);
                string lines;
                while ((lines = file.ReadLine()) != null)
                {
                    Results.Add(lines);
                }
                file.Close();
            }
            updateLowest();
           
        }

        public void updateLowest() {
            if (Results.Count > 10)
            {
                string[] parts = Results[Results.Count-1].Split('\t');
                LowestScore = int.Parse(parts[1]);
            }
            else
                LowestScore = 0;
        }

        public void update(string name, int sc)
        {
            if (Results.Count == 0)
                Results.Add(string.Format("{0}\t{1}", name, sc));
            else
            {
                bool flag=true;
                for (int i = 0; i < Results.Count; i++)
                {
                    string[] parts = Results[i].Split('\t');
                    int temp = int.Parse(parts[1]);
                    if (temp >= sc)
                        continue;
                    else
                    {
                        Results.Insert(i, string.Format("{0}\t{1}", name, sc));
                        flag = false;
                        break;
                    }
                }
                if (flag)
                    Results.Insert(Results.Count, string.Format("{0}\t{1}", name, sc));
            }
            if (Results.Count > 10)
                Results.RemoveAt(11);
            updateLowest();
            Refresh();
        }

        public void Refresh() {
            StreamWriter file;
            string path = @"../../scores.txt";
            if (File.Exists(path))
            {
                file = new StreamWriter(path);
                for (int i = 0; i < Results.Count; i++)
                    file.WriteLine(Results[i]);
                file.Close();
            }
        }

        public string ListofPlayers()
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            for (i = 0; i < Results.Count-1; i++)
                sb.Append(string.Format("{0}\t {1}\n",(i+1),Results[i]));
            sb.Append(string.Format("{0}\t {1}", (i + 1), Results[i]));
            return sb.ToString();
        }
    }
}
