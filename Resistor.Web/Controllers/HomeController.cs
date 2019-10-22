using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resistor.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<SelectListItem> bandDropdownList = new List<SelectListItem>();
            bandDropdownList.Add(new SelectListItem { Text = "Select Number of Bands", Value = "" });
            bandDropdownList.Add(new SelectListItem { Text = "3 Bands", Value = "3" });
            bandDropdownList.Add(new SelectListItem { Text = "4 Bands", Value = "4" });
            bandDropdownList.Add(new SelectListItem { Text = "5 Bands", Value = "5" });
            bandDropdownList.Add(new SelectListItem { Text = "6 Bands", Value = "6" });
            ViewBag.BandDropdown = bandDropdownList;
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}