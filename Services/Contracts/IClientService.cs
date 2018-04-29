using Microsoft.AspNetCore.Http;
using RemoteTorrentServer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RemoteTorrentServer.Services.Contracts
{
    public interface IClientService
    {
        Task<Torrent> AddNewTorrentByMagnetAsync(string magnet);

        Task<List<Torrent>> GetAllTorrentsAsync();
    }
}