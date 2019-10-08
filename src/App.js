import React, { Component } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import { Provider } from 'unstated'
import Header from './components/Header';
import Home from './components/homepage/Home';
import SectorDetail from './components/sector/SectorDetail';
import PatientDetail from './components/patient/PatientDetail';

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
							<Switch>
								<Route path="/" exact render={() => <Home data={this.state} onDragEnd={this.onDragEnd} addPatient={this.addPatient} />} />
								<Route path="/sector/:id" exact render={(props) => <SectorDetail {...props} />} />
								<Route path="/patient/:id" exact render={(props) => <PatientDetail {...props} />} />
								<Route path="/" render={() => <div>404</div>} />
							</Switch>
						</Provider>
					</Layout>
				</BrowserRouter>
		)
	}
}

export default App;
