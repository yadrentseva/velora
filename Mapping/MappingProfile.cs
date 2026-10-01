using AutoMapper;
using velora.Models;

namespace velora.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventResponseDto>();
            CreateMap<EventRequestDto, Event>();
        }
    }
}
