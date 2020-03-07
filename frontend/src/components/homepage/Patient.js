import React from 'react';
import { Draggable } from 'react-beautiful-dnd';
import { Link } from 'react-router-dom';
import Timer from './Timer';
import icon from '../../patient.svg';
import "./Patient.css";

export default function Patient(props) {
    const { id, name, time, start } = props.patient;

    return (
        <Draggable draggableId={id} index={props.index}>
            {(provided, snapshot) => {
                const style = {
                    backgroundColor: snapshot.isDragging ? 'white' : '#fbf9fa',
                    ...provided.draggableProps.style,
                };

                return (
                    <Link to={{pathname:`/patient/${id}`}}>
                        <div className="patient"
                            ref={provided.innerRef}
                            {...provided.draggableProps}
                            style={style}
                            {...provided.dragHandleProps}
                        >                            
                            <img className="icon" alt="icon-patient" src={icon} />
                            <div className="patient-content">
                                <p>{name}</p>    
                                <Timer start={start} time={time} />
                            </div>
                        </div>
                    </Link>
                )
            }}
        </Draggable>
    )
}