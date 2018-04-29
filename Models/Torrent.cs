using RemoteTorrentServer.Extensions;
using System.ComponentModel.DataAnnotations;

namespace RemoteTorrentServer.Models
{
    /// <summary>
    /// A representation of the Torrent model returned from qBittorrent.
    /// </summary>
    public class Torrent
    {
        /// <summary>
        /// Torrent hash.
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// The torrent name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Torrent total size in bytes.
        /// </summary>
        public ulong Size { get; set; }

        /// <summary>
        /// Total progress percentage.
        /// </summary>
        public decimal Progress { get; set; }

        /// <summary>
        /// Download speed, bytes per second.
        /// </summary>
        public ulong DLSpeed { get; set; }

        /// <summary>
        /// Upload speed, bytes per second.
        /// </summary>
        public ulong UpSpeed { get; set; }

        /// <summary>
        /// Torrent priority. Returns -1 if queueing is disabled, or torrent is in seed mode.
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Total number of connected seeds.
        /// </summary>
        public int Num_Seeds { get; set; }

        /// <summary>
        /// Total number of seeds in swarm.
        /// </summary>
        public int Num_Complete { get; set; }

        /// <summary>
        /// Total number of leeches connected to.
        /// </summary>
        public int Num_Leechs { get; set; }

        /// <summary>
        /// Total number of leaches in swarm.
        /// </summary>
        public int Num_Incomplete { get; set; }

        /// <summary>
        /// Torrent share ratio. Max value: 9999.
        /// </summary>
        public decimal Ratio { get; set; }

        /// <summary>
        /// Estimated torrent ETA in seconds.
        /// </summary>
        public int Eta { get; set; }

        /// <summary>
        /// Sequental Download enabled?
        /// </summary>
        public bool Seq_Dl { get; set; }

        /// <summary>
        /// First/Last piece proiritised?
        /// </summary>
        public bool F_L_Piece_Prio { get; set; }

        /// <summary>
        /// Category of torrent.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Super seeding enabled?
        /// </summary>
        public bool Super_Seeding { get; set; }

        /// <summary>
        /// Force start enabled?
        /// </summary>
        public bool Force_Start { get; set; }

        /// <summary>
        /// State of the torrent.
        /// </summary>
        public TorrentStatus State { get; set; }

        /// <summary>
        /// Get the State enum value as it's display value.
        /// </summary>
        public string StateDisplay => State.GetAttribute<DisplayAttribute>().Name;
    }
}