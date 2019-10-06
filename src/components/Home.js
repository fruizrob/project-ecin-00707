import React, { Component } from 'react';
import { DragDropContext } from 'react-beautiful-dnd'
import Sector from './Sector';

import './Home.css';

export default class Home extends Component {

    render() {
        const { sectors, patients } = this.props.data;
        return (
            <section className="homepage">
                <DragDropContext
                    onDragEnd={this.props.onDragEnd}
                >
                    <div className="homepage-container">
                        {
                            sectors.map((sector, index) => {
                                const sectorPatients = sector.patientIds.map(id => {
                                    let obj;
                                    patients.forEach(patient => {
                                        if(patient.id === id)
                                            obj = patient;
                                    })
                                    return obj;
                                })

                                return (
                                    <Sector sector={sector} patients={sectorPatients} key={sector.id} />
                                )
                            })
                        }
                    </div>
                </DragDropContext>
            </section>
        )
    }
}

