import { Container } from 'unstated';

export default class CategorizationContainer extends Container {
    constructor(props = {}) {
        super();
		this.state = {
            activate: false,
		};
    }

    toggleCategorizationSection = () => {
        /* this section will only appear on the homepage */

        this.setState({
            activate: !this.state.activate
        })
    }
}