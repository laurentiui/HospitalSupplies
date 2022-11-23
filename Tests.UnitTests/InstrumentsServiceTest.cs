using Data.Domain.Entity;
using NUnit.Framework;
using Services.Implementations;
using Services.Interfaces;
using System.Threading.Tasks;
using Tests.UnitTests.Mocks;

namespace Tests.UnitTests {
    public class InstrumentsServiceTest {

        private IInstrumentsService _instrumentsService;
        private const int LIST_COUNT = 2;

        [SetUp]
        public async Task Setup() {

            var instrumentsRepository = new InstrumentsRepositoryMock();
            _instrumentsService = new InstrumentsService(instrumentsRepository);

            await instrumentsRepository.Insert(new Instrument() {
                Id = 1,
                Name = "seed name 1",
                Color = "seed color 1"
            });
            await instrumentsRepository.Insert(new Instrument() {
                Id = 2,
                Name = "seed name 2",
                Color = "seed color 2"
            });

        }
        [TearDown]
        public async Task TearDown() {
            //no need for something here so far
        }

        [Test]
        public async Task Insert_ReturnCorrectData() {
            string name = "name1";
            string color = "color1";

            var toInsert = new Instrument() {
                Name = name,
                Color = color
            };

            var inserted = await _instrumentsService.Insert(toInsert);

            Assert.NotNull(inserted);
            Assert.AreEqual(name, inserted.Name);
            Assert.AreEqual(color, inserted.Color);
        }

        [Test]
        public async Task Insert_AddsDataToCollection() {
            string name = "name1";
            string color = "color1";

            var toInsert = new Instrument() {
                Name = name,
                Color = color
            };

            await _instrumentsService.Insert(toInsert);

            var instruments = await _instrumentsService.ListAll();

            Assert.NotNull(instruments);
            Assert.AreEqual(LIST_COUNT + 1, instruments.Count);
        }

        [Test]
        public async Task Update_ReturnCorrectData() {
            string name = "name1";
            string color = "color1";

            var toUpdate = new Instrument() {
                Id = 1,
                Name = name,
                Color = color
            };

            var updated = await _instrumentsService.Update(toUpdate);

            Assert.NotNull(updated);
            Assert.AreEqual(name, updated.Name);
            Assert.AreEqual(color, updated.Color);
        }

        [Test]
        public async Task Update_IdDoesNotExists_ReturnsNull() {
            string name = "name1";
            string color = "color1";

            var toUpdate = new Instrument() {
                Id = 1_000,
                Name = name,
                Color = color
            };

            var updated = await _instrumentsService.Update(toUpdate);

            Assert.Null(updated);
        }

        [Test]
        public async Task Delete_RemovesDataFromCollection() {
            await _instrumentsService.Delete(1);

            var instruments = await _instrumentsService.ListAll();

            Assert.NotNull(instruments);
            Assert.AreEqual(LIST_COUNT - 1, instruments.Count);
        }

        [Test]
        public async Task Delete_IdDoesNotExists_DataIsUnchanged() {
            await _instrumentsService.Delete(1_000);

            var instruments = await _instrumentsService.ListAll();

            Assert.NotNull(instruments);
            Assert.AreEqual(LIST_COUNT, instruments.Count);
        }

        [Test]
        public async Task List_ReturnsInitialData() {
            var instruments = await _instrumentsService.ListAll();

            Assert.NotNull(instruments);
            Assert.AreEqual(LIST_COUNT, instruments.Count);
        }
    }
}
