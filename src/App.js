import React, { Component } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import Header from './components/Header';
import Home from './components/homepage/Home';
import SectorDetail from './components/sector/SectorDetail';
import PatientDetail from './components/patient/PatientDetail';

import data from './data.json';
class App extends Component {

	state = data;

	addPatient = (id) => {
		let sector; let indexSector;
		this.state.sectors.forEach((item, index) => {
			if(id === item.id) {
				sector = item;
				indexSector = index; 
			}
		})

		let newPatients = this.state.patients;
		let idNewPatient = ++newPatients.length;

		newPatients.push({
			id: idNewPatient,
			name: "Felipe Ruiz",
			time: "03:45",
			years: "22"
		});

		sector.patientIds.push(idNewPatient);

		const newSectors = this.state.sectors;
		newSectors[indexSector] = sector;

		this.setState({
			sectors: newSectors,
			patinets: newPatients,
		})

	}

	onDragEnd = (result) => {
        const { destination, source, draggableId } = result;

        if(!destination) {
            return;
        }

        if(destination.droppableId === source.droppableId && destination.index === source.index) {
            return;
        }

		let start;
		let indexStart;
		this.state.sectors.forEach((sector, index) => {
			if(source.droppableId === sector.id){
				start = sector;
				indexStart = index;
			}
		})
		
		let finish;
		let indexFinish;
		this.state.sectors.forEach((sector, index) => {
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
	
			const newSectors = this.state.sectors;
			newSectors[indexFinish] = newSector;

            const newState = {
                ...this.state,
                sectors: newSectors
            };
    
            this.setState(newState);
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
		
		const newSectors = this.state.sectors;
		newSectors[indexStart] = newStart;
		newSectors[indexFinish] = newFinish;

        const newState = {
            ...this.state,
			sectors: newSectors
        };

        this.setState(newState);
    };

	render() {
		return (
			<BrowserRouter>
				<Header />
				<Switch>
					<Route path="/" exact render={() => <Home data={this.state} onDragEnd={this.onDragEnd} addPatient={this.addPatient} />} />
					<Route path="/sector/:id" exact render={(props) => <SectorDetail {...props} />} />
					<Route path="/patient/:id" exact render={(props) => <PatientDetail {...props} />} />
					<Route path="/" render={() => <div>404</div>} />
				</Switch>
			</BrowserRouter>
		)
	}
}

export default App;
