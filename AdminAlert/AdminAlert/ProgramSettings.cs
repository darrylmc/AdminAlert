using AdminAlert.AppLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdminAlert
{
    public class ProgramSettings
    {
        private AppModeEnum _appMode;
        private string _customer;
        private string _alertDetails;
        private string _sendTo;
        private string _mailgunDomain;
        private string _mailgunApiKey;
        private string _folderPath;
        private string _searchPattern;

        public AppModeEnum AppMode
        {
            get
            {
                return _appMode;
            }
            private set
            {
                _appMode = value;
            }
        }

        public string Customer
        {
            get
            {
                return _customer;
            }
            private set
            {
                _customer = value;
            }
        }

        public string AlertDetails
        {
            get
            {
                return _alertDetails;
            }
            private set
            {
                _alertDetails = value;
            }
        }

        public string SendTo
        {
            get
            {
                return _sendTo;
            }
            private set
            {
                _sendTo = value;
            }
        }

        public string MailgunDomain
        {
            get
            {
                return _mailgunDomain;
            }
            private set
            {
                _mailgunDomain = value;
            }
        }

        public string MailgunApiKey
        {
            get
            {
                return _mailgunApiKey;
            }
            private set
            {
                _mailgunApiKey = value;
            }
        }

        public string FolderPath
        {
            get
            {
                return _folderPath;
            }
            private set
            {
                _folderPath = value;
            }
        }

        public string SearchPattern
        {
            get
            {
                return _searchPattern;
            }
            private set
            {
                _searchPattern = value;
            }
        }

        public ProgramSettings()
        {
            _appMode = (AppModeEnum)Enum.Parse(typeof(AppModeEnum), GetPropertyValue("AppMode"));
            _customer = GetPropertyValue("Customer");
            _alertDetails = GetPropertyValue("AlertDetails");
            _sendTo = GetPropertyValue("SendTo");
            _mailgunDomain = GetPropertyValue("MailgunDomain");
            _mailgunApiKey = GetPropertyValue("MailgunApiKey");
            _folderPath = GetPropertyValue("FolderPath");
            _searchPattern = GetPropertyValue("SearchPattern");
        }

        private String GetPropertyValue(String element)
        {
            if (!File.Exists("properties.xml"))
            {
                throw new Exception("The properties file (properties.xml) cannot be found! Please make sure this is in the same directory as the executable");
            }
            XElement root = XElement.Load("properties.xml");
            String value = "";
            foreach (XElement e in root.Descendants(element))
            {
                value = e.Value;
            }

            return value;
        }
    }
}
