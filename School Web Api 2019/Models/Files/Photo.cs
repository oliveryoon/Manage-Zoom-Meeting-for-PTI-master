using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebAPI.Models
{
    public class File
    {
        [Key]
        public int Id { get; set; }
        public string FileType { get; set; }
        public string Classification { get; set; }
        public byte[] Content { get; set; }
    }
}
