using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects.Dto
{
    public class ImagesDto
    {
        public IFormFileCollection Files { get; set; }
        public string UpLoadPath { get; set; } = string.Empty;
    }
}
