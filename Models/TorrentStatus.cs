namespace RemoteTorrentServer.Models
{
    /// <summary>
    /// Represents the current state of a given torrent.
    /// </summary>
    public enum TorrentStatus
    {
        Error,
        PausedUp,
        PausedDL,
        QueuedUp,
        QueuedDL,
        Uploading,
        StalledUp,
        CheckingUp,
        CheckingDL,
        Downloading,
        StalledDL,
        MetaDL,
    }
}