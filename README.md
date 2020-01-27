# BearFTP
#### Dare to hack a bear?

BearFTP is a honeypot FTP server, designed to log hackers' attempts and report them to public IP blacklist databases.

## Featuring:

  - Configuration support (no need to recompile)
  - Edit files and content of files located on server
  - Tested on FileZilla and WinSCP.
  - AntiNmap, AntiMetasploit, Report even those ones, who try to download **your** files!
  - Works on both Windows and Linux
  - Pure TCPClients, expect good performance!
  - PASV mode support (only PASV, for now...)


This software was tested and runs perfectly on:
  - Windows 10 x64 (.NET CORE 3.1)
  - Linux Ubuntu 18.04

### Technologies

We use several projects as dependencies to run smoothly:

* [https://www.newtonsoft.com/json] - JSON converter!
* [https://www.abuseipdb.com/] - Public IP blacklist database

### Installation

BearFTP requires .NET Core 3.1 or higher.

Download binaries from Release tab or compile it yourself.

If you are on Windows, run
```sh
C:/BearFTP/BearFTP/bin/Release/netcoreapp3.1> ./BearFTP.exe
```
For Linux, run
```sh
$ dotnet BearFTP.dll
```
The program should exit with an error. Proceed to editing the **config.json**
```json
{
  "PortDef": 21,
  "PortPasv": 21,
  "Hostname": "127.0.0.1",
  "Token": "",
  "Report": true,
  "Ban": true,
  "PunishScans": true,
  "Files": [{
    "Name": "readme.txt",
    "Content": "Please, dont insert content which is more than 2048 bytes!"
  }],
  "Banner": "Welcome to FTP!"
}
```
| Key | Value |
| ------ | ------ |
| PortDef | Replace with port you want to use for new connections (21 by default) |
| PortPasv | Replace with port for PASV mode (1222 by default) |
| Hostname | Replace with an actual public IPv4 of your PC/server. Used to initiate PASV connections. Please use IPv4, we dont support domains |
| Token | AbuseIPDB token to report bad ones |
| Report | Should we report suspicious actions? |
| Ban | Should we ban users on suspicious actions? (Ban is 1 hour long to prevent people from being double-reported) |
| PunishScans | Should we ban/report nmap scanners? |
| Files[] | Array of files. |
| Files[Name] | Filename |
| Files[Content] | Contents of files (string). Start with --- to make it load from a file (example: "---file.exe") |
| Banner | Banner sent right after TCP handshake. %host% will be replaced with current hostname |

To make it work, you should change PortPasv to any other value, so PortPasv is not equal to PortDef. Other options are optional.
**We highly dont recommend using files with size of more than 4 MB! You should not use honeypot as a real FTP server to share files!**

### Development

Want to contribute? Great!

We use VS2019 and .NET core 3.1 for development.

Here's our CURRENT todo list:
- Administrator commands (adding files right through FTP!)
- Local command handler (execute FTP commands in your console, ban spamming IPs and such)
- Implement directories
- Implement support of files with size more than 2 kbs
- Add more features (Active mode, more advanced ban system)


License
----

MIT