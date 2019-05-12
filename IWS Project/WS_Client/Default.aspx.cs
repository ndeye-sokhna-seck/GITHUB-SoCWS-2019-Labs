using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WS_Client
{
    public partial class _Default : Page
    {
        private string result = "";
        public string Result { get { return result; } }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Town_TextChanged(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            IWS_Velib.Service1Client service1Client = new IWS_Velib.Service1Client();
            int num;
            bool isNStationValid = Int32.TryParse(NStation.Text.ToString(), out num);
            if (isNStationValid)
                result = service1Client.GetStationDetails(Town.Text.ToString(), num);
            


        }
    }
}