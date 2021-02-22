using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PasswordManager
{
    static class FirstLaunch
    {
        static public bool CheckLaunch(string path)   // Checking on first launch in this PC.
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
