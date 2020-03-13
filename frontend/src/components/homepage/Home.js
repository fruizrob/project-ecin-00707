import React, { Component } from 'react';
import { DragDropContext } from 'react-beautiful-dnd';
import Sector from './Sector';
import Categorization from '../categorization/Categorization';
import './Home.css';

export default class Home extends Component {

    onDragEnd = (result, sectors, sectorStore) => {
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
            
            sectorStore.newState(newSectors);
            return;
        }

		const startPatientIds = Array.from(start.patientIds);
        startPatientIds.splice(source.index, 1)
        const newStart = {
            ...start,
            patientIds: startPatientIds
		};

        const finishPatientIds = Array.from(finish.patientIds);
        finishPatientIds.splice(destination.index, 0, draggableId);
        const newFinish = {
            ...finish,
            patientIds: finishPatientIds
		};
		
		const newSectors = sectors;
		newSectors[indexStart] = newStart;
		newSectors[indexFinish] = newFinish;

        sectorStore.newState(newSectors);
        return;
    };

    render() {

        const { sectorStore, patientStore, categorizationStore } = this.props;
        const { sectors } = sectorStore.state;
        const { patients } = patientStore.state;
        const categorizationData = sectors.filter(function(sector) { return sector.id === 6 });
        const patientsOnCategorization = categorizationData[0].patientIds.map(id => {
            let obj;
            patients.forEach(patient => {
                if(patient.id === id)
                    obj = patient
            })
            return obj;
        })

        let valid_sectors = sectors.filter(function(sector) { return sector.id !== 6 });

        return (
            <section className="homepage">
                <DragDropContext
                    onDragEnd={(result) => this.onDragEnd(result, sectors, sectorStore)}
                >
                    {
                        categorizationStore.state.activate && 
                            <Categorization 
                                data={categorizationData[0]} 
                                patients={patientsOnCategorization}
                            />
                    }
                    
                    <div className="homepage-container">
                        {   
                            valid_sectors.map((sector) => {
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
                                        patientStore={patientStore} 
                                        sector={sector} 
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
    }
}