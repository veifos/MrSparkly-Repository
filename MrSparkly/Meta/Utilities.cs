using MrSparkly.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrSparkly.Meta
{
    public static class Utilities
    {
        public const string DB_FILE = @"Data\Sparkly1.accdb";
        public static Employee User;

    public static void Log (string s)
    {
        using (StreamWriter r = new StreamWriter("Sparkly.log", true))
            {
                r.WriteLine(string.Format("[{0}] {1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), s));
            }
        }
    }

}
