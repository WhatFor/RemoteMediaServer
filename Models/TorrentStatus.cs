using System.ComponentModel.DataAnnotations;

namespace RemoteTorrentServer.Models
{
    /// <summary>
    /// Represents the current state of a given torrent.
    /// </summary>
    public enum TorrentStatus
    {
        [Display(Name = "Error")]
        Error,
        [Display(Name = "Upload Paused")]
        PausedUp,
        [Display(Name = "Download Paused")]
        PausedDL,
        [Display(Name = "Upload Queued")]
        QueuedUp,
        [Display(Name = "Download Queued")]
        QueuedDL,
        [Display(Name = "Uploading")]
        Uploading,
        [Display(Name = "Upload Stalled")]
        StalledUp,
        [Display(Name = "Upload Check")]
        CheckingUp,
        [Display(Name = "Download Check")]
        CheckingDL,
        [Display(Name = "Downloading")]
        Downloading,
        [Display(Name = "Download Stalled")]
        StalledDL,
        [Display(Name = "Downloading Meta")]
        MetaDL,
    }
}