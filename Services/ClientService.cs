using Microsoft.Extensions.Options;
using RemoteTorrentServer.Models.Configuration;
using RemoteTorrentServer.Services.Contracts;
using System.Diagnostics;

namespace RemoteTorrentServer.Services
{
    public class ClientService : IClientService
    {
        private Process process;
        private readonly TorrentConfig config;

        public string DownloadLocation { get; set; }

        public ClientService(IOptions<TorrentConfig> torrentConfigWrapper)
        {
            config = torrentConfigWrapper.Value;

            DownloadLocation = config.DefaultDownloadLocation;
        }

        public Process GetProcess()
        {
            if (process == null)
            {
                var torrentProcess = new Process();

                torrentProcess.StartInfo.UseShellExecute = false;
                torrentProcess.StartInfo.RedirectStandardOutput = true;
                torrentProcess.StartInfo.FileName = "aria2c";
                torrentProcess.Start();
                process = torrentProcess;
            }

            return process;
        }

        public void Kill()
        {
            process.Kill();
        }
    }
}