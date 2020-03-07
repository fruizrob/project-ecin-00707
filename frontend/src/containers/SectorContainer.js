import { Container } from 'unstated';
import data from '../data.json';

export default class SectorContainer extends Container {

	state = {
        sectors: data.sectors
    }

    newState = (newSectors) => {
        this.setState({
            sectors: newSectors
        })
    }
}
