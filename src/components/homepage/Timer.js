import React, { Component } from 'react';
import moment from 'moment';

export default class Timer extends Component {

    state = {
        time: this.props.time
    }

    componentDidMount = () => {
        setInterval(() => {
            let seconds = moment().diff(this.props.start, 'seconds')

            const formatted = moment.utc(seconds*1000).format('HH:mm:ss');

            this.setState({
                time: formatted
            })
        }, 1000)
    }
    
    render() {
        return <p>{this.state.time}</p>
    }
}