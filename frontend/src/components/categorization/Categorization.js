import React from 'react';
import { Droppable } from 'react-beautiful-dnd';
import Patient  from '../homepage/Patient';
import './Categorization.css'

export default function Categorization(props) {
    const { data, patients } = props;

    return (
        <div className="categorization-contianer">
            <div className="categorization-header">
                <p className="categorization-description">{data.description}</p>
                <h5 className="categorization-title">{data.title}</h5>
            </div>

            <div className="categorization-content">
                    <Droppable droppableId={data.id}>
                        {(provided, snapshot) => (
                            <div className="sector-droppable"
                                {...provided.droppableProps}
                                ref={provided.innerRef}
                                style = {{
                                    backgroundColor: snapshot.isDraggingOver ? 'black' : 'white',
                                }}
                            >
                                {patients.map((patient, index) => 
                                    <Patient 
                                        color={data.color} 
                                        patient={patient} 
                                        key={patient.id} 
                                        index={index} 
                                    />
                                )}
                                {provided.placeholder}
                            </div>
                        )}
                    </Droppable>
                </div>
        </div>
    )
}