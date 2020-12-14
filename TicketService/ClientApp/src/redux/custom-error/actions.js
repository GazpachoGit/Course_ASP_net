import {ERROR_OPEN, ERROR_CLOSE} from './index'


export const openErrorModal =(err) => ({
    type: ERROR_OPEN,
    payload: err
})
export const closeErrorModal = () => ({
    type: ERROR_CLOSE,
})