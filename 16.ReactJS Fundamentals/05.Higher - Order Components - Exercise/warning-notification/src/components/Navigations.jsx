import React, { Component } from 'react';
import { Route, Switch, Link } from 'react-router-dom';

import Home from './Home'
import RegisterForm from './RegisterForm'

function registerFormValidator(data) {
    let error = false

    if (!data.hasOwnProperty('email')
        || !data.hasOwnProperty('username')
        || !data.hasOwnProperty('password')
        || !data.hasOwnProperty('confirmedPassword')) {
        error = true
    } else if (data.password.length < 3) {
        error = true
    } else if (data.password !== data.confirmedPassword) {
        error = true
    }

    return {
        error: error
    }
}

export default class Navigation extends Component {
    render() {
        return (
            <div>
                <nav>
                    <header>
                        <span className="title">Navigation</span>
                    </header>
                    <ul>
                        <li>
                            <Link to="/">Home</Link>
                        </li>
                        <li>
                            <Link to="/register">Register</Link>
                        </li>
                    </ul>
                </nav>
                <main>
                    <Switch>
                        <Route exact path="/" component={Home} />
                        <Route exact path="/register" render={(props) =>
                            <RegisterForm
                                validateFunc={registerFormValidator}
                                {...props}
                            />}
                        />
                    </Switch>
                </main>
            </div>
        )
    }
}