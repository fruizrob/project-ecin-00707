import React from 'react';
import { Link } from 'react-router-dom';

import './Header.css';

export default function Header() {
    return (
        <header>
            <div className="container">
                <Link className="title" to="/">Unidad de Emergencia</Link>
                <div className="menu">
                    <p>'Add patient'</p>
                    <p>'Add stretcher'</p>
                    <p>etc</p>
                </div>
            </div>
        </header>
    )
}