using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BHG.Platform.DemoServer.Data.Entities;

namespace BHG.Platform.DemoServer.Data.Services
{
    public interface IZoneService
    {
        Zone GetZoneById(string id);
    }
}
