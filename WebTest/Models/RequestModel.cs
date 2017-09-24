using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTest.Domain.Infrastracture;

namespace WebTest.Models
{
    public class RequestModel
    {
        public FishServiceType ServiceType { get; set; }

        public HttpPostedFileBase File { get; set; }

        public string Url { get; set; }
    }
}