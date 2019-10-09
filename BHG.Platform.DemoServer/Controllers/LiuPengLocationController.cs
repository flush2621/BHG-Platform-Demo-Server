using Microsoft.AspNetCore.Mvc;
using BHG.Platform.DemoServer.Data.Services;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BHG.Platform.DemoServer.Controllers
{
    [Route("api/[controller]/[action]")]
    public class LiuPengLocationController : Controller
    {
        private readonly ILiuPengLocationService _liuPengLocationService;
        public LiuPengLocationController(ILiuPengLocationService liuPengLocationService)
        {
            _liuPengLocationService = liuPengLocationService;
        }
        /// <summary>
        /// 根据ID获取Locations
        /// </summary>
        /// <param name="id">请输入LiuPengLocation Id，例：100001</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IActionResult GetLiuPengLocationById(int id)
        {
            var location = _liuPengLocationService.GetLiuPengLocationById(id);

            if (location != null)

                return Ok(new
                {
                    code = 1,
                    msg = "成功",
                    data = location
                });
            return Ok(new
            {
                code = 0,
                msg = "失败"
            });
        }
        /// <summary>
        /// 获取Locaitons全表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IActionResult ListAllStores()
        {
            var locations = _liuPengLocationService.ListAllStores();

            if (locations.Count > 0)

                return Ok(new
                {
                    code = 1,
                    msg = "成功",
                    data = locations
                });
            return Ok(new
            {
                code = 0,
                msg = "失败"
            });
        }
        /// <summary>
        /// 根据regionId获取Locations信息
        /// </summary>
        /// <param name="regionId">请输入regionId，例：100110</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IActionResult ListAllLocationsByRegionId(int regionId)
        {
            var locs = _liuPengLocationService.ListAllLocationsByRegionId(regionId);
            if (locs.Count > 0)

                return Ok(new
                {
                    code = 1,
                    msg = "成功",
                    data = locs
                });
            return Ok(new
            {
                code = 0,
                msg = "失败"
            });
        }
    }
}
