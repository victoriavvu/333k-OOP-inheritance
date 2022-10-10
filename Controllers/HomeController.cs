//Name: Victoria Vu
//Date: 02/18/2022
//Description: HW2 – Food Truck Checkout
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Vu_Victoria_HW2.Models;

namespace Vu_Victoria_HW2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        public HomeController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        //index or home
        public IActionResult Index()
        {
            return View();
        }

        //catering order
        public IActionResult CheckoutCatering()
        {
            return View();
        }

        //displaying catering totals
        public IActionResult CateringTotals(CateringOrder cateringOrder)
        {
            TryValidateModel(cateringOrder);

            if (ModelState.IsValid == false)
            {
                return View("CheckoutCatering", cateringOrder);
            }
            cateringOrder.CalcTotals();
            cateringOrder.CustomerType = CustomerType.Catering;
            return View(cateringOrder);
        }

        //walkup order
        public IActionResult CheckoutWalkup()
        {
            return View();
        }

        //displaying walkup totals
        public IActionResult WalkupTotals(WalkupOrder walkupOrder)
        {
            TryValidateModel(walkupOrder);

            if (ModelState.IsValid == false)
            {
                return View("CheckoutWalkup", walkupOrder);
            }
            walkupOrder.CalcTotals();
            walkupOrder.CustomerType = CustomerType.Walkup;
            return View(walkupOrder);
        }
    }


}