using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using eAlbum.Models;

namespace eAlbum.Controllers
{
    public class HomeController : Controller
    {
         private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public class ImagesViewVM
        {
            public int ImagesViewId { get; set; }
            public string FileName { get; set; }
        }
        public static List<ImagesViewVM> imagesViewVMList = new List<ImagesViewVM>
        {
            new ImagesViewVM
            {
                ImagesViewId=1,
                FileName="1.jpg"
            },
            new ImagesViewVM
            {
                ImagesViewId=2,
                FileName="2.jpg"
            },
            new ImagesViewVM
            {
                ImagesViewId=3,
                FileName="3.jpg"
            },
            new ImagesViewVM
            {
                ImagesViewId=4,
                FileName="4.jpg"
            },
            new ImagesViewVM
            {
                ImagesViewId=5,
                FileName="5.jpg"
            },
            new ImagesViewVM
            {
                ImagesViewId=6,
                FileName="6.jpg"
            },
            new ImagesViewVM
            {
                ImagesViewId=7,
                FileName="7.jpg"
            },
            new ImagesViewVM
            {
                ImagesViewId=8,
                FileName="8.jpg"
            },
            new ImagesViewVM
            {
                ImagesViewId=9,
                FileName="9.jpg"
            },
            new ImagesViewVM
            {
                ImagesViewId=10,
                FileName="10.jpg"
            },
            new ImagesViewVM
            {
                ImagesViewId=11,
                FileName="11.jpg"
            },
            new ImagesViewVM
            {
                ImagesViewId=12,
                FileName="12.jpg"
            },
            new ImagesViewVM
            {
                ImagesViewId=13,
                FileName="13.jpg"
            }//,
            // new ImagesViewVM
            // {
            //     ImagesViewId=14,
            //     FileName="14.jpg"
            // },
            // new ImagesViewVM
            // {
            //     ImagesViewId=15,
            //     FileName="15.jpg"
            // },
            // new ImagesViewVM
            // {
            //     ImagesViewId=16,
            //     FileName="16.jpg"
            // },
            // new ImagesViewVM
            // {
            //     ImagesViewId=17,
            //     FileName="17.jpg"
            // },
            // new ImagesViewVM
            // {
            //     ImagesViewId=18,
            //     FileName="18.jpg"
            // },
            // new ImagesViewVM
            // {
            //     ImagesViewId=19,
            //     FileName="19.jpg"
            // },
            // new ImagesViewVM
            // {
            //     ImagesViewId=20,
            //     FileName="20.jpg"
            // },
            // new ImagesViewVM
            // {
            //     ImagesViewId=21,
            //     FileName="21.jpg"
            // },
            // new ImagesViewVM
            // {
            //     ImagesViewId=22,
            //     FileName="22.jpg"
            // },
            // new ImagesViewVM
            // {
            //     ImagesViewId=23,
            //     FileName="23.jpg"
            // },
            // new ImagesViewVM
            // {
            //     ImagesViewId=24,
            //     FileName="24.jpg"
            // }
        };

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetImages(int pageNumber, int pageSize)
        {
            JsonResult result = new JsonResult(null,null);
            try
            {
                pageNumber = pageNumber - 1;
                var CertificateList = imagesViewVMList.Skip(pageNumber * pageSize).Take(pageSize).ToList();
                bool NoMoredata = false;
                if (CertificateList.Count() <= 0)
                {
                    NoMoredata = true;
                }
               
                result = this.Json(new
                {
                    IsSuccess = true,
                    data = CertificateList,
                    NoMoreData = NoMoredata
                });
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Message = ex.Message });

            }
            return result;
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
