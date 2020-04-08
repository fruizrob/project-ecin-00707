import React from 'react';
import './Login.css'

const Login = (props) => {
    return (
        <div className="login-layout">
            <section className="login-img-container">
            </section>
            <section className="login-form-container">
                <div className="form-group">
                    <label for="input-email">Email</label>
                    <input type="email" class="form-control" id="input-email" aria-describedby="emailHelp" />
                    <small id="emailHelp" class="form-text text-muted">Nunca compartiremos su correo electrónico con nadie más.</small>
                </div>
                <div class="form-group">
                    <label for="input-password">Contraseña</label>
                    <input type="password" class="form-control" id="input-password" />
                </div>
                <button type="submit" class="btn btn-primary" onClick={props.handleLogin}>Iniciar sesión</button>
            </section>
        </div>
    )
}

export default Login;