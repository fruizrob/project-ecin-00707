import { Container } from 'unstated';
import SectorContainer from './SectorContainer';
import data from '../data.json';

export default class PatientContainer extends Container {

    constructor(props = {}) {
        super();
        this.sectors = new SectorContainer()
		this.state = {
			patients: data.patients
		};
    }

    addPatient = (id) => {
        const { sectors } = this.sectors.state;
        let sector; 
        let indexSector;
		sectors.forEach((item, index) => {
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

		const newSectors = sectors;
		newSectors[indexSector] = sector;

        this.sectors.newState(newSectors);

        this.setState({
            patients: newPatients
        })
	}
	
	getPatientsBySector = (sectorId) => {
		const { sectors } = this.sectors.state;
		const patientIds = sectors[sectorId-1].patientIds;
		return this.state.patients.filter(patient => patientIds.includes(patient.id));
	}

}