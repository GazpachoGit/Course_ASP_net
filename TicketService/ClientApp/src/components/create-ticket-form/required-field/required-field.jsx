import react, { Component } from 'react';
import ReactDOM from 'react-dom';

import '../create-ticket-form.css'

const RequiredField = ({ input, label, type, meta: { touched, error, warning } }) => (
    <div>
        <label>{label}</label>
        <div>
            <input className="form-control" {...input} placeholder={label} type={type} />
            <div className="validate-text">
                {touched && ((error && <span>{error}</span>) || (warning && <span>{warning}</span>))}
            </div>

        </div>
    </div>
)
export default RequiredField