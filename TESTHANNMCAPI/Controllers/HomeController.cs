using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HANNMCAIRTKT;
using Microsoft.AspNetCore.Mvc;
using TESTHANNMCAPI.Models;

namespace TESTHANNMCAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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

        [HttpPost]
        public async Task<IActionResult> AirShop(AirShopRequest model)
        {
            TestWSClient AirTktService = new TestWSClient();
            informationRQ shopRequestInfo = new informationRQ();
            shoppingResponse KetQuaAirShop = new shoppingResponse();            

            shopRequestInfo.TripType = model.TripType;
            shopRequestInfo.DepDate = model.DepartureDate.Date.ToString("dd/MM/yyyy");
            if (shopRequestInfo.TripType == "RT")
            {
                shopRequestInfo.ArrDate = model.ArrivalDate.Date.ToString("dd/MM/yyyy");
            }
            shopRequestInfo.DepCity = model.DepartureCity;           
            shopRequestInfo.ArrCity = model.ArrivalCity;
            shopRequestInfo.ClassService = model.ClassOfServices;
            shopRequestInfo.FlightType = model.FlightType;
            shopRequestInfo.ADT = model.NumberOfAdt;
            shopRequestInfo.CNN = model.NumberOfChd;
            shopRequestInfo.INF = model.NumberOfInf;

            KetQuaAirShop =await AirTktService.shoppingAsync(shopRequestInfo);
            if (KetQuaAirShop.@return.Status == "Success")
            {
                HttpContext.Session.Set("Dschuyenbay", KetQuaAirShop); //dua thong tin ket qua search chuyen bay vao session
                return View(KetQuaAirShop.@return.Itinerary);
            }
            else
            {
                ViewBag.NoFlight = "Khong co chuyen bay";
                return View();
            }
            
        }

        public IActionResult Book()
        {
            //HttpContext.Session.Set
            return View();
        }

        [HttpPost]
        public IActionResult Book(AirBookRequest model)
        {
            return View();
        }
    }
}
