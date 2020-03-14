import React from 'react';
import { Link } from 'react-router-dom';

import './Header.css';

export default function Header(props) {
    const {categorizationStore} = props;

    return (
        <header>
            <div className="container">
                <Link className="title" to="/">Unidad de Emergencia</Link>
                <div className="menu">
                    <div className="menu-option">
                        <p>Enfermer@, Moises Moraga</p>
                    </div>
                    <div className="menu-option">
                        <p>Generar reporte</p>
                    </div>
                    <div onClick={categorizationStore.toggleCategorizationSection} className="menu-option">
                        <p>Categorización</p>
                        {/* this will be the number of waiting patients */}
                        <p className="categorization-notification">4</p> 
                    </div>
                </div>
            </div>
        </header>
    )
}