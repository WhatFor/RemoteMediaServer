import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface AllTorrentsState {
    torrents : Torrent[];
    loading: boolean;
    downloadLocation: string;
}

interface TorrentConfig {
    downloadLocation: string;
}

export class AllTorrents extends React.Component<RouteComponentProps<{}>, AllTorrentsState> {
    constructor() {
        super();
        this.state = { torrents: [], loading: true, downloadLocation: '' };

        // Get torrent list
        fetch('api/torrent')
            .then(response => response.json() as Promise<Torrent[]>)
            .then(data => {
                this.setState({ torrents: data, loading: false });
            });

        // Get download location
        fetch('api/torrent/download-location')
            .then(res => res.json() as Promise<TorrentConfig>)
            .then(config => {
                console.log(location);
                this.setState({ downloadLocation: config.downloadLocation });
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : AllTorrents.renderTorrentsTable(this.state.torrents);

        return <div>
            <h1>All Torrents</h1>
            {contents}
            <p>Downloading to: { this.state.downloadLocation }.</p>
        </div>;
    }

    private static renderTorrentsTable(torrents: Torrent[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Status</th>
                </tr>
            </thead>
            <tbody>
                { torrents.map(torrent =>
                <tr key={ torrent.id }>
                    <td>{ torrent.torrentName }</td>
                    <td>{ torrent.status }</td>
                    <td>{ torrent.magnetLink }</td>
                </tr>
            )}
            </tbody>
        </table>;
    }
}

interface Torrent {
    id: number;
    torrentName: string;
    magnetLink: string;
    status: number;
}
