using Calculator;
using System.ComponentModel.Design;
using System.Globalization;
using System.Runtime.CompilerServices;


ArrayList Tokenize(string input)
{
    ArrayList buffer = new ArrayList();
    ArrayList tokens = new ArrayList();
    char[] operators = ['+', '-', '*', '/', '(', ')', '^'];
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
    }
    if (buffer.Count() != 0)
    { 
        string token = "";
        EmptyBuffer(token);
    }
    return tokens;
}
int GetPriority(string op)
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

string[] ShuntingYard(ArrayList tokenized) 
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

int Calculate(string[] equation) 
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
                    stack.Push((num2-num1).ToString());
                    break;
                case "*":
                    stack.Push((num1 * num2).ToString()); 
                    break;
                case "/":
                    stack.Push((num2/num1).ToString());
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
void CalculateAndDisplay() {
    string input = Console.ReadLine();
    var tokenized = Tokenize(input);
    var sorted = ShuntingYard(tokenized);
    foreach (var e in sorted) Console.Write(e + " ");
    Console.WriteLine($"\n{Calculate(sorted)}");
}

CalculateAndDisplay();











