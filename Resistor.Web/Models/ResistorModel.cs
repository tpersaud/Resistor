using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Resistor.Web.Models
{
    public class ResistorModel
    {
        public List<KeyValuePair<string, List<SelectListItem>>> ResistorDropdownList { get; set; }

        public ResistorModel()
        {
            ResistorDropdownList = new List<KeyValuePair<string, List<SelectListItem>>>();
        }

        public static implicit operator ResistorModel(ResistorType resistorType)
        {
            ResistorModel model = new ResistorModel();

            foreach (var band in resistorType.Bands)
            {
                string dropdownName = band.GetType().Name;
                List<SelectListItem> list = new List<SelectListItem>();
                list.Add(new SelectListItem { Text = "Select", Value = "" });
                foreach (var code in band.Codes.OrderBy(r => r.Order))
                {
                    list.Add(new SelectListItem { Text = code.Color, Value = code.Order.ToString() });
                }

                model.ResistorDropdownList.Add(new KeyValuePair<string, List<SelectListItem>>(dropdownName, list));
            }

            return model;
        }
    }

    public class CalculationModel
    {
        [Display(Name = "Digit")]
        public int Digit { get; set; }

        [Display(Name = "Multiplier")]
        public int Multiplier { get; set; }

        [Display(Name = "Tolerance")]
        public double Tolerance { get; set; }

        [Display(Name = "Temperature")]
        public double? Temperature { get; set; }

        [Display(Name = "Final Calculations")]
        public string Calculations { get; set; }

        [Display(Name = "Confidence")]
        public string Confidence { get; set; }

        public static implicit operator CalculationModel(Data data)
        {
            CalculationModel model = new CalculationModel();
            model.Digit = data.Digit;
            model.Multiplier = data.Multiplier;
            model.Tolerance = (double) data.Tolerance;
            model.Temperature = data.Temperature;
            model.Calculations = CalculateString(data.Ohm, (double) data.Tolerance, data.Temperature);
            model.Confidence = ConfidencesString(data.Confidence);
            return model;
        }

        private static string CalculateString(long ohm, double tolerance, double? temperature)
        {
            string calculations = String.Format("{0}Ω ± {1}%", ohm.ToString("#,##0"), tolerance * 100);

            if (temperature != null)
                calculations = String.Format("{0} {1}ppm/C°", calculations, temperature);

            return calculations;
        }

        private static string ConfidencesString(Interval interval)
        {
            string confidence = String.Format("{0}Ω - {1}Ω", interval.Min.ToString("#,##0"), interval.Max.ToString("#,##0")); ;
            return confidence;
        }

    }
}