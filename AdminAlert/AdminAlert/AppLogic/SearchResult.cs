using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminAlert.AppLogic
{
    public class SearchResult
    {
        public string FilePath { get; set; }
        public DateTime LastWriteTime { get; set; }
        public List<string> Matches { get; set; }
    }
}
