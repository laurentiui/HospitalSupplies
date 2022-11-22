using Data.Domain.Entity;
using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Implementations
{
    public class InstrumentsRepository : BaseRepository<Instrument>, IInstrumentsRepository
    {
        private readonly AppDbContext _appDbContext;

        public InstrumentsRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
