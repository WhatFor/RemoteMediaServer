import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { FormEvent } from 'react';

interface AddNewState {
    magnet: string;
    downloadLocation: string;
    autoStart: boolean;
}

interface Event {
    preventDefault: Function;
    target: Target;
}

interface Target {
    value: string;
}

export class AddNew extends React.Component<RouteComponentProps<{}>, AddNewState> {
    constructor() {
        super();
        this.state = { magnet: '', downloadLocation: '', autoStart: false };
    }

    public render() {

        const handleChange = (event: Event) => {
            this.setState({ magnet: event.target.value });
        };

        const submitMagnet = (e: FormEvent<HTMLFormElement>) => {
            e.preventDefault();

            fetch('/api/torrent/magnet', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ magnetLink: this.state.magnet }),
            });
        };

        return (
            <form onSubmit={(e) => submitMagnet(e)}>
                <input type="text" value={this.state.magnet} onChange={(e) => handleChange(e)} />
                <input type="submit" value="Add Magnet"/>
            </form>
        )
    };
};
