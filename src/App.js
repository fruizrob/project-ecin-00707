import React, { Component } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import { Provider, Subscribe } from 'unstated'

import Header from './components/Header';
import Home from './components/homepage/Home';
import SectorDetail from './components/sector/SectorDetail';
import PatientDetail from './components/patient/PatientDetail';

import SectorContainer from './containers/SectorContainer';
import PatientContainer from './containers/PatientContainer';

function Layout(props) {
	return (
		<div style={{
			display: "flex",
			flexDirection: "column",
			height: "100%"
		}}>
			{props.children}
		</div>
	) 
}
class App extends Component {

	render() {
		return (
			<BrowserRouter>
				<Layout>
					<Header />
					<Provider>
						<Subscribe to={[ SectorContainer, PatientContainer ]}>
							{(sectorStore, patientStore) => (
								<Switch>
									<Route path="/" exact render={(props) => <Home {...props} sectorStore={sectorStore} patientStore={patientStore}  />} />
									<Route path="/sector/:id" exact render={(props) => <SectorDetail  {...props} sectorStore={sectorStore} patientStore={patientStore} />} />
									<Route path="/patient/:id" exact render={(props) => <PatientDetail {...props} sectorStore={sectorStore} patientStore={patientStore} />} />
									<Route path="/" render={() => <div>404</div>} />
								</Switch>
							)}
						</Subscribe>
					</Provider>
				</Layout>
			</BrowserRouter>
		)
	}
}

export default App;
