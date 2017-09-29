using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Game1
{
    class DebugLog
    {
        private string logLocation;
        private StreamWriter logger;
        public DebugLog(String fileLocation)
        {
            File.WriteAllText(fileLocation, "Beginning log file");
            logLocation = fileLocation;
            logger = new StreamWriter(fileLocation, true);
            logger.WriteLine("");
            logger.Close();
        }

        public void Write(String txt)
        {
            logger = new StreamWriter(logLocation, true);
           logger.WriteLine(txt);
            logger.Close();
        }

        public void Close()
        {
            logger.Close();
        }
    }
}
