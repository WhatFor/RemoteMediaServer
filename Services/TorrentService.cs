using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using RemoteTorrentServer.Models;
using RemoteTorrentServer.Services.Contracts;

namespace RemoteTorrentServer.Services
{
    public class TorrentService : ITorrentService
    {
        private readonly IClientService client;
        private readonly Process process;

        public TorrentService(IClientService client)
        {
            this.client = client;
            this.process = client.GetProcess();
        }

        public List<Torrent> GetAllTorrentsAsync()
        {
            return new List<Torrent>
            {
                new Torrent { Id = 1, TorrentName = "Torrent 1", Status = TorrentStatus.Pending, },
                new Torrent { Id = 2, TorrentName = "Torrent 2", Status = TorrentStatus.Pending, },
            };
        }

        public string GetDownloadLocation()
        {
            return client.DownloadLocation;
        }

        public Task<Torrent> ImportTorrentAsync(string magnetLink, string downloadLocation = null, bool autoStart = true)
        {
            throw new System.NotImplementedException();
        }

        public void SetDownloadLocation(string location)
        {
            client.DownloadLocation = location;
        }
    }
}
