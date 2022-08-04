using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        public Calculator()
        {

        }

        public Dictionary<string, string> Operators { get; private set; } = new Dictionary<string, string>()
        {
            {"add", "+"},
            {"subtract", "-"},
            {"multiply", "*"},
            {"divide", "/"},
            {"remainder", "%"},
        };

        public string Op { get; set; } = string.Empty;

        public double Num1 { get; set; } = double.NaN;

        public double Num2 { get; set; } = double.NaN;

        public string Calculate()
        {
            string result;

            switch (Op)
            {
                case "+":
                    result = Add();
                    break;
                case "-":
                    result = Subtract();
                    break;
                case "*":
                    result = Multiply();
                    break;
                case "/":
                    result = Divide();
                    break;
                case "%":
                    result = Remainder();
                    break;
                default:
                    result = $"Invalid operation: {Op}";
                    break;
            }

            return result;
        }

        public void Reset()
        {
            Op = string.Empty;
            Num1 = double.NaN;
            Num2 = double.NaN;
        }

        public bool Ready()
        {
            return (Op != string.Empty && !double.IsNaN(Num1) && !double.IsNaN(Num2));
        }

        private string Add()
        {
            double result = Math.Round(Num1 + Num2, 2);
            return $"{Num1} + {Num2} = {result}";
        }

        private string Subtract()
        {
            double result = Math.Round(Num1 - Num2, 2);
            return $"{Num1} - {Num2} = {result}";
        }

        private string Multiply()
        {
            double result = Math.Round(Num1 * Num2, 2);
            return $"{Num1} x {Num2} = {result}";
        }

        private string Divide()
        {
            try
            {
                if (Num2 == 0)
                {
                    throw new DivideByZeroException();
                }

                double result = Math.Round(Num1 / Num2, 2);
                return $"{Num1} / {Num2} = {result}";
            }
            catch (DivideByZeroException)
            {
                return $"Division by {Num2}!";
            }
        }

        private string Remainder()
        {
            try
            {
                if (Num2 == 0)
                {
                    throw new DivideByZeroException();
                }

                double result = Math.Round(Num1 % Num2, 2);
                return $"{Num1} % {Num2} = {result}";
            }
            catch (DivideByZeroException)
            {
                return $"Division by {Num2}!";
            }
        }
    }
}
