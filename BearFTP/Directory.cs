using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BearFTP
{
    class Directory
    {
        //TODO: Implement directories
        public string path;
        public List<File> files = new List<File>();
        public List<Directory> dirs = new List<Directory>();
    }
}
