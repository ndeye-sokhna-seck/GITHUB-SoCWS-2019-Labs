﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;

////API KEY 


namespace IWS

{
    
    public class Contract
    {
        
        public string name;
        public List<string> cities;

    }
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Service1 : IService1
    {
        private string apiKey = "b8ee022e29ffee22c471d6ad6b59c740e1e99ac4";
        private int nbrCallStationDetails = 0;
        private int nbrCallLoadCities = 0;

        public string GetStationDetails(string contract_name)
        {
            nbrCallStationDetails++;
            try
            {
                WebRequest request = WebRequest.Create(String.Concat("https://api.jcdecaux.com/vls/v3/stations?contract=", contract_name, "&apiKey=", apiKey));
                // If required by the server, set the credentials.  
                request.Credentials = CredentialCache.DefaultCredentials;

                // Get the response.  
                WebResponse response = request.GetResponse();
                // Display the status.  
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                // Get the stream containing content returned by the server. 
                // The using block ensures the stream is automatically closed. 
                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.  
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.  
                    string responseFromServer = reader.ReadToEnd();
                    dynamic res = JsonConvert.DeserializeObject(responseFromServer).ToString();
                    //response.Close();
                    return res;
                }
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                // Something more serious happened
                // like for example you don't have network access
                // we cannot talk about a server exception here as
                // the server probably was never reached
                return "-1";
            }

        }

        public string GetStatistics()
        {
            string toReturn = String.Concat("{ \"nbrCallDetails\": \"", nbrCallStationDetails, "\", \"nbrCallLoadCities\": ",nbrCallLoadCities);
            return toReturn;
        }

        public string LoadCities()
        {
            nbrCallLoadCities++;
            // Create a request for the URL.   
            WebRequest request = WebRequest.Create(String.Concat("https://api.jcdecaux.com/vls/v3/contracts?apiKey=", apiKey));
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;

            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server. 
            // The using block ensures the stream is automatically closed. 
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseFromServer = reader.ReadToEnd();
                List<Contract> res = JsonConvert.DeserializeObject<List<Contract>>(responseFromServer);
                //response.Close();
                string finalRes = "[";
                foreach(Contract c in res)
                {
                    finalRes = String.Concat(finalRes, "{ \"name\": \"", c.name, "\", \"cities\": ");
                    if (c.cities != null)
                    {
                        finalRes = String.Concat(finalRes, " [ ");
                        foreach (string el in c.cities)
                        {
                            finalRes = String.Concat(finalRes, " \"", el , "\", ");
                        }
                        finalRes = String.Concat(finalRes, "] },");
                    }
                    else finalRes = String.Concat(finalRes, "null },");
                   
                }
                finalRes = String.Concat(finalRes, " ]");
                return finalRes;
                
            }
        }
    }
}
