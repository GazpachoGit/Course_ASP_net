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
        //      .ForMember(er => er.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
