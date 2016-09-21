using AdminAlert.AppLogic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminAlert
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ProgramSettings settings = new ProgramSettings();

                switch (settings.AppMode)
                {
                    case AppModeEnum.FileSearch:
                        FileSearcher fs = new FileSearcher(settings.FolderPath, settings.SearchPattern);
                        List<SearchResult> results = fs.Search();
                        if (results.Count > 0)
                        {
                            MailgunClient mgc = new MailgunClient()
                            {
                                MailgunDomain = settings.MailgunDomain,
                                MailgunApiKey = settings.MailgunApiKey
                            };

                            StringBuilder filesFound = new StringBuilder();
                            StringBuilder linesFound = new StringBuilder();

                            foreach (SearchResult sr in results)
                            {
                                filesFound.Append(String.Format("{0}: {1}",sr.LastWriteTime, sr.FilePath + Environment.NewLine));
                                foreach (string line in sr.Matches)
                                {
                                    linesFound.Append(line + Environment.NewLine);
                                }
                            }

                            mgc.SendMessage(settings.SendTo, settings.Customer, settings.AlertDetails, filesFound + "\n" + linesFound);
                        }
                        break;
                    default:
                        Console.WriteLine("No Valid AppMode!");
                        break;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
