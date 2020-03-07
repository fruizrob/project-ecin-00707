import React, { Component } from 'react';
import moment from 'moment';

export default class Timer extends Component {

    state = {
        time: this.props.time
    }

    updateTime = () => {
        let seconds = moment().diff(this.props.start, 'seconds')

        const formatted = moment.utc(seconds*1000).format('HH:mm:ss');

        this.setState({
            time: formatted
        })
    }

    componentDidMount = () => {
        this.updateTime();
        this.timer = setInterval(() => this.updateTime(), 1000)
    }

    componentWillUnmount = () => {
        clearInterval(this.timer);
        this.timer = null;
    }
    
    render() {
        return <p>{this.state.time}</p>
    }
}