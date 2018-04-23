using RemoteTorrentServer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RemoteTorrentServer.Services.Contracts
{
    public interface ITorrentService
    {
        List<Torrent> GetAllTorrentsAsync();

        Task<Torrent> ImportTorrentAsync(string magnetLink, string downloadLocation = null, bool autoStart = true);

        string GetDownloadLocation();

        void SetDownloadLocation(string location);
    }
}
