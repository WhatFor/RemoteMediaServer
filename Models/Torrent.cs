using System.ComponentModel.DataAnnotations;

namespace RemoteTorrentServer.Models
{
    public class Torrent
    {
        [Key]
        public int Id { get; set; }

        public string TorrentName { get; set; }

        public string MagnetLink { get; set; }

        public TorrentStatus Status { get; set; }
    }
}
