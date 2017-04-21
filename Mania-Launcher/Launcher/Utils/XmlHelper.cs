using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Mania.Launcher.Config;

namespace Mania.Launcher.Utils
{
    class XmlHelper
    {

        private string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppFolder.APP_DATA_FOLDER_NAME);
        private string conftemporaryFile = Path.Combine(LocalConfiguration.Instance.Files.ConfTempDataFile);
        private string configFile = Path.Combine(LocalConfiguration.Instance.Files.ConfDataFile);

        public string GetSettingValue(string key)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(this.configFile);
            foreach (XmlNode xmlNode in xmlDocument.SelectSingleNode("configuration/appSettings"))
            {
                if (xmlNode.Attributes["key"].Value == key)
                {
                    return xmlNode.Attributes["value"].Value;
                }
            }
            return "";
        }

        public void UpdateSettingValue(string key, string value)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(this.configFile);
            foreach (XmlNode xmlNode in xmlDocument.SelectSingleNode("configuration/appSettings"))
            {
                if (xmlNode.Attributes["key"].Value == key)
                {
                    xmlNode.Attributes["value"].Value = value;
                }
            }
            xmlDocument.Save(this.configFile);
        }

    }
}
