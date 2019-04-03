using System;
using System.ServiceModel.Web;

namespace REST_APP
{
    public class Service1 : IService1
    {
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
       UriTemplate = "data/{id}")]
        public Person GetData(string id)
        {
            // lookup person with the requested id
            return new Person()
            {
                Id = Convert.ToInt32(id),
                Name = "Leo Messi"
            };
        }
    }
    }