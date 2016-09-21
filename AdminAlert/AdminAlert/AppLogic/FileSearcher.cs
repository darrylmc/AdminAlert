using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminAlert.AppLogic
{
    public class FileSearcher
    {
        private string folderPath;
        private string pattern;

        public FileSearcher(string folderPath, string pattern)
        {
            this.folderPath = folderPath;
            this.pattern = pattern;
        }

        public List<SearchResult> Search()
        {
            List<SearchResult> searchResults = new List<SearchResult>();
            string[] files = Directory.GetFiles(folderPath);
            foreach (string file in files)
            {
                SearchResult sr = new SearchResult()
                {
                    FilePath = file.ToString(),
                    LastWriteTime = File.GetLastWriteTime(file),
                    Matches = new List<string>()
                };

                string[] lines = File.ReadAllLines(file);
                foreach (string line in lines)
                {
                    if (line.Contains(pattern))
                    {
                        sr.Matches.Add(line);
                    }
                }

                if (sr.Matches.Count > 0)
                {
                    searchResults.Add(sr);
                }
            }

            return searchResults;

        }
    }
}
