using Face_Recognition_Attendance.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Face_Recognition_Attendance.Controllers
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
            ViewBag.target_directory = "E:/Others/face-recognition-python/Images";
            ViewBag.pythonApiURL = "http://127.0.0.1:5000/process_frame";

            return View();
        }

        public IActionResult AttendanceMarking(string fileName)
        {
            // save attendance for this employee
            string[] str = fileName.Split('-');
            string id = str[0].Split('_')[1];
            string name = str[1].Split('_')[1];

            return Json(new
            {
                success = true,
                message = $"Attendance marked for id : {id} and Name : {name}"
            });
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