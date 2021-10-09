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
        private readonly IReportService _reportService;
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;

        public ReportController(IReportService reportService , IReportRepository reportRepository , IMapper mapper)
        {
            _reportService = reportService;
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> PostReport()
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
                report.CreationDate = DateTime.Now;
                await _reportRepository.CreateReport(report);

                return StatusCode(201);
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
    }
}
