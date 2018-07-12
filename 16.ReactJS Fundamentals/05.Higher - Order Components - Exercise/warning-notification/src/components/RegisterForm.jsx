import React, { Component } from 'react'

export default class RegisterForm extends Component {
    constructor(props) {
        super(props)

        this.state = {
            error: null,
            spanId: 'span',
            errorSymbol: ''
        }

        this.handleChange = this.handleChange.bind(this)
        this.handleSubmit = this.handleSubmit.bind(this)
    }

    handleChange(ev) {
        this.setState({
            [ev.target.name]: ev.target.value
        })
    }

    handleSubmit(e) {
        e.preventDefault()

        let isValidate = this.props.validateFunc(this.state)

        if (isValidate.error) {
            this.setState({
                error: 'alert',
                spanId: '',
                errorSymbol: 'alert-symbol'
            })
            alert('Please fill all the inputs correctly!')
        } else {
            this.setState({
                error: null,
                spanId: 'span',
                errorSymbol: ''
            })
            this.props.history.push('/')
            alert('Successful form filled!')
        }
    }

    render() {
        return (
            <div className={this.state.error}>
                <span className={this.state.errorSymbol} id={this.state.spanId}>&#9888;</span>
                <div>
                    <header>
                        <span className="title">Register</span>
                    </header>
                    <form onSubmit={this.handleSubmit}>
                        Username:
                        <input type="text" name="username" onChange={this.handleChange} />
                        <br /> Email:
                        <input type="text" name="email" onChange={this.handleChange} />
                        <br /> Password:
                        <input type="password" name="password" onChange={this.handleChange} />
                        <br /> Repeat Password:
                        <input type="password" name="confirmedPassword" onChange={this.handleChange} />
                        <br />
                        <input type="submit" value="Register" />
                    </form>
                </div>
            </div>
        )
    }
}