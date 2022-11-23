using Data.Domain.Dto;
using Data.Domain.Entity;
using Data.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository.Implementations {
    public class InstrumentsRepository : BaseRepository<Instrument>, IInstrumentsRepository
    {
        private readonly AppDbContext _appDbContext;

        public InstrumentsRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IList<Instrument>> Search(InstrumentFilterDto filterDto) {
            var query = _appDbContext.Set<Instrument>().AsQueryable();
            if (!string.IsNullOrEmpty(filterDto.FreeText)) {
                query = query.Where(i =>
                    i.Name.Contains(filterDto.FreeText)
                    || i.Color.Contains(filterDto.FreeText));
            }
            if (!string.IsNullOrEmpty(filterDto.NameContains)) {
                query = query.Where(i =>
                    i.Name.ToLower().Contains(filterDto.NameContains));
            }
            if (!string.IsNullOrEmpty(filterDto.ColorContains)) {
                query = query.Where(i =>
                    i.Color.ToLower().Contains(filterDto.ColorContains));
            }

            var list = query.OrderBy(i => i.Id).ToList();   

            return list;
        }
    }
}
