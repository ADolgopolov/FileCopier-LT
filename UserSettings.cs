using FileCopier.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FileCopier
{
    public class UserSettings
    {
        public struct SettingsStruct
        {
            public string SourceBaseFolder;
            public bool isAutoCloseProgram;
        }

        private SettingsStruct ss;

        public string SourceBaseFolder {
            get { return ss.SourceBaseFolder; }
            set { ss.SourceBaseFolder = value; }
            }

        public bool isAutoCloseProgram { 
            get { return ss.isAutoCloseProgram; }
            set { ss.isAutoCloseProgram = value; }
        }

        public UserSettings() {

            XmlSerializer serializer = new XmlSerializer(typeof(SettingsStruct));
            ss = new SettingsStruct(); // Ініціалізуємо ss, щоб уникнути можливості нульового значення

            string filePath = Path.Combine(Application.StartupPath, "userSettings.xml");

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    var deserialized = serializer.Deserialize(reader);
                    if (deserialized != null)
                    {
                        ss = (SettingsStruct)deserialized;
                    }
                    if (String.IsNullOrEmpty(ss.SourceBaseFolder))
                        ss.SourceBaseFolder = String.Empty;
                }
            }
        }

        public void SaveSettings()
        {
            // Шлях до файлу
            string filePath = Path.Combine(Application.StartupPath, "userSettings.xml");

            // Створити XmlSerializer для MySettings класу
            XmlSerializer serializer = new XmlSerializer(typeof(SettingsStruct));

            // Відкрити файл для запису
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Серіалізувати об'єкт та зберегти у файл
                serializer.Serialize(writer, ss);
            }
        }
    }
}
