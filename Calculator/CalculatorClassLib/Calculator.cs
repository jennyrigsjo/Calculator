namespace CalculatorClassLib
{
    public class Calculator
    {
        public Calculator()
        {
            Operators.Add("add", "+");
            Operators.Add("subtract", "-");
            Operators.Add("multiply", "*");
            Operators.Add("divide", "/");
            Operators.Add("remainder", "%");
        }

        private Dictionary<string, string> _operators = new Dictionary<string, string>();
        public Dictionary<string, string> Operators
        {
            get => _operators;
            private set => _operators = value;
        }

        private string _op = string.Empty;
        public string Op
        {
            get => _op;
            set => _op = value;
        }

        private double _num1 = double.MinValue;
        public double Num1
        {
            get => _num1;
            set => _num1 = value; 
        }

        private double _num2 = double.MinValue;
        public double Num2
        {
            get => _num2;
            set => _num2 = value;
        }

        public string Calculate()
        {
            string operation = Op;
            string result = "";

            switch (operation)
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
                    result = $"Invalid operation: {operation}";
                    break;
            }

            return result;
        }

        public void Reset()
        {
            Op = string.Empty;
            Num1 = double.MinValue;
            Num2 = double.MinValue;
        }

        public bool Ready()
        {
            return (Op != string.Empty && Num1 != double.MinValue && Num2 != double.MinValue);
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

    public class CalculatorController
    {
        public CalculatorController()
        {
            Menu();

            while (Calculate)
            {
                string[] prompts = { "First number", "Operator", "Second number" };

                foreach (string prompt in prompts)
                {
                    var input = "";

                    while (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine();
                        Console.Write($"{prompt}: ");
                        input = Console.ReadLine();
                    }

                    if (prompt == "First number" && IsNumber(input))
                    {
                        Calc.Num1 = double.Parse(input);
                    }

                    else if (prompt == "Second number" && IsNumber(input))
                    {
                        Calc.Num2 = double.Parse(input);
                    }

                    else if (prompt == "Operator" && IsOperator(input))
                    {
                        Calc.Op = input;
                    }

                    else
                    {
                        ChooseOption(input);
                        Calc.Reset();
                        break;
                    }

                }

                if (Calc.Ready())
                {
                    string result = Calc.Calculate();

                    Console.WriteLine();
                    Console.WriteLine(result);

                    Calc.Reset();
                }
            }
        }

        private Calculator _calc = new();
        private Calculator Calc
        {
            get => _calc;
        }

        private bool _calculate = true;
        private bool Calculate
        {
            get => _calculate;
            set => _calculate = value;
        }

        private void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("*-*-*-*-*-*- Welcome to Calculator -*-*-*-*-*-*");
            Console.WriteLine("When prompted, enter two numbers and an operator to calculate the result.");
            Options();
        }

        private void Options()
        {
            Console.WriteLine();
            Console.WriteLine("- - - Options- - -");
            Console.WriteLine("'h' = help");
            Console.WriteLine("'o' = options");
            Console.WriteLine("'op' = available operators");
            Console.WriteLine("'q' = quit");
        }

        private void Operators()
        {
            Console.WriteLine();
            Console.WriteLine("- - - Possible operations - - -");

            foreach (var op in Calc.Operators)
            {
                Console.WriteLine($"'{op.Value}' = {op.Key}");
            }
        }

        private void ChooseOption(string choice)
        {
            switch (choice.ToLower())
            {
                case "h":
                    Menu();
                    break;
                case "o":
                    Options();
                    break;
                case "op":
                    Operators();
                    break;
                case "q":
                    Calculate = false;
                    Console.WriteLine();
                    Console.WriteLine("Program ended. Bye!");
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid input!");
                    break;
            }
        }

        private bool IsNumber(string input)
        {   
            return double.TryParse(input, out _);
        }

        private bool IsOperator(string input)
        {
            return Calc.Operators.ContainsValue(input);
        }
    }
}