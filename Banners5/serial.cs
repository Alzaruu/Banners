using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banners5
{
    internal class serial
    {
        public static T MyDeser<T>()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                string json = File.ReadAllText(dialog.FileName);
                T serials = JsonConvert.DeserializeObject<T>(json);
                return serials;
            }
            else
            {
                return default(T);
            }
        }
    }
}
