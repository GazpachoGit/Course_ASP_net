﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketService.DAL.Models;

namespace TicketService.Core
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event> GetEventById(int Id);

        Task<int> CreateEvent(Event _event);
        Task EditEvent(int Id);
        Task DeleteEvent(int Id);

    }
}