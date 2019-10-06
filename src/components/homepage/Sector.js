import React from 'react';
import { Droppable } from 'react-beautiful-dnd';
import { Link } from 'react-router-dom';
import Patient from './Patient';
import addIcon from '../../add.svg';

import './Sector.css';

export default function Sector(props) {
    const { id, title, description, color } = props.sector;

    return (
        <div className="aux-container-sector">
            <div className="sector" >
                <Link to={`sector/${id}`}>
                    <div className="sector-header" style={{ backgroundColor: color }}>
                        <p className="sector-category">{description}</p>
                        <h5 className="sector-title">{title}</h5>
                    </div>
                </Link>
                <div className="sector-content">
                    <p className="sector-description">'Information'</p>
                    <Droppable droppableId={id}>
                        {(provided, snapshot) => (
                            <div className="sector-droppable"
                                {...provided.droppableProps}
                                ref={provided.innerRef}
                                style = {{
                                    backgroundColor: snapshot.isDraggingOver ? color : 'white',
                                }}
                            >
                                {props.patients.map((patient, index) => <Patient patient={patient} key={patient.id} index={index} />)}
                                {provided.placeholder}
                            </div>
                        )}
                    </Droppable>
                    <div className="sector-add-patient" onClick={() => props.addPatient(id)}>
                        <img className="icon-add" width="14" alt="icon-patient" src={addIcon} />
                        <p>Agregar un paciente</p>
                    </div>
                </div>
            </div>
        </div>
    )
}