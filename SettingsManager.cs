using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MSBuildExample
{
    class SettingsManager
    {
        private Settings settings;

        public SettingsManager()
        {
            InitSettings();
        }

        private void InitSettings()
        {
            using (var reader = new StreamReader("settings.json"))
            {
                var content = reader.ReadToEnd();
                settings = JsonConvert.DeserializeObject<Settings>(content);
            }
        }

        public Settings GetSettings()
        {
            return settings;
        }
    }
}