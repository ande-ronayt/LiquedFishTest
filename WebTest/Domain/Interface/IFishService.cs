using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTest.Domain.Entity;

namespace WebTest.Domain.Interface
{
    public interface IFishService
    {
        string GetJson();

        List<FishCaught> Convert(string json);

        Dictionary<string, int> CountAllFishes(List<FishCaught> fishes);

        Dictionary<string, int> GetTop20();
    }
}
