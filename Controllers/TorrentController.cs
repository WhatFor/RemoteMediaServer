using Microsoft.AspNetCore.Mvc;
using RemoteTorrentServer.Models;
using RemoteTorrentServer.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RemoteTorrentServer.Controllers
{
    [Route("api/torrent")]
    public class TorrentController : Controller
    {
        private readonly ITorrentService torrentService;

        public TorrentController(ITorrentService torrentService)
        {
            this.torrentService = torrentService;
        }

        [HttpGet]
        public async Task<List<Torrent>> GetAllTorrentsAsync()
        {
            return await torrentService.GetAllTorrentsAsync();
        }

        [HttpPost]
        public async Task<Torrent> AddNewTorrentAsync(string magnetLink, string downloadLocation = null, bool autoStart = true)
        {
            return await torrentService.ImportTorrentAsync(magnetLink);
        }
    }
}