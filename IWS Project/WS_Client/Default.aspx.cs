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
    public class Station
    {
        public string number;
        public string name;
        public string address;
        public string bikes;
        public string stands;
        public string latitude;
        public string longitude;
        public string status;
        public string connected;
    }

    public partial class _Default : Page
    {
        public int[] stats = { 0, 0 };
        private List<Station> result;
        private List<Contract> cities;
        private string draft;
        public bool asked = false;
        IWS.Service1Client service = new IWS.Service1Client();

        public List<Station> Result { get { return result; } }
        public List<Contract> Cities { get { return cities; } }
        public string Draft { get { return draft; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            result = new List<Station>();
            
            cities = JsonConvert.DeserializeObject<List<Contract>>(service.LoadCities());
            List<ListItem> items = new List<ListItem>();
            foreach(Contract city in cities)
            {
                items.Add(new ListItem(city.name, city.name));
            }
            choice.DataSource = items;
            choice.DataBind();
        }

        protected void getStationList(object sender, EventArgs e)
        {
            //draft = choice.SelectedItem.Text;
            //TextBox1.Text = draft;
            result = JsonConvert.DeserializeObject <List<Station>>(service.GetStationDetails(choice.SelectedItem.Value));
            //draft = service.GetStationDetails(choice.SelectedItem.Value);
        }
        protected void GetStatistics(object sender, EventArgs e)
        {
            stats = service.GetStatistics();
        }
    }
}