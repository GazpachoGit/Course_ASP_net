export const getDetails = () => ({ type: 'getDetails' });

export const deleteTicket = (listingId, ticketId) => ({type: 'deleteTicket',
                                             payload: {listingId, ticketId}})

export const rnd = () => {
  return {
    type: 'RND',
    payload: Math.floor(Math.random()*10)
  };
};

