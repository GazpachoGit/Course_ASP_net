using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketService.Controllers.api.Models;
using TicketService.DAL.Models;

namespace TicketService.Mapper
{
    public class MappingProfile : Profile

    {
        public MappingProfile()
        {            

            CreateMap<Event, EventResource>()
                .ForMember(x => x.Date, opt => opt.MapFrom(src => ((DateTime)src.Date).ToString("dd/MM/yyyy HH:mm")))
                .ForMember(r => r.CityName, opt => opt.MapFrom(src => src.Venue.City.Name));

            CreateMap<Venue, VenueResource>();
            
            CreateMap<Listing, ListingResource>();

            CreateMap<Ticket, TicketResource>()
                .ForMember(x => x.id, opt => opt.MapFrom(src => src.TicketId))
                .ForMember(x => x.CityName, opt => opt.MapFrom(src => src.Event.Venue.City.Name))
                .ForMember(x => x.Date, opt => opt.MapFrom(src => ((DateTime)src.Event.Date).ToString("dd/MM/yyyy HH:mm")))
                .ForMember(x => x.EventName, opt => opt.MapFrom(src => src.Event.Name))
                .ForMember(x => x.VenueName, opt => opt.MapFrom(src => src.Event.Venue.Name));
            CreateMap<TicketResourceCreate, Ticket>()
                .ForMember(res => res.Status, opt => opt.MapFrom(_ => TicketStatus.Selling));                
        }
    }
}
