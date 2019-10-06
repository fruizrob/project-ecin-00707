import React, { Component } from 'react';
import './PatientDetail.css';

export default class PatientDetail extends Component {

    render() {
        return (
            <div className="patient-page">
                <p>Patient {this.props.match.params.id}</p>
            </div>
        )
    }
}