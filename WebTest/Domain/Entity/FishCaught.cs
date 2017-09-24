using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest.Domain.Entity
{
    public class FishCaught
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("fish_caught")]
        public List<string> Fishes { get; set; }
    }

    public class FishCaughtRoot
    {
        public List<FishCaught> List { get; set; }
    }
}