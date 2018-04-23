namespace RemoteTorrentServer.Models
{
    /// <summary>
    /// Represents the current state of a given torrent.
    /// </summary>
    public enum TorrentStatus
    {
        Pending = 0,
        Running = 1,
        Paused = 2,
        Stopped = 3,
        Completed = 4,
        Failed = 5,
    }
}