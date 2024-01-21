using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KspSaveEditor
{
    public partial class Form2 : Form
    {
        DetailItem detail;
        public Form2()
        {
            InitializeComponent();
            detail = new DetailItem();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            string folder = System.Environment.GetEnvironmentVariable("USERPROFILE");
            var saveFolder = $@"{folder}\AppData\LocalLow\Intercept Games\Kerbal Space Program 2\Saves\SinglePlayer";

            if (Directory.Exists(saveFolder))
            {
                folder = saveFolder;
            }
            OpenFileDialog d = new OpenFileDialog();
            d.InitialDirectory = folder;
            d.Filter = "Json files (*.json)|*.json";
            if (DialogResult.OK == d.ShowDialog())
            {
                //var encoding = GetEncoding(d.FileName);
                using (StreamReader sr = File.OpenText(d.FileName))
                {
                    var json = sr.ReadToEnd();
                    var obj = JsonSerializer.Deserialize<JsonDocument>(json);
                    var vesselsObj = obj.RootElement.GetProperty("Vessels");
                    var vesselsArr = vesselsObj.GetArrayLength();
                    List<VesselItem> vesselItems = new List<VesselItem>();
                    for (int i = 0; i < vesselsArr; i++)
                    {
                        var item = vesselsObj[i];
                        var name = item.GetProperty("AssemblyDefinition").GetProperty("assemblyName").GetString();
                        vesselItems.Add(new VesselItem
                        {
                            Name = name,
                            Element = item,
                        });
                    }
                    lstVessels.DataSource = vesselItems;
                    //using (var stream = new MemoryStream())
                    //{ 
                    //    Utf8JsonWriter writer = new Utf8JsonWriter(stream, new JsonWriterOptions { Indented = true });
                    //    obj.WriteTo(writer);
                    //    writer.Flush();
                    //    string jsonStr = Encoding.ASCII.GetString(stream.ToArray());
                    //    var eq = json == jsonStr;
                    //}
                }
            }
        }

        private void lstVessels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVessels.SelectedIndex < 0)
                return;
            var selectedVessel = lstVessels.SelectedItem as VesselItem;
            if (selectedVessel == null)
                return;
            detail.Count = 0;
            var partsObj = selectedVessel.Element.GetProperty("parts");
            var len = partsObj.GetArrayLength();
            List<PartItem> partsArr = new List<PartItem>();
            for (int i = 0; i < len; i++)
            {
                var item = partsObj[i];
                var name = item.GetProperty("partName").GetString();
                var res = item.GetProperty("partState").GetProperty("resources");
                if (res.ValueKind == JsonValueKind.Null)
                    continue;
                string type = "";
                JsonElement el = new JsonElement();

                if (res.TryGetProperty("Methane", out el))
                {
                    if (res.TryGetProperty("Oxidizer", out el))
                    {
                        type = "Meth-Ox";
                    }
                    else
                        type = "Methane";
                }
                else if (res.TryGetProperty("ElectricCharge", out el))
                {
                    type = "ElectricCharge";
                }
                else if (res.TryGetProperty("MonoPropellant", out el))
                {
                    type = "MonoPropellant";
                }
                else if (res.TryGetProperty("Xenon", out el))
                {
                    type = "Xenon";
                }
                else if (res.TryGetProperty("Hydrogen", out el))
                {
                    type = "Hydrogen";
                }
                else if (res.TryGetProperty("Ablator", out el))
                {
                    type = "Ablator";
                }
                else
                {

                }
                partsArr.Add(new PartItem
                {
                    Name = $"{name} ({type})",
                    Element = item,
                    Type = type

                });
            }
            lstParts.DataSource = partsArr;
        }

        private void lstParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            grpProperty2.Text = "--";
            grpProperty2.Enabled = false;

            if (lstParts.SelectedIndex < 0)
                return;
            var selectedPart = lstParts.SelectedItem as PartItem;
            if (selectedPart == null)
                return;
            var partObj = selectedPart.Element;
            var res = partObj.GetProperty("partState").GetProperty("resources");

            var type = selectedPart.Type;
            JsonElement resourceObj1 = new JsonElement();
            JsonElement resourceObj2 = new JsonElement();
            var count = 1;
            switch (type)
            {
                case "Methane":
                case "ElectricCharge":
                case "MonoPropellant":
                case "Xenon":
                case "Ablator": resourceObj1 = res.GetProperty(type); break;
                case "Meth-Ox":
                    resourceObj1 = res.GetProperty("Methane");
                    resourceObj2 = res.GetProperty("Oxidizer");
                    count = 2; break;
                default: return;
            }
            double cap1 = resourceObj1.GetProperty("capacityUnits").GetDouble();
            double sto1 = resourceObj1.GetProperty("storedUnits").GetDouble();
            string name1 = resourceObj1.GetProperty("name").GetString();

            detail.Capacity1 = cap1;
            detail.Stock1Default = sto1;
            detail.Count = count;
            detail.Resource1 = resourceObj1;

            lblCapacity1.Text = $"Capacity: {cap1}";
            trckStorage1.Value = Convert.ToInt32(sto1 * 1000 / cap1);
            grpProperty1.Text = name1;
            if (count == 2)
            {
                detail.Resource2 = resourceObj2;

                double cap2 = resourceObj2.GetProperty("capacityUnits").GetDouble();
                double sto2 = resourceObj2.GetProperty("storedUnits").GetDouble();
                string name2 = resourceObj2.GetProperty("name").GetString();

                detail.Capacity2 = cap2;
                detail.Stock2Default = sto2;

                lblCapacity2.Text = $"Capacity: {cap2}";
                trckStorage2.Value = Convert.ToInt32(sto2 * 1000 / cap2);
                grpProperty2.Text = name2;
                grpProperty2.Enabled = true;
            }
        }

        private void trckStorage1_Scroll(object sender, EventArgs e)
        {
        }

        private void trckStorage1_ValueChanged(object sender, EventArgs e)
        {

            if (detail.Count == 0)
                return;
            detail.Stock1 = detail.Stock1Default * (double)trckStorage1.Value / (double)trckStorage1.Maximum;
            txtValue1.Text = detail.Stock1.ToString("########0.###");
        }

        private void trckStorage2_ValueChanged(object sender, EventArgs e)
        {
            if (detail.Count <= 1)
                return;
            detail.Stock2 = detail.Stock2Default * (double)trckStorage2.Value / (double)trckStorage2.Maximum;
            txtValue2.Text = detail.Stock2.ToString("########0.###");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (detail.Count == 0)
                return;

            foreach (var item in detail.Resource1.EnumerateObject())
            {
            }
        }
    }

}
