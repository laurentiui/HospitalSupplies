using AutoMapper;
using Data.Domain.Dto;
using Data.Domain.Entity;

namespace Data.Domain.Mapping {
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {            
            CreateMap<Instrument, InstrumentDto>();
            CreateMap<Instrument, InstrumentDto>().ReverseMap();

            CreateMap<Instrument, InstrumentAddDto>();
            CreateMap<Instrument, InstrumentAddDto>().ReverseMap();
        }
    }
}
