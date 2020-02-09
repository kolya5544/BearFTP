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
        public string Banner = "Welcome to FTP!";

        public bool Report = true;
        public bool Ban = true;
        public bool PunishScans = true;
        public bool AllowAnonymous = false;
        public bool PerIPLogs = false;

        public int Max_PerSecond = 5;
        public int Max_Total = 6;
        public int BanLength = 3600;
        public int MaxErrors = 6;
        public int BufferSize = 8192;

        

        public List<CJSON_FILE> files;
       

        public Config(string name)
        {
            CJSON json = null;
            string Placeholder = Properties.Resources.ConfigFile;
            try
            {
                if (System.IO.File.Exists(name))
                {
                    string config = System.IO.File.ReadAllText(name);
                    json = JsonConvert.DeserializeObject<CJSON>(config);
                }
                else
                {
                    json = JsonConvert.DeserializeObject<CJSON>(Placeholder);
                    System.IO.File.WriteAllText(name, Placeholder);
                }
                PortDef = json.PortDef;
                PortPasv = json.PortPasv;
                Hostname = json.Hostname;
                Token = json.Token;
                Banner = json.Banner; //DID YOU KNOW?: Use %host% for it to be replaced with your current hostname!
                Report = json.Report;
                Ban = json.Ban;
                PunishScans = json.PunishScans;
                AllowAnonymous = json.AllowAnonymous;
                Max_PerSecond = json.Max_PerSecond;
                Max_Total = json.Max_Total;
                BanLength = json.BanLength;
                MaxErrors = json.MaxErrors;
                BufferSize = json.BufferSize;
                PerIPLogs = json.PerIPLogs;
                


                //For files handling to go Program.cs
                files = json.Files;

                

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
        public string Banner { get; set; }
        public bool Report { get; set; }
        public bool Ban { get; set; }
        public bool PunishScans { get; set; }
        public bool AllowAnonymous { get; set; }
        public bool PerIPLogs { get; set; }
        public int Max_PerSecond { get; set; }
        public int Max_Total { get; set; }
        public int BanLength { get; set; }
        public int MaxErrors { get; set; }
        public int BufferSize { get; set; }
        public List<CJSON_FILE> Files { get; set; }
    }
}
