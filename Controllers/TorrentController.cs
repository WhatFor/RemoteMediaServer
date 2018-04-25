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

        [HttpGet("all")]
        public async Task<List<Torrent>> GetAllTorrentsAsync()
        {
            return await torrentService.GetAllTorrentsAsync();
        }

        [HttpPost("magnet")]
        public async Task<Torrent> AddNewTorrentAsync([FromForm]string magnetLink, [FromForm]string downloadLocation = null, [FromForm]bool autoStart = true)
        {
            return await torrentService.ImportTorrentAsync(magnetLink);
        }
    }
}