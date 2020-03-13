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
                    <p>Iniciar jornada</p>
                    <p>Generar reporte</p>
                    <p onClick={categorizationStore.toggleCategorizationSection}>Categorización</p>
                </div>
            </div>
        </header>
    )
}