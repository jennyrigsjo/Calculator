using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
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
            return double.TryParse(input, out double _);
        }

        private bool IsOperator(string input)
        {
            return Calc.Operators.ContainsValue(input);
        }
    }
}
