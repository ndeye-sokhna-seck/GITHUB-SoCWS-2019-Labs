using System.ServiceModel;
namespace REST_APP
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Person GetData(string id);
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}