import React, { Component } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import './App.css';
import Home from './components/Home';
import Header from './components/Header';

class App extends Component {

	render() {
		return (
			<BrowserRouter>
				<Header />
				<Switch>
					<Route path="/" exact render={() => <Home />} />
					<Route path="/" render={() => <div>404</div>} />
				</Switch>
			</BrowserRouter>
		)
	}
}

export default App;
