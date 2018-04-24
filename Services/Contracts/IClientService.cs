using RemoteTorrentServer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RemoteTorrentServer.Services.Contracts
{
    public interface IClientService
    {
        Task<List<Torrent>> GetAllTorrentsAsync();
    }
}