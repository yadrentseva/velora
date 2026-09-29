using AutoMapper;
using velora.Models;

namespace velora
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventResponseDto>();
            CreateMap<EventResponseDto, Event>();
            CreateMap<EventRequestDTO, Event>();
        }
    }
}
