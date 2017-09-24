using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest.Domain.Concrete
{
    public class FishServiceFromLocalFile : FishServiceBase
    {
        /// <summary>
        /// Load JSON from the file
        /// </summary>
        /// <returns></returns>
        public override string GetJson()
        {
            var path = System.Web.Hosting.HostingEnvironment.MapPath("/files/fishes.json");
            return System.IO.File.ReadAllText(path);
        }
    }
}