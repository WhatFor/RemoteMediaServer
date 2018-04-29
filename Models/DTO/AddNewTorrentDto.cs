namespace RemoteTorrentServer.Models.DTO
{
    public class AddNewTorrentDto
    {
        public string MagnetLink { get; set; }
        
        public string DownloadLocation { get; set; }

        public bool AutoStart { get; set; }
    }
}