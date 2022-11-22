using Data.Domain.Entity;
using Data.Repository;
using Data.Repository.Implementations;
using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations {
    public class InstrumentsService : IInstrumentsService {

        private readonly IInstrumentsRepository _instrumentRepository;

        public InstrumentsService(IInstrumentsRepository instrumentRepository) {
            _instrumentRepository = instrumentRepository;
        }

        public async Task<IList<Instrument>> ListAll() {
            var list = await _instrumentRepository.ListAll();
            return list;
        }
        public async Task<Instrument> GetById(int entityId) {
            var entity = await _instrumentRepository.GetById(entityId);
            return entity;
        }

        public async Task<Instrument> Insert(Instrument newEntity) {
            var instrument = await _instrumentRepository.Insert(newEntity);
            return instrument;
        }
        public async Task<Instrument> Update(Instrument entity) {
            var instrument = await _instrumentRepository.Update(entity);

            return instrument;
        }
        public async Task Delete(int id) {
            var instrument = await GetById(id);
            await _instrumentRepository.Delete(instrument);
        }
    }
}
