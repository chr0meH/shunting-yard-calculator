using CalculatorAlgorithm;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorAlgorithm
{
    public class Calculator
    {
        static string[][] _variables = new string[10][];

        static int _varCount = 0;

        static ArrayList<string> Tokenize(string input)
        {
            ArrayList<string> buffer = new();
            ArrayList<string> tokens = new();
            char[] operators = ['+', '-', '*', '/', '(', ')', '^'];
            

            //Перевірка на існування змінної
            bool isVariable(string var)
            {
                for(int i = 0; i < _varCount; i++) { if (_variables[i][0] == var) return true; }
                throw new ArgumentException("Змінної не існує");
            }

            //Пошук значення змінної
            string FindValue(string varName) 
            {
                foreach(var variable in _variables) { if (variable[0] == varName) return variable[1]; }
                return "0";
            }
           
            //Функція що клеїть токен зі значень з буфера та його очищує
            void EmptyBuffer(string token)
            {
                if (buffer.Count() != 0)
                {
                    while (buffer.Count() != 0)
                    {
                        token += buffer.GetAt(0);
                        buffer.Remove(buffer.GetAt(0));
                    }
                    tokens.Add(token);
                }
            }

            // Обробка змінних
            if (input.Contains('=') && char.IsLetter(input[0]))
            {
                if (_varCount == 10) { throw new ArgumentException("Закінчилось місце для змінних"); }
                input = input.Replace(" ", "");
                string varName = input.Split('=')[0];
                string varValue = input.Split('=')[1];
                _variables[_varCount] = new string[2];
                _variables[_varCount][0] = varName;
                _variables[_varCount][1] = FullCalculate(varValue).ToString();
                _varCount++;
                tokens.Add(_variables[_varCount - 1][1]);
                return tokens;
            }
            //Основна логіка токенізації
            foreach (char c in input)
            {
                string token = "";
                if (char.IsDigit(c)) buffer.Add(c.ToString());
                else if (char.IsWhiteSpace(c)) EmptyBuffer(token);
                else if (operators.Contains(c))
                {
                    EmptyBuffer(token);
                    tokens.Add(c.ToString());
                }
                else if (isVariable(c.ToString())) tokens.Add(FindValue(c.ToString()));
            }
            if (buffer.Count() != 0)
            {
                string token = "";
                EmptyBuffer(token);
            }
            return tokens;
        }

        //Отримання пріорітету операції
        static int GetPriority(string op)
        {
            switch (op)
            {
                case "+":
                case "-":
                    return 1;

                case "*":
                case "/":
                    return 2;
                case "^":
                    return 3;

                default:
                    return 0;
            }
        }

        //Сортувальна станція
        static string[] ShuntingYard(ArrayList<string> tokenized)
        {
            string[] operations = ["+", "-", "*", "/", "^"];
            Queue output = new();
            Stack operators = new();
            for (int i = 0; i < tokenized.Count(); i++)
            {

                string token = tokenized.GetAt(i);
                if (char.IsDigit(token[0]))
                {
                    output.Enqueue(token);
                }
                else if (operations.Contains(token))
                {
                    while (operators.Peek() != null && operators.Peek() != "(" && ((token != "^") && (GetPriority(operators.Peek()) >= GetPriority(token))))
                    {
                        output.Enqueue(operators.Pop());
                    }
                    operators.Push(token);
                }
                else if (token == "(") operators.Push(token);
                else if (token == ")")
                {
                    while (operators.Peek() != "(" && operators.Peek() != null)
                    {
                        output.Enqueue(operators.Pop());
                    }
                    operators.Pop();
                }

            }
            while (operators.Peek() != null) output.Enqueue(operators.Pop());
            return output.ToArray();

        }

        //Розрахунок значення з польскої нотації
        static int Calculate(string[] equation)
        {
            Stack stack = new();
            foreach (string token in equation)
            {
                if (char.IsDigit(token[0])) stack.Push(token);
                else
                {
                    int num1 = int.Parse(stack.Pop());
                    int num2 = int.Parse(stack.Pop());
                    switch (token)
                    {
                        case "+":
                            stack.Push((num1 + num2).ToString());
                            break;
                        case "-":
                            stack.Push((num2 - num1).ToString());
                            break;
                        case "*":
                            stack.Push((num1 * num2).ToString());
                            break;
                        case "/":
                            stack.Push((num2 / num1).ToString());
                            break;
                        case "^":
                            stack.Push((Math.Pow(num2, num1)).ToString());
                            break;
                        default:
                            continue;
                    }

                }
            }
            return int.Parse(stack.Pop());
        }

        //Функція що повертає значення заданого виразу
        private static int FullCalculate(string input) 
        {
            var tokenized = Tokenize(input);
            var sorted = ShuntingYard(tokenized);
            return Calculate(sorted);
        }

        //Функція для взаємодії з користувачем
        public static void UserInterface()
        {
            Console.Write("Введіть вираз: ");
            string input = Console.ReadLine();
            try
            {
                Console.WriteLine(FullCalculate(input));
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            catch (Exception e) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Сталася невідома помилка");
                Console.ResetColor();
            }
        }


    }
}
