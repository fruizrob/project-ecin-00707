import React, { Component } from 'react';
import { DragDropContext } from 'react-beautiful-dnd'
import { Subscribe } from 'unstated'
import Sector from './Sector';

import SectorContainer from '../../containers/SectorContainer';
import PatientContainer from '../../containers/PatientContainer';

import './Home.css';


export default class Home extends Component {

    onDragEnd = (result, sectors, sectorsStore) => {
        const { destination, source, draggableId } = result;

        if(!destination) {
            return;
        }

        if(destination.droppableId === source.droppableId && destination.index === source.index) {
            return;
        }

		let start;
		let indexStart;
		sectors.forEach((sector, index) => {
			if(source.droppableId === sector.id){
				start = sector;
				indexStart = index;
			}
		})
		
		let finish;
		let indexFinish;
		sectors.forEach((sector, index) => {
			if(destination.droppableId === sector.id) {
				finish = sector;
				indexFinish = index;
			}
				
		})


        if(start === finish) {
            const newPatientIds = Array.from(start.patientIds);
            newPatientIds.splice(source.index, 1)
            newPatientIds.splice(destination.index, 0, draggableId);
    
            const newSector = {
                ...start,
                patientIds: newPatientIds
            };
	
			const newSectors = sectors;
			newSectors[indexFinish] = newSector;
            
            sectorsStore.newState(newSectors);
            return;
        }

		const startPatientIds = Array.from(start.patientIds);
        startPatientIds.splice(source.index, 1)
        const newStart = {
            ...start,
            patientIds: startPatientIds
		}

        const finishPatientIds = Array.from(finish.patientIds);
        finishPatientIds.splice(destination.index, 0, draggableId);
        const newFinish = {
            ...finish,
            patientIds: finishPatientIds
		}
		
		const newSectors = sectors;
		newSectors[indexStart] = newStart;
		newSectors[indexFinish] = newFinish;

        sectorsStore.newState(newSectors);
        return;
    };

    render() {
        return (
            <Subscribe to={[ SectorContainer, PatientContainer ]}>
                {(sectorsStore, patientsStore) => {

                    const { sectors } = sectorsStore.state;
                    const { patients } = patientsStore.state;

                    return (
                        <section className="homepage">
                            <DragDropContext
                                onDragEnd={(result) => this.onDragEnd(result, sectors, sectorsStore)}
                            >
                                <div className="homepage-container">
                                    {
                                        sectors.map((sector) => {
                                            const sectorPatients = sector.patientIds.map(id => {
                                                let obj;
                                                patients.forEach(patient => {
                                                    if(patient.id === id)
                                                        obj = patient;
                                                })
                                                return obj;
                                            })

                                            return (
                                                <Sector 
                                                    patientsStore={patientsStore} 
                                                    sector={sector} 
                                                    addPatient={this.props.addPatient} 
                                                    patients={sectorPatients} 
                                                    key={sector.id} 
                                                />
                                            )
                                        })
                                    }
                                </div>
                            </DragDropContext>
                        </section>
                    )
                }}
            </Subscribe>
        )
    }
}

