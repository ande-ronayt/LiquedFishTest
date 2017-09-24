using System;
using System.Collections.Generic;
using System.Net;
using WebTest.Domain.Entity;

namespace WebTest.Domain.Concrete
{
    internal class FishServiceLoadFromUrl : FishServiceBase
    {
        public string Url { get; set; }

        public FishServiceLoadFromUrl(string url)
        {
            this.Url = url;
        }

        public override string GetJson()
        {
            using (var wc = new WebClient())
            {
                wc.BaseAddress = Url;
                var json = wc.DownloadString(Url);
                return json;
            }
        }
    }
}