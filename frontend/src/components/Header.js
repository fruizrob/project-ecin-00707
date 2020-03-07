import React from 'react';
import { Link } from 'react-router-dom';

import './Header.css';

export default function Header() {
    return (
        <header>
            <div className="container">
                <Link className="title" to="/">Unidad de Emergencia</Link>
                <div className="menu">
                    <p>Iniciar jornada</p>
                    <p>Generar reporte</p>
                    <p>etc</p>
                </div>
            </div>
        </header>
    )
}