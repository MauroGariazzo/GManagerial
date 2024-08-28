using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.Geo.models
{
    internal interface IDAOGeo
    {
        List<string> GetRegions();
        Dictionary<string, string> GetProvinces(string region);
        List<string> GetCities(string province);
    }
}
