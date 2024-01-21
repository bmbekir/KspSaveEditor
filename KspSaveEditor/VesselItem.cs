using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace KspSaveEditor
{
    class VesselItem
    {
        public string Name { get; set; }
        public JsonNode Element { get; set; }
    }

    class PartItem
    {
        public string Name { get; set; }
        public JsonNode Element { get; set; }
        public string Type { get; set; }
    }

    class DetailItem
    {

        public double Stock2 { get;set; }
        public double Capacity2 { get;set; }
        public double Capacity1 { get;set; }
        public double Stock1 { get;set; }
        public int Count { get;set; }
        public JsonNode Resource1 { get;set; }
        public JsonNode Resource2 { get;set; }
    }
}
