using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebAPI.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public string ImageType { get; set; }
        
        public byte[] Image { get; set; }
    }
}
