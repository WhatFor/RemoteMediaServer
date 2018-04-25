using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteTorrentServer.Models;
using RemoteTorrentServer.Services.Contracts;

namespace RemoteTorrentServer.Services
{
    public class TorrentService : ITorrentService
    {
        private readonly IClientService client;

        public TorrentService(IClientService client)
        {
            this.client = client;
        }

        public async Task<List<Torrent>> GetAllTorrentsAsync()
        {
            return await client.GetAllTorrentsAsync();
        }

        public async Task<Torrent> ImportTorrentAsync(string magnetLink, string downloadLocation = null, bool autoStart = true)
        {
            return await client.AddNewTorrentByMagnetAsync(magnetLink);
        }
    }
}