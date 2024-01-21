using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KspSaveEditor
{
    class VesselItem
    {
        public string Name { get; set; }
        public JsonElement Element { get; set; }
    }

    class PartItem
    {
        public string Name { get; set; }
        public JsonElement Element { get; set; }
        public string Type { get; set; }
    }

    class DetailItem
    {
        internal JsonElement Resource1;

        public double Stock2 { get; internal set; }
        public double Capacity2 { get; internal set; }
        public double Capacity1 { get; internal set; }
        public double Stock1 { get; internal set; }
        public int Count { get; internal set; }
        public double Stock1Default { get; internal set; }
        public double Stock2Default { get; internal set; }
        public JsonElement Resource2 { get; internal set; }
    }
}
