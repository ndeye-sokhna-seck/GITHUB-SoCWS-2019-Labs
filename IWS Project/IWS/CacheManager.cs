using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Threading.Tasks;

using System.Net;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;

namespace IWS
{
    static public class CacheManager
    {   static private string apiKey = "b8ee022e29ffee22c471d6ad6b59c740e1e99ac4";
        static private ObjectCache cache = MemoryCache.Default;
        private static readonly string STATIONS_CACHE_KEY = "stations";
        private static readonly string CONTRATS_CACHE_KEY = "contrats";
        
        static public List<Station> GetCachedStations()
        {
            if (cache.Contains(STATIONS_CACHE_KEY))
            {
                Console.WriteLine("fetch stations from cache");
                return (List<Station>)cache.Get(STATIONS_CACHE_KEY);
            }

            else
            {
                Console.WriteLine("Caching stations...");
                // using the api to invoke REST Service
                List<Station> stationsList = getStations();

                // Store data in the cache    
                // for the policy, here we have the cache that expires every 2 minutes
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddMinutes(2.0);
                cache.Add(STATIONS_CACHE_KEY, stationsList, cacheItemPolicy);
                return stationsList;
            }
        }

        static public List<Station> getStation(string contract_name)
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
                List<Station> res = JsonConvert.DeserializeObject<List<Station>>(responseFromServer);
                //response.Close();
                return res;
            }
        }

        static public List<Station> getCachedStation(string contract_name) {
            if (cache.Contains(STATIONS_CACHE_KEY + contract_name))
            {
                Console.WriteLine("fetch stations from cache");
                return (List<Station>)cache.Get(STATIONS_CACHE_KEY + contract_name);
            }

            else
            {
                Console.WriteLine("Caching stations...");
                // using the api to invoke REST Service
                List<Station> stationsList = getStation(contract_name);

                // Store data in the cache    
                // for the policy, here we have the cache that expires every 2 minutes
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddMinutes(2.0);
                cache.Add(STATIONS_CACHE_KEY, stationsList, cacheItemPolicy);
                return stationsList;
            }
        }

        static public List<Station> getStations()
        {
            WebRequest request = WebRequest.Create(String.Concat("https://api.jcdecaux.com/vls/v3/stations?apiKey=", apiKey));
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
                List<Station> res = JsonConvert.DeserializeObject<List<Station>>(responseFromServer);
                //response.Close();
                return res;
            }
        }
        static public List<Contract> GetCachedContracts()
        {
            if (cache.Contains(CONTRATS_CACHE_KEY))
            {
                Console.WriteLine("fetch contracts from cache");
                return (List<Contract>)cache.Get(CONTRATS_CACHE_KEY);
            }

            else
            {
                Console.WriteLine("Caching contracts...");
                // using the api to invoke REST Service
                List<Contract> contractsList = getContracts();

                // Store data in the cache    
                // for the policy, here we have the cache that expires every 2 minutes
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddMinutes(2.0);
                cache.Add(CONTRATS_CACHE_KEY, contractsList, cacheItemPolicy);
                return contractsList;
            }
        }
        static public List<Contract> getContracts()
        {
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
                return res;
            }
        }
    }
}