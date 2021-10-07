using Microsoft.AspNetCore.Mvc;
using Polidom.Core.Domains;
using Polidom.Core.Interfaces;
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

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
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
    }
}
