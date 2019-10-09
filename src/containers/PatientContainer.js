import { Container } from 'unstated';
import SectorContainer from './SectorContainer';
import data from '../data.json';
export default class PatientContainer extends Container {

    constructor(props = {}) {
        super();
        this.sectors = new SectorContainer()
		this.state = {
			patients: data.patients,
			id: data.patients.length + 1
		};
    }

    addPatient = (sectorId, newPatient = undefined) => {
		const { sectors } = this.sectors.state;
        let sector; 
        let indexSector;
		sectors.forEach((item, index) => {
			if(Number(sectorId) === item.id) {
				sector = item;
				indexSector = index; 
			}
		})

		let newPatients = this.state.patients;

		if(newPatient) {
			newPatients.push({
				id: this.state.id,
				...newPatient
			})
		} else {
			newPatients.push({
				id: this.state.id,
				name: "Felipe Ruiz",
				time: "03:45",
				years: "22"
			});
		}

		sector.patientIds.push(this.state.id);

		const newSectors = sectors;
		newSectors[indexSector] = sector;

        this.sectors.newState(newSectors);

        this.setState({
			patients: newPatients,
			id: this.state.id + 1
        })
	}

	updatePatient = (newPatient, oldPatient) => {
		const patients = this.state.patients;
		const index = patients.indexOf(oldPatient);
		patients[index] = {
			...oldPatient,
			...newPatient
		};

		this.setState({
			patients
		});
	}
	
	deletePatient = (idSector, oldPatient) => {
		const { sectors } = this.sectors.state;
		sectors[idSector-1].patientIds.splice(sectors[idSector-1].patientIds.indexOf(oldPatient.id), 1)

		const patients = this.state.patients;
		const indexPatient = patients.indexOf(oldPatient);
		patients.splice(indexPatient, 1);

		this.sectors.newState(sectors)

		this.setState({
			patients,
		})
	}

	getPatientsBySector = (sectorId) => {
		const { sectors } = this.sectors.state;
		const patientIds = sectors[sectorId-1].patientIds;
		return this.state.patients.filter(patient => patientIds.includes(patient.id));
	}

}