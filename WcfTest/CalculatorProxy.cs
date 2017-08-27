using System.ServiceModel;

namespace WcfTest
{
    public class CalculatorProxy : ClientBase<ICalculatorService>, ICalculatorService
    {
        public double Add(double n1, double n2) => Channel.Add(n1, n2);

        public double Divide(double n1, double n2) => Channel.Divide(n1, n2);

        public double Multiply(double n1, double n2) => Channel.Multiply(n1, n2);

        public double Subtract(double n1, double n2) => Channel.Subtract(n1, n2);
    }
}