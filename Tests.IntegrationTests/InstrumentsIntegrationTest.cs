using Data.Domain.Dto;
using Data.Domain.Dto.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.IntegrationTests {
    public class InstrumentsIntegrationTest : IClassFixture<CustomWebApplicationFactory<WebApi.Startup>> {
        private readonly CustomWebApplicationFactory<WebApi.Startup> _factory;

        public InstrumentsIntegrationTest(CustomWebApplicationFactory<WebApi.Startup> factory) {
            _factory = factory;
        }

        [Fact]
        public async Task ListAll_Works() {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var instruments = ListAll(client);

            // Assert
            Assert.NotNull(instruments);
        }

        [Fact]
        public async Task Test_CRUDWorkflow_IsGood() {

            string url = "/instruments";
            //=============== Register user
            // Arrange
            var client = _factory.CreateClient();
            var toInsertDto = new InstrumentAddDto() {
                Name = "insert name",
                Color = "insert color"
            };
            var toUpdateDto = new InstrumentDto() {
                Name = "update name",
                Color = "update color"
            };

            // Act
            var listInitial = await ListAll(client);

            //insert
            var responseInsert = await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(toInsertDto), Encoding.UTF8) {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            });
            var insertedInstrument = await GetFromResponse<InstrumentDto>(responseInsert);
            var listAfterInsert = await ListAll(client);

            //update
            toUpdateDto.Id = insertedInstrument.Id;
            var responseUpdate = await client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(toUpdateDto), Encoding.UTF8) {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            });
            var updatedInstrument = await GetFromResponse<InstrumentDto>(responseUpdate);
            var listAfterUpdate = await ListAll(client);

            //delete
            var responseDelete = await client.DeleteAsync($"{url}/{insertedInstrument.Id}");
            bool isDeleted = await GetFromResponse<bool>(responseDelete);
            var listAfterDelete = await ListAll(client);

            //// Assert
            responseInsert.EnsureSuccessStatusCode();
            responseUpdate.EnsureSuccessStatusCode();
            responseDelete.EnsureSuccessStatusCode();

            Assert.Equal(listInitial.Count + 1, listAfterInsert.Count);
            Assert.Equal(listAfterUpdate.Count, listAfterInsert.Count);
            Assert.Equal(listAfterDelete.Count, listInitial.Count);

            Assert.Equal(toInsertDto.Name, insertedInstrument.Name);
            Assert.Equal(toInsertDto.Color, insertedInstrument.Color);

            Assert.Equal(insertedInstrument.Id, updatedInstrument.Id);
            Assert.Equal(toUpdateDto.Name, updatedInstrument.Name);
            Assert.Equal(toUpdateDto.Color, updatedInstrument.Color);

            Assert.True(isDeleted);

        }

        private async Task<IList<InstrumentDto>> ListAll(HttpClient client) {

            string url = "/instruments/list";

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await GetFromResponse<IList<InstrumentDto>>(response);
        }

        private async Task<T> GetFromResponse<T>(HttpResponseMessage response) {
            var text = await response.Content.ReadAsStringAsync();
            var convertedResponse = JsonConvert.DeserializeObject<T>(text);

            return convertedResponse;
        }
    }
}
