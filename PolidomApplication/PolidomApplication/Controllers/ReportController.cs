using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Polidom.Core.Contracts;
using Polidom.Core.Domains;
using Polidom.Core.Interfaces;
using Polidom.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PolidomApplication.Controllers
{
    [Route("api/reports")]
    [ApiController]
    public class ReportController : ControllerBase
    {

        #region Fields

        private readonly IReportService _reportService;
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        /// <summary>
        /// <paramref name="reportService"/> <see cref="IReportService"/> class.
        /// <paramref name="reportRepository"/> <see cref="IReportRepository"/> class.
        /// <paramref name="mapper"/> <see cref="IMapper"/> class.
        /// </summary>
        public ReportController(IReportService reportService , IReportRepository reportRepository , IMapper mapper)
        {
            _reportService = reportService;
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetReports()
        {
            try
            {
                IEnumerable<Report> reports = await _reportService.GetAllReports();
                return Ok(reports);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReportById(int id)
        {
            try
            {
                Report report = await _reportService.GetReportById(id);
                return Ok(report);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("panic")]
        public async Task<IActionResult> GetPanicReport()
        {
            try
            {
                IEnumerable<Report >reports = await _reportService.GetPanicReport();
                return Ok(reports);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("account")]
        public async Task<IActionResult> GetReportByAccount([FromQuery] string accountId)
        {
            try
            {
                var report = await _reportService.GetReportAssignToAccount(accountId);

                return Ok(report);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("all/account")]
        public async Task<IActionResult> GetReportsByAccount([FromQuery] string accountId)
        {
            try
            {
                IEnumerable<Report> reports = await _reportService.GetReportsByAccountId(accountId);
                return Ok(reports);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetReportCount()
        {
            try
            {
                int reportCount = await _reportService.ReportCount();
                return Ok(reportCount);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateReport([FromBody] ReportToRegister reportToRegister)
        {
            try
            {
                Report report = _mapper.Map<Report>(reportToRegister);
                int reportId = await _reportRepository.CreateReport(report);

                return Ok(reportId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReport([FromBody]ReportToUpdate reportToUpdate)
        {
            try
            {
                Report report = _mapper.Map<Report>(reportToUpdate);
                await _reportRepository.UpdateReport(report);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignReport([FromQuery] int reportId , [FromQuery] string accountId)
        {
            try
            {
                await _reportService.AssignReportToAuthority(reportId, accountId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    
        [HttpPatch("mark-as-complete")]
        public async Task<IActionResult> MarkAsComplete([FromQuery] int reportId , [FromQuery] string accountId)
        {
            try
            {
                await _reportService.MarkReportAsComplete(reportId, accountId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    
        [HttpDelete("remove-report")]
        public async Task<IActionResult> removeAssignReport([FromQuery] int reportId, [FromQuery] string accountId)
        {
            try
            {
                await _reportService.RemoveReportAssignToAuthority(reportId, accountId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
