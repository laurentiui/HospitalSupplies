using Data.Domain.Dto;
using Data.Domain.Entity;
using Data.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests.UnitTests.Mocks {
    public class InstrumentsRepositoryMock : BaseRepositoryMock<Instrument>, IInstrumentsRepository {
        public async Task<IList<Instrument>> Search(InstrumentFilterDto filterDto) {
            return null;
        }
    }
}
