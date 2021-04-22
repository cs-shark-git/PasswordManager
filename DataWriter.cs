using System;
using System.Collections.Generi
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace PasswordManager
{
    class DataWriter
    {
        private string data;
        private string fileName;
        private string appFolder = Assembly.GetExecutingAssembly().Location.Substring(0, Assembly.GetExecutingAssembly().Location.LastIndexOf('\\'));
        public DataWriter(string data, string fileName)
        {
            this.data = data;
            this.fileName = fileName;

            Directory.CreateDirectory(appFolder + "\\Data");
            File.Create(appFolder + $"\\Data\\{fileName}").Close();
        }

        public async void WriteAsync()
        {
            using(StreamWriter sw = new StreamWriter(appFolder + $"\\Data\\{fileName}"))
            {
                await sw.WriteLineAsync(data);
            }
        }
    }
}
