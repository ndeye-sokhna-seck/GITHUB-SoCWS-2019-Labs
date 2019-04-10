using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
namespace MathsLibrary
{
    public class MathsOperations : IMathsOperations
    {
        public int Add(int num1, int num2)
        {
            return (num1 + num2);
        }
        public int Multiply(int num1, int num2)
        {
            return (num1 * num2);
        }
    }
}