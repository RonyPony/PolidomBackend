using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Polidom.Core.Domains;
using Polidom.Core.Interfaces;
using PolidomApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PolidomApplication.Controllers
{
    [Route("api/photos")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _photoService;
        private readonly IReportService _reportService;

        public PhotoController(IPhotoService photoService , IReportService reportService)
        {
            _photoService = photoService;
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPhotos()
        {
            try
            {
                IEnumerable<Photo> photos = await _photoService.GetPhotos();

                return Ok(photos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            try
            {

                Photo photo = await _photoService.GetPhotoById(id);

                return Ok(photo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("report")]
        public async Task<IActionResult> GetPhotosByReport([FromQuery]int reportId)
        {
            try
            {
                IEnumerable<Photo> photos = await _photoService.GetPhotosByReportId(reportId);
                return Ok(photos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("new")]
        public async Task<IActionResult> PostPhoto([FromForm] PhotoToRegister photoToRegister)
        {
            try
            {
                string[] extensions = new string[] { ".jpg", ".png", ".svg" };
                var fileName = Path.GetFileName(photoToRegister.Image.FileName);
                var fileExtension = Path.GetExtension(fileName);

                if (!extensions.Contains(fileExtension))
                    throw new ArgumentException("InvalidFile");

                var foundReport = await _reportService.GetReportById(photoToRegister.ReportId);

                if (foundReport is null)
                    throw new ArgumentException("ReportNotFound");

                var newPhoto = new Photo
                {
                    Name = fileName.Split('.')[0],
                    ReportId = photoToRegister.ReportId,
                    CreatedAt = DateTime.Now
                };

                using(var target = new MemoryStream())
                {
                    photoToRegister.Image.CopyTo(target);
                    newPhoto.Image = target.ToArray();
                }

                await _photoService.CreatePhoto(newPhoto);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            try
            {
                Photo photo = await _photoService.GetPhotoById(id);

                await _photoService.DeletePhoto(photo);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    
    }
}
