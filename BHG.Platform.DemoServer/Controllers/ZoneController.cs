using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BHG.Platform.DemoServer.Data.DbContexts;
using BHG.Platform.DemoServer.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BHG.Platform.DemoServer.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ZoneController : Controller
    {
        private readonly IZoneService _zoneService;

        public ZoneController(IZoneService zoneService)
        {
            _zoneService = zoneService;
        }

        /// <summary>
        /// 根据ID获取Zone
        /// </summary>
        /// <param name="id">请输入Zone Id，例：BJ</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IActionResult GetZoneById(string id)
        {
            var zone = _zoneService.GetZoneById(id);

            if (zone != null)

                return Ok(new
                {
                    code = 1,
                    msg = "成功",
                    data = zone
                });
            return Ok(new
            {
                code = 0,
                msg = "失败"
            });
        }
    }
}