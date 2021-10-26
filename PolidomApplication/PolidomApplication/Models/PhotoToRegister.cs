using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolidomApplication.Models
{
    public sealed class PhotoToRegister
    {
        public IFormFile Image { get; set; }
        public int ReportId { get; set; }
    }
}
