using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Resistor;
using Demo.Models;

namespace Demo.Controllers
{
    public class ResistorController : Controller
    {
        private readonly Data resistor;

        public ResistorController()
        {
            resistor = new Data();
        }

        //
        // GET: /Resistor/

        public ActionResult Index(int id)
        {
            ResistorType collection = resistor.GetBand(id);
            ResistorModel model = new ResistorModel();

            foreach (var band in collection.Bands)
            {
                string dropdownName = band.GetType().Name;
                List<SelectListItem> list = new List<SelectListItem>();
                list.Add(new SelectListItem { Text = "Select", Value = "" });
                foreach (var code in band.Codes.OrderBy(r => r.Order))
                {
                    list.Add(new SelectListItem {Text = code.Color, Value = code.Order.ToString() });
                }

                model.ResistorDropdownList.Add(new KeyValuePair<string, List<SelectListItem>>(dropdownName, list));
            }

            return View(model);
        }

        public ActionResult Calculate(string value)
        {
            int[] nums = value.Split(',').Select(int.Parse).ToArray();
            resistor.Update(nums.ToList());
            CalculationModel result = resistor;
            return View(result);
        }
    }
}