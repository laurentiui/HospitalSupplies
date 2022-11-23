using AutoMapper;
using Data.Domain.Dto;
using Data.Domain.Dto.User;
using Data.Domain.Dto.Weather;
using Data.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Services.Implementations;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class InstrumentsController : ControllerBase {

        private readonly ILogger<InstrumentsController> _logger;
        private readonly IInstrumentsService _instrumentsService;
        private readonly IMapper _mapper;


        public InstrumentsController(ILogger<InstrumentsController> logger, IMapper mapper, IInstrumentsService instrumentsService) {
            _logger = logger;
            _mapper = mapper;
            _instrumentsService = instrumentsService;
        }

        /// <summary>
        /// Get specified instrument
        /// </summary>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     here we add extra documention we want to see in swagger
        ///
        /// </remarks>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<InstrumentDto>> Get(int id) {
            var instrument = await _instrumentsService.GetById(id);

            if (instrument == null) {
                return NotFound();
            }
            var returnEntity = _mapper.Map<InstrumentDto>(instrument);

            return Ok(instrument);
        }

        /// <summary>
        /// Lists all instruments
        /// </summary>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     here we add extra documention we want to see in swagger
        ///
        /// </remarks>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet("list")]
        public async Task<ActionResult<IList<InstrumentDto>>> ListAll() {
            var instruments = await _instrumentsService.ListAll();

            var listDtos = instruments.Select(i => _mapper.Map<InstrumentDto>(i));

            return Ok(listDtos);
        }

        /// <summary>
        /// Adds instrument
        /// </summary>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     here we add extra documention we want to see in swagger
        ///
        /// </remarks>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult<InstrumentDto>> Add([FromBody] InstrumentAddDto instrumentAddDto) {
            var instrumentToAdd = _mapper.Map<Instrument>(instrumentAddDto);
            var createdInstrument = await _instrumentsService.Insert(instrumentToAdd);
            var returnEntity = _mapper.Map<InstrumentDto>(createdInstrument);

            return Ok(returnEntity);
        }

        /// <summary>
        /// Updates instrument
        /// </summary>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     here we add extra documention we want to see in swagger
        ///
        /// </remarks>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult<InstrumentDto>> Update([FromBody] InstrumentDto instrumentDto) {
            var instrumentToUpdate = _mapper.Map<Instrument>(instrumentDto);
            var updatedInstrument = await _instrumentsService.Update(instrumentToUpdate);
            var returnEntity = _mapper.Map<InstrumentDto>(updatedInstrument);

            return Ok(returnEntity);
        }

        /// <summary>
        /// Deletes instrument
        /// </summary>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     here we add extra documention we want to see in swagger
        ///
        /// </remarks>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id) {
            await _instrumentsService.Delete(id);

            return Ok(true);
        }
    }
}
