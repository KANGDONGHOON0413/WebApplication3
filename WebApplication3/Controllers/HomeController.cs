using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var firstUser = new UserClass();
            //firstUser.UserNo = 1002;
            //firstUser.UserID = "kmerits";

            //위와 같은 표현방식이다.
            var firstUser = new UserClass
            {
                UserNo = 1002,
                UserID = "kmerits"
            };

            ViewData["UserNo"] = firstUser.UserNo;
            ViewData["UserID"] = firstUser.UserID;  //ViewData는 단일값만을 반환할 수 있다(셋 중 가장 좁은 범위를 넘겨준다)
            ViewBag.newBag = firstUser; //viewbag를 통한 데이터 넘기기(dynamic type)(셋중 가장 넓은 범위를 넘겨줄 수 있다)
            return View(firstUser); //매개변수를 통한 데이터 넘기기(object type)
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
