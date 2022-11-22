using AutoMapper;
using Data.Domain.Dto;
using Data.Domain.Dto.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
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
        [HttpGet("get/{id}")]
        public async Task<ActionResult<InstrumentDto>> Get(int id) {
            var instrument = new InstrumentDto() {
                Id = id
            };

            //_instrumentsService.get

            return Ok(instrument);
        }
    }
}
