using Microsoft.AspNetCore.Mvc;
using BHG.Platform.DemoServer.Data.Services;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BHG.Platform.DemoServer.Controllers
{
    [Route("api/[controller]/[action]")]
    public class LiuPengDistrictController : Controller
    {
        private readonly ILiuPengDistrictService _liuPengDistrictService;
        public LiuPengDistrictController(ILiuPengDistrictService liuPengDistrictService)
        {
            _liuPengDistrictService = liuPengDistrictService;
        }
        /// <summary>
        /// 根据DistrictId获取District信息
        /// </summary>
        /// <param name="id">请输入DistrictId，例：100110001</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IActionResult GetLiuPengDistrictById(int id)
        {
            var district = _liuPengDistrictService.GetLiuPengDistrictById(id);
            if (district != null)

                return Ok(new
                {
                    code = 1,
                    msg = "成功",
                    data = district
                });
            return Ok(new
            {
                code = 0,
                msg = "失败"
            });
        }
        /// <summary>
        /// 根据DistrictId获取District及其包含的location信息
        /// </summary>
        /// <param name="id">请输入DistrictId，例：100110001</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IActionResult GetDistrictWithLocaitonsById(int id)
        {
            var district = _liuPengDistrictService.GetDistrictWithLocaitonsById(id);
            
            if (district != null)

                return Ok(new
                {
                    code = 1,
                    msg = "成功",
                    data = district
                });
            return Ok(new
            {
                code = 0,
                msg = "失败"
            });
        }
    }
}
