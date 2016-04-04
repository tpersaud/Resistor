using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Models
{
    public class ResistorModel
    {
        public List<KeyValuePair<string, List<SelectListItem>>> ResistorDropdownList { get; set; }

        public ResistorModel()
        {
            ResistorDropdownList = new List<KeyValuePair<string, List<SelectListItem>>>();
        }
    }

    public class CalculationModel
    {
        public int Digit { get; set; }
        public int Multiplier { get; set; }
        public double? Tolerance { get; set; }
        public double? Temperature { get; set; }
        public long Ohm { get; set; }
        public double MaxConfidence { get; set; }
        public double MinConfidence { get; set; }

        public static implicit operator CalculationModel(Resistor.Data data)
        {
            CalculationModel model = new CalculationModel();
            model.Digit = data.Digit;
            model.Multiplier = data.Multiplier;
            model.Tolerance = data.Tolerance;
            model.Temperature = data.Temperature;
            model.Ohm = data.Ohm;
            model.MinConfidence = data.Confidence.Min;
            model.MaxConfidence = data.Confidence.Max;
            return model;
        }
    }
}