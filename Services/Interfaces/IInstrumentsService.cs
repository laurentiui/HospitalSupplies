using Data.Domain.Dto;
using Data.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface IInstrumentsService {
        Task<Instrument> Insert (Instrument instrument);
        Task<Instrument> Update (Instrument instrument);
        Task<IList<Instrument>> ListAll ();
        Task<Instrument> GetById(int entityId);
        Task Delete (int id);
        Task<IList<Instrument>> Search(InstrumentFilterDto filterDto);
    }
}
