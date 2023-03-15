using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Infrastructure.Dtos
{
    public class FileDatumDto
    {        
        public int FileDataId { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public string Path { get; set; }
        public string Base64 { get; set; }
        public byte[] ByteArray { get; set; }
    }
}
