using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BearFTP
{
    class Config
    {
        public int PortDef = 21;
        public int PortPasv = 21;
        public string Hostname = "127.0.0.1";
        public string Token = "";

        public bool Report = true;
        public bool Ban = true;
        public bool PunishScans = true;

        public string Banner = "Welcome to FTP!";

        public List<CJSON_FILE> files;
        
        static string PlaceHolder = "{\r\n"+
  "\"PortDef\": 21,\r\n"+
  "\"PortPasv\": 21,\r\n"+
  "\"Hostname\": \"127.0.0.1\",\r\n" +
  "\"Token\": \"\",\r\n" +
  "\"Report\": true,\r\n" +
  "\"Ban\": true,\r\n" +
  "\"PunishScans\": true,\r\n" +
  "\"Files\": [{\r\n" +
  "  \"Name\": \"readme.txt\",\r\n" +
  "  \"Content\": \"Please, dont insert content which is more than 2048 bytes!\"\r\n" +
  "}],\r\n" +
  "\"Banner\": \"Welcome to FTP!\"\r\n" +
"}";

        public Config(string name)
        {
            CJSON json = null;
            try
            {
                if (System.IO.File.Exists(name))
                {
                    string config = System.IO.File.ReadAllText(name);
                    json = JsonConvert.DeserializeObject<CJSON>(config);
                }
                else
                {
                    json = JsonConvert.DeserializeObject<CJSON>(PlaceHolder);
                    System.IO.File.WriteAllText(name, PlaceHolder);
                }
                PortDef = json.PortDef;
                PortPasv = json.PortPasv;
                Hostname = json.Hostname;
                Token = json.Token;
                Report = json.Report;
                Ban = json.Ban;
                PunishScans = json.PunishScans;

                //For files handling to go Program.cs
                files = json.Files;

                Banner = json.Banner; //DID YOU KNOW?: Use %host% for it to be replaced with your current hostname!

            } catch (JsonReaderException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("---> CANNOT CONTINUE! Config corrupt.");
                Environment.Exit(1);
            }
            
        }
    }

    public class CJSON_FILE
    {
        public string Name { get; set; }
        public string Content { get; set; }
    }
    public class CJSON
    {
        public int PortDef { get; set; }
        public int PortPasv { get; set; }
        public string Hostname { get; set; }
        public string Token { get; set; }
        public bool Report { get; set; }
        public bool Ban { get; set; }
        public bool PunishScans { get; set; }
        public List<CJSON_FILE> Files { get; set; }
        public string Banner { get; set; }
    }
}
