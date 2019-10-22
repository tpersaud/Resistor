using Microsoft.AspNetCore.Mvc;
using Resistor.Web.Models;
using System.Linq;

namespace Resistor.Web.Controllers
{
    public class ResistorController : Controller
    {
        private readonly Data resistor;

        public ResistorController()
        {
            resistor = new Data();
        }

        public ActionResult Index(int id)
        {
            ResistorModel model = resistor.GetBand(id);
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