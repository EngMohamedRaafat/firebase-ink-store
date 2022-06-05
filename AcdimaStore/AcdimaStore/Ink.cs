using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace AcdimaStore
{
    public enum InkColor
    {
        Black,
        Cyan,
        Magento,
        Yellow
    }
    public enum AlertLevel
    {
        Low,
        Meduim,
        High,
        Severe
    }

    public class InkCollection
    {
        public IList<Ink> inks { get; set; }
    }

    public class Ink
    {
        public string BarcodeID { get; set; }
        public string Name { get; set; }
        public InkColor color { get; set; }
        public int NumberOfPages { get; set; }
        public int Quantity { get; set; }
        public AlertLevel AlertLevel { get; set; }
        public bool AllowThreat { get; set; }

        public static explicit operator Ink(JToken v)
        {

            return new Ink
            {
                BarcodeID = (string)v["BarcodeID"],
                Name = (string)v["Name"],
                color = (InkColor)(int)v["color"],
                NumberOfPages = (int)v["NumberOfPages"],
                Quantity = (int)v["Quantity"],
                AlertLevel = (AlertLevel)(int)v["AlertLevel"],
                AllowThreat = (bool)v["AllowThreat"]
            };
        }
    }
}
