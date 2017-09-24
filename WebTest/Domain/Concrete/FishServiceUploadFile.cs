using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebTest.Domain.Concrete
{
    public class FishServiceUploadFile : FishServiceBase
    {
        public HttpPostedFileBase File { get; set; }
        public FishServiceUploadFile(HttpPostedFileBase file)
        {
            this.File = file;
        }

        public override string GetJson()
        {
            BinaryReader b = new BinaryReader(File.InputStream);
            byte[] binData = b.ReadBytes(File.ContentLength);

            return System.Text.Encoding.UTF8.GetString(binData);
        }
    }
}