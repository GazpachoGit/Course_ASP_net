import { APIgetListings } from '../API/store.jsx'

export const getDetails = () => ({ type: 'getDetails' });

export const deleteTicket = (id) => (
{
  type: 'deleteTicket',
  payload: id
})
export const loadListings = (data) => (
    {
    type: 'loadListings',
    payload: data
    })
export const loadTickets = (data) => (
    {
        type: 'loadTickets',
        payload: data
    })



