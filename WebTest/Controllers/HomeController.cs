using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WebTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult QuestionOne()
        {
            return View();
        }
        // GET: Home
        public ActionResult Index()
        {
            var url = @"https://liquid.fish/fishes.json";
            //url = @"https://feeds.citibikenyc.com/stations/stations.json";
            using (WebClient wc = new WebClient())
            {
                var result = new List<string>();
                try
                {
                    var json = wc.DownloadString(url);
                    var data = JsonConvert.DeserializeObject<Root>(json);
                    result = CountFish(data.Caughts);
                }
                catch (Exception e)
                {
                    result.Add("Errror : " + e.Message);
                }

                return View(result);
            }
        }

        private List<string> CountFish(List<FishCaught> list)
        {
            var result = new Dictionary<string, int>();
            foreach (var item in list)
            {
                foreach (var name in item.fish_caught)
                {
                    if (result.Keys.Contains(name))
                        result[name]++;
                    else
                        result.Add(name, 1);
                }
            }

            return result.OrderByDescending(x => x.Value).Take(20).Select(x => x.Key).ToList();
        }

    }

    public class FishSort
    {
        public string Name { get; set; }

        public int Count { get; set; }
    }

    public class FishCaught
    {
        public DateTime date { get; set; }

        public List<string> fish_caught { get; set; }
    }

    public class Root
    {
        public List<FishCaught> Caughts { get; set; }
    }
}