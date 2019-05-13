using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WS_Client
{
    public class Contract
    {
        public string name;
        public List<string> cities;

    }
    public partial class _Default : Page
    {
        private string result;
        private string stats;
        private List<Contract> cities;
        public string Result { get { return result; } }
        public List<Contract> Cities { get { return cities; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            IWS.Service1Client service = new IWS.Service1Client();
            
            cities = JsonConvert.DeserializeObject<List<Contract>>(service.LoadCities());
            List<ListItem> items = new List<ListItem>();
            foreach(Contract city in cities)
            {
                items.Add(new ListItem(city.name, city.name));
            }
            choice.DataSource = items;
            choice.DataBind();

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            IWS.Service1Client service = new IWS.Service1Client();
            //int num;
            //bool isNStationValid = Int32.TryParse(NStation.Text.ToString(), out num);
            //if (isNStationValid)
             result = service.GetStationDetails(choice.SelectedItem.Value);
           
        }
        protected void GetStatistics(object sender, EventArgs e)
        {
            IWS.Service1Client service = new IWS.Service1Client();
            stats = service.GetStatistics();
        }
    }
}