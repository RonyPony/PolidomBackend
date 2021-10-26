using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Polidom.Core.Domains
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public int ReportId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
