using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Polidom.Core.Contracts;
using Polidom.Core.Domains;
using Polidom.Core.Interfaces;
using Polidom.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolidomApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        #region Fields

        private readonly ILocationInfoRepository _locationInfoRepository;
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        /// <summary>
        /// <paramref name="locationInfoRepository"/> <see cref="ILocationInfoRepository"/> class.
        /// <paramref name="locationService"/> <see cref="ILocationService"/> class.
        /// <paramref name="mapper"/> <see cref="IMapper"/> class.
        /// </summary>
        public LocationController(ILocationInfoRepository locationInfoRepository , ILocationService locationService , IMapper mapper)
        {
            _locationInfoRepository = locationInfoRepository;
            _locationService = locationService;
            _mapper = mapper;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            try
            {
                IEnumerable<LocationInfo> locations = await _locationService.GetAllLocationInfos();

                return Ok(locations);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            try
            {

                LocationInfo location = await _locationService.GetLocationById(id);

                return Ok(location);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> PostLocation([FromBody]LocationToRegister locationToRegister)
        {
            try
            {
                LocationInfo location = _mapper.Map<LocationInfo>(locationToRegister);

                await _locationInfoRepository.CreateLocation(location);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLocation([FromBody]LocationToUpdate locationToUpdate)
        {
            try
            {
                LocationInfo location = _mapper.Map<LocationInfo>(locationToUpdate);
                await _locationInfoRepository.UpdateLocation(location);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
