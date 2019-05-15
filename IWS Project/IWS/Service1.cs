using System;
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
    public class Availabitity
    {
        public string bikes;
        public string stands;
    }
    public class Stand
    {
        public Availabitity availabilities;
        public string capacity;
    }
    public class Position
    {
        public string latitude;
        public string longitude;
    }
    public class Station
    {
        public string number;
        public string name;
        public string address;
        public Position position;
        public string status;
        public string connected;
        public Stand totalStands;
    }


    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Service1 : IService1
    {
        private string apiKey = "b8ee022e29ffee22c471d6ad6b59c740e1e99ac4";

        static int nbrCallStationDetails = 0;
        static int nbrCallLoadCities = 0;
        public string GetStationDetails(string contract_name)
        {
            nbrCallStationDetails++;
            try
            {
                List<Station> res = CacheManager.getCachedStation(contract_name);
                //response.Close();
                //return res[0].totalStands.availabilities.stands;
                string finalRes = "[";
                foreach (Station s in res)
                {
                    finalRes = String.Concat(finalRes, "{ \"name\": \"", s.name, "\", \"number\": ", s.number, ", \"address\": \"", s.address,
                                                        "\", \"bikes\": ", s.totalStands.availabilities.bikes, ", \"stands\": ", s.totalStands.availabilities.stands,
                                                          ", \"connected\": \"", s.connected, "\", \"status\": \"", s.status,
                                                          "\", \"latitude\": \"", s.position.latitude, "\", \"longitude\": \"", s.position.longitude, "\" },");
                }
                finalRes = String.Concat(finalRes, " ]");
                return finalRes;
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

        public int[] GetStatistics()
        {
            int[] toReturn = { nbrCallStationDetails, nbrCallLoadCities };
            return toReturn;
        }

        public string LoadCities()
        {
            nbrCallLoadCities++;
            // Create a request for the URL.  
            List<Contract> res = CacheManager.GetCachedContracts();
            //response.Close();
            string finalRes = "[";
            foreach (Contract c in res)
            {
                finalRes = String.Concat(finalRes, "{ \"name\": \"", c.name, "\", \"cities\": ");
                if (c.cities != null)
                {
                    finalRes = String.Concat(finalRes, " [ ");
                    foreach (string el in c.cities)
                    {
                        finalRes = String.Concat(finalRes, " \"", el, "\", ");
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
