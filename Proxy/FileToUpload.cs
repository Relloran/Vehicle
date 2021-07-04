using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy
{
    public class FileToUpload
    {
        public string FileName { get; set; }
        public string VinCode { get; set; }
        public string FileType { get; set; }
        public long LastModifiedTime { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string FileAsBase64 { get; set; }
        public byte[] FileAsByteArray { get; set; }
    }
}
