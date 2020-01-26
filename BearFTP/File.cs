using System;
using System.Collections.Generic;
using System.Text;

namespace BearFTP
{
    class File
    {
        public string name = "";
        public string chmod = "";
        public string creation = "";
        public int size = 0;
        public byte[] content = new byte[2048];
        public Directory dir;
        public File(string name, int size, string chmod, string creation, string content, Directory dir)
        {
            this.name = name;
            this.size = size;
            this.chmod = chmod;
            this.creation = creation;
            if (content.Length < 2048)
            {
                //TODO: Implement transfer of files larger than 2 kbs.
                this.content = new byte[content.Length];
            }
            this.content = Encoding.ASCII.GetBytes(content);
            this.dir = dir;
        }
        public File(string name, int size, string chmod, string creation, byte[] content, Directory dir)
        {
            this.name = name;
            this.size = size;
            this.chmod = chmod;
            if (content.Length < 2048)
            {
                //TODO: Implement transfer of files larger than 2 kbs.
                this.content = new byte[content.Length];
            }
            this.creation = creation;
            this.content = content;
            this.dir = dir;
        }
    }
}
