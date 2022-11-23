using Data.Domain.Dto;
using Data.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository.Interfaces {
    public interface IInstrumentsRepository : IBaseRepository<Instrument> {
        Task<IList<Instrument>> Search(InstrumentFilterDto filterDto);
    }
}
