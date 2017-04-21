using System.IO;

namespace Mania.Launcher.Config
{
    internal class AppFiles
    {
        private const string CONF_TEMPORARY_FILE = "MapleStoryMania.Default.xml.cfg";
        private const string CONFIG_FILE = "MapleStoryMania.Default.cfg";
        
        public AppFiles(AppFolder folders)
        {
 
            string configTempData = folders.GetPath(WowLauncherFolder.AppData);
            ConfTempDataFile = Path.Combine(configTempData, CONF_TEMPORARY_FILE);

            string configData = folders.GetPath(WowLauncherFolder.AppData);
            ConfDataFile = Path.Combine(configData, CONFIG_FILE);
        }


        public string ConfTempDataFile { get; private set; }
        public string ConfDataFile { get; private set; }
    }
}