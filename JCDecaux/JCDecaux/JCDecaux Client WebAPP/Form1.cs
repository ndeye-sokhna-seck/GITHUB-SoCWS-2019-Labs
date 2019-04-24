using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;

//new ServiceReference1.ConverterSoapClient()

namespace JCDecaux_Client_WebAPP
{
    public partial class Form1 : Form
    {
        dynamic data;
        int length = 0;
        int index = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string key = ville.Text;
            // Create a request for the URL.
            WebRequest request = WebRequest.Create(String.Concat("https://api.jcdecaux.com/vls/v1/stations?contract=", key, "&apiKey=7b45aec96e4b81c84ed122a777c07538dd513f41"));
            // If required by the server, set the credentials.
            // request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response. //TODO try catch ? to handle response errors
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            dynamic res = JsonConvert.DeserializeObject(responseFromServer);
            //result.Text = res.GetValue("name").ToString();
            data = res;
            length = res.Count;
            getNextPA(sender, e);
            // Display the content.
            //Console.WriteLine(responseFromServer);
            // Clean up the streams and the response.
            reader.Close();
            response.Close();

        }

        private void getNextPA(object sender, EventArgs e)
        {
            if (index < length - 1)
            {
                result.Text = data[index].name;
                dispo.Text = data[index].available_bikes;
                index++;
            }
            else index = 0;
            
        }
    }
}
