import React, { Component } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import { Provider, Subscribe } from 'unstated'

import Login from './components/login/Login';
import Header from './components/Header';
import Home from './components/homepage/Home';
import SectorDetail from './components/sector/SectorDetail';
import PatientDetail from './components/patient/PatientDetail';

import SectorContainer from './containers/SectorContainer';
import PatientContainer from './containers/PatientContainer';
import CategorizationContainer from './containers/CategorizationContainer';

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

	state = {
		user: false
	}

	handleLogin = () => {
		this.setState({
			user: !this.state.user
		})
	}

	render() {
		return (
			<BrowserRouter>
				<Layout>
					{
						this.state.user ?
						<Provider>	
							<Subscribe to={[ SectorContainer, PatientContainer, CategorizationContainer]}>
								{(sectorStore, patientStore, categorizationStore) => (
									<>
										<Header categorizationStore={categorizationStore} />
										<Switch>
											<Route path="/" exact render={(props) => <Home {...props} sectorStore={sectorStore} patientStore={patientStore} categorizationStore={categorizationStore}  />} />
											<Route path="/sector/:id" exact render={(props) => <SectorDetail  {...props} sectorStore={sectorStore} patientStore={patientStore} />} />
											<Route path="/patient/:id" exact render={(props) => <PatientDetail {...props} sectorStore={sectorStore} patientStore={patientStore} />} />
											<Route path="/" render={() => <div>404</div>} />
										</Switch>
									</>
								)}
							</Subscribe>
						</Provider>
						:						
						<Login handleLogin={this.handleLogin} />
					}
				</Layout>
			</BrowserRouter>
		)
	}
}

export default App;
