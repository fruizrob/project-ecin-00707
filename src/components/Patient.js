import React from 'react';
import { Draggable } from 'react-beautiful-dnd';
import icon from '../patient.svg';

import "./Patient.css";

export default function Patient(props) {
    const { id, name, time } = props.patient;

    return (
        <Draggable draggableId={id} index={props.index}>
            {(provided, snapshot) => {
                const style = {
                    backgroundColor: snapshot.isDragging ? '#EEEEEE' : 'white',
                    ...provided.draggableProps.style,
                };

                return (
                    <div className="patient"
                        ref={provided.innerRef}
                        {...provided.draggableProps}
                        isDragging={snapshot.isDragging}
                        style={style}
                        {...provided.dragHandleProps}
                    >
                        <img className="icon" alt="icon-patient" src={icon} />
                        <div className="patient-content">
                            <p>{name}</p>    
                            <p className="patient-time">{time}</p>
                        </div>
                    </div>
                )
            }}
        </Draggable>
    )
}