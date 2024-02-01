using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KspSaveEditor
{
    public partial class MainForm : Form
    {
        DetailItem detail;
        string FileName;
        JsonNode Obj;
        public MainForm()
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
                FileName=d.FileName;
                using (StreamReader sr = File.OpenText(d.FileName))
                {
                    var json = sr.ReadToEnd();
                    var obj = JsonNode.Parse(json);
                    Obj = obj;
                    var vesselsObj = obj["Vessels"];// ("Vessels");
                    var vesselsArr = vesselsObj.AsArray();
                    List<VesselItem> vesselItems = vesselsArr.Select(b =>
                    new VesselItem
                    {
                        Name = b["AssemblyDefinition"]["assemblyName"].GetValue<string>(),
                        Element = b
                    }).ToList();

                    lstVessels.DataSource = vesselItems;
                }
            }
        }

        private string GetPartType(JsonNode node)
        {
            if (node == null)
                return null;
            if (node["Methane"] != null)
            {
                if (node["Oxidizer"] != null)
                {
                    return "Meth-Ox";
                }
                else
                    return "Methane";
            }
            else if (node["ElectricCharge"] != null)
            {
                if (node["MonoPropellant"] != null)
                {
                    return "Elec-Mon";
                }
                else
                    return "ElectricCharge";
            }
            else if (node["MonoPropellant"] != null)
            {
                return "MonoPropellant";
            }
            else if (node["Xenon"] != null)
            {
                return "Xenon";
            }
            else if (node["Hydrogen"] != null)
            {
                return "Hydrogen";
            }
            else if (node["Ablator"] != null)
            {
                return "Ablator";
            }
            else
            {
                return string.Empty;
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
            var partsObj = selectedVessel.Element["parts"];
            List<PartItem> partsArr = partsObj.AsArray().Select(b => new PartItem
            {
                Element = b,
                Name = b["partName"].GetValue<string>(),
                Type = GetPartType(b["partState"]["resources"])
            }).Where(b => !string.IsNullOrEmpty(b.Type)).ToList();
            lstParts.DataSource = partsArr;
        }

        private void lstParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            grpProperty2.Text = "--";
            grpProperty2.Enabled = false;
            detail.Count = 0;
            trckStorage1.Value = 0;
            trckStorage2.Value = 0;
            txtValue1.Text = "";
            txtValue2.Text = "";
            lblCapacity1.Text = "Capacity:";
            lblCapacity2.Text = "Capacity:";
            if (lstParts.SelectedIndex < 0)
                return;
            var selectedPart = lstParts.SelectedItem as PartItem;
            if (selectedPart == null)
                return;
            var partObj = selectedPart.Element;
            var res = partObj["partState"]["resources"];

            var type = selectedPart.Type;
            JsonNode resourceObj2 = null;
            var count = 1;
            JsonNode resourceObj1;
            switch (type)
            {
                case "Methane":
                case "ElectricCharge":
                case "MonoPropellant":
                case "Xenon":
                case "Hydrogen":
                case "Ablator": resourceObj1 = res[type]; break;
                case "Meth-Ox":
                    resourceObj1 = res["Methane"];
                    resourceObj2 = res["Oxidizer"];
                    count = 2; break;
                case "Elec-Mon":
                    resourceObj1 = res["ElectricCharge"];
                    resourceObj2 = res["MonoPropellant"];
                    count = 2; break;
                default: return;
            }
            double cap1 = (double)resourceObj1["capacityUnits"];
            double sto1 = (double)resourceObj1["storedUnits"];
            string name1 = resourceObj1["name"].ToString();

            detail.Capacity1 = cap1;
            detail.Count = count;
            detail.Resource1 = resourceObj1;

            lblCapacity1.Text = $"Capacity: {cap1}";
            trckStorage1.Value = Convert.ToInt32(sto1 * 1000 / cap1);
            grpProperty1.Text = name1;
            if (count == 2)
            {
                detail.Resource2 = resourceObj2;
                double cap2 = (double)resourceObj2["capacityUnits"];
                double sto2 = (double)resourceObj2["storedUnits"];
                string name2 = resourceObj2["name"].ToString();


                detail.Capacity2 = cap2;

                lblCapacity2.Text = $"Capacity: {cap2}";
                trckStorage2.Value = Convert.ToInt32(sto2 * 1000 / cap2);
                grpProperty2.Text = name2;
                grpProperty2.Enabled = true;
            }
        }

        private void trckStorage1_ValueChanged(object sender, EventArgs e)
        {

            if (detail.Count == 0)
                return;
            detail.Stock1 = detail.Capacity1 * (double)trckStorage1.Value / (double)trckStorage1.Maximum;
            txtValue1.Text = detail.Stock1.ToString("########0.###");
        }

        private void trckStorage2_ValueChanged(object sender, EventArgs e)
        {
            if (detail.Count <= 1)
                return;
            detail.Stock2 = detail.Capacity2 * (double)trckStorage2.Value / (double)trckStorage2.Maximum;
            txtValue2.Text = detail.Stock2.ToString("########0.###");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (detail.Count == 0)
                return;

            detail.Resource1["storedUnits"] = detail.Stock1;

            if (detail.Count <= 1)
                return;

            detail.Resource2["storedUnits"] = detail.Stock2;

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FileName) || Obj == null)
                return;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json files (*.json)|*.json";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = FileName;
            if(saveFileDialog.ShowDialog()!=DialogResult.OK)
            {
                return;
            }

            using (var stream = File.OpenWrite(saveFileDialog.FileName))
            {
                var writer = new System.Text.Json.Utf8JsonWriter(stream, new System.Text.Json.JsonWriterOptions { Indented = true });
                Obj.WriteTo(writer);
                writer.Flush();
            }
        }
    }

}
