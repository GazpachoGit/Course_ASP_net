import axios from "axios";
import qs from "qs";

const instance = axios.create({
    baseURL: "/api/v1/",
    headers: {
        userName: 'admin'
    },
    paramsSerializer: function (params) {
        return qs.stringify(params, { arrayFormat: "repeat" });
    },
});

export const getListings = async () => {
    const resp = await instance.get('Listing', { params: {} });
    return resp;
}
export const getTickets = async (id) => {
    const resp = await instance.get('Ticket', { params: { ListingId: id } })
    return resp;
}
export const removeTicket = async (id) => {
    const resp = await instance.delete('Ticket', { params: { id: id } })
    return resp;
}
export const getEvents = async (par) => {
    const resp = await instance.get('Event', { params: { ...par } });
    return resp;
}
export const getVenues = async (par) => {
    const resp = await instance.get('Venue', { params: { ...par } });
    return resp;
}
export const getCities = async () => {
    const resp = await instance.get('City');
    return resp;
}
export const createTicket = async (ticket) => {
    const resp = await instance.post('Ticket', ticket);
    return resp;
}