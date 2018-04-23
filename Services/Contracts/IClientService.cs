using System.Diagnostics;

namespace RemoteTorrentServer.Services.Contracts
{
    public interface IClientService
    {
        Process GetProcess();

        string DownloadLocation { get; set; }

        void Kill();
    }
}
