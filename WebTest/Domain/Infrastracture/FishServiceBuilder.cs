using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTest.Domain.Concrete;
using WebTest.Domain.Interface;

namespace WebTest.Domain.Infrastracture
{
    public class FishServiceBuilder
    {
        public FishServiceType Type { get; set; }

        public string Url { get; set; }

        public HttpPostedFileBase File { get; set; }

        public IFishService Create()
        {
            switch (Type)
            {
                case FishServiceType.FROM_URL:
                    return new FishServiceLoadFromUrl(Url);
                case FishServiceType.FROM_LOCAL_FILE:
                    return new FishServiceFromLocalFile();
                case FishServiceType.UPLOAD_FILE:
                    return new FishServiceUploadFile(File);
            }

            throw new NotImplementedException();
        }
    }
}