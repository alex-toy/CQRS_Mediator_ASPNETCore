using AutoMapper;
using FormulaOne.Data.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : BaseController
    {
        public HomeController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        //[Route("")]
        //[Route("Home")]
        //[Route("Home/Index")]
        [HttpGet]
        [Route("{id?}")]
        public IActionResult Index(int? id)
        {
            return Ok(ControllerContext.RouteData);
        }

        [Route("Home/About")]
        [Route("Home/About/{id?}")]
        public IActionResult About(int? id)
        {
            return Ok(ControllerContext.RouteData);
        }
    }
}
