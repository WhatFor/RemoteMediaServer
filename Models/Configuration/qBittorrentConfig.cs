namespace RemoteTorrentServer.Models.Configuration
{
    /// <summary>
    /// qBittorrent Web API Authentication Details.
    /// </summary>
    public class qBittorrentConfig
    {
        public string ServiceUri { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}