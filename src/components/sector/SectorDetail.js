import React, { Component } from 'react';
import './SectorDetail.css';

export default class SectorDetail extends Component {
    render() {

        return (
            <section className="sector-page">
                <p>Sector Page {this.props.match.params.id}</p>
            </section>
        )
    }
}