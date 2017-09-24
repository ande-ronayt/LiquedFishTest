using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTest.Domain.Entity;
using WebTest.Domain.Interface;

namespace WebTest.Domain.Concrete
{
    public abstract class FishServiceBase : IFishService
    {
        public abstract string GetJson();

        public List<FishCaught> Convert(string json)
        {
            return JsonConvert.DeserializeObject<List<FishCaught>>(json);
        }

        public Dictionary<string, int> CountAllFishes(List<FishCaught> caughts)
        {
            var result = new Dictionary<string, int>();
            foreach (var item in caughts)
            {
                var key = String.Join(", ", item.Fishes.OrderBy(x=>x));
                if (result.Keys.Contains(key))
                    result[key]++;
                else
                    result.Add(key, 1);
            }

            return result;
        }

        public Dictionary<string, int> GetTop20()
        {
            var json = GetJson();
            var data = CountAllFishes(this.Convert(json));
            return data.OrderByDescending(x => x.Value).Take(20).ToDictionary(x=>x.Key, x=>x.Value);
        }
    }
}