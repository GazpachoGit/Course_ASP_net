import React from 'react';
import {Field, reduxForm} from 'redux-form';

import './create-ticket-form.css';

const CreateTicketForm = (props) => {
    const {handleSubmit} = props;
    return (<form onSubmit={handleSubmit}>
            <div className="form-group">
                <lable htmlFor={"name"}>Name</lable>
                <Field className="form-control" name= {"name"} component={"input"} type={"text"}/>
            </div>
            <div className="form-group">
                <lable htmlFor={"price"}>Price</lable>
                <Field className="form-control" name= {"price"} component={"input"} type={"text"}/>
            </div>
            <div>
                <button type={"submit"} className="btn btn-dark">submit</button>
            </div>             
    </form>)
}

export default reduxForm({form: "contact"})(CreateTicketForm);