using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects.Dto
{
    public class ResponseImagesDto
    {
        public string SavePath { get; set; } = string.Empty;
        public bool RequestResponse { get; set; }
    }
}
