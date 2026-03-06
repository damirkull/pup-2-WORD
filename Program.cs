using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

namespace ConsoleApp12
{
    internal class Program
    {
        static string operations = "+-*/^";
        static string prioritet = "11223";
        

        static void Main(string[] args)
        {
            //string s = "{}()[]";
            //Console.WriteLine(IsBalanceBrackets(s));
            //Console.WriteLine(Calculate("23+7*481/+-"));
            //string s = "2+9*(1-6/(2+3)+(5-8))";
            
            Console.WriteLine(21 + 91 * (11 - 6123 / (12 + 38) + (5465 - 821)));
            string s = "21+91*(11-6123/(12+38)+(5465-821))";
            Console.WriteLine(s);

            Queue<string> express = GetBackExpression(s);
            PrintQueue(express);
            Console.WriteLine();
            Console.WriteLine(Calculate(express));
        }

        static Queue<string> GetElementsOfExpression(string expression)
        {
            Queue<string> elementsOfExpression = new Queue<string>();
            string newNum = "";
            foreach (char item in expression)
            {
                if (char.IsDigit(item)) newNum += item;
                else
                {
                    if (newNum != "") 
                    {
                        elementsOfExpression.Enqueue(newNum);
                        newNum = "";
                    }
                    elementsOfExpression.Enqueue(item.ToString());
                }
            }
            elementsOfExpression.Enqueue(newNum);
            return elementsOfExpression;
        }

        static bool IsBalanceBrackets(string s)
        {
            string openBrackets = "({[<";
            string closeBrackets = ")}]>";
            Stack<char> stack = new Stack<char>();
            foreach (char b in s)
            {
                if (openBrackets.IndexOf(b) != -1) 
                    stack.Push(b);
                else
                {
                    if (stack.Count == 0)
                        return false;
                    char topStack = stack.Pop();
                    if (openBrackets.IndexOf(topStack) != closeBrackets.IndexOf(b)) 
                        return false;                    
                }
            }
            return stack.Count == 0;
        }

        static int Calculate(Queue<string> expression)
        {
            Stack<int> stack = new Stack<int>();
            foreach (string item in expression)
            {
                if (IsOperation(item[0]))
                {
                    int op1 = stack.Pop();
                    int op2 = stack.Pop();
                    switch (item[0])
                    {
                        case '+': stack.Push(op1 + op2); break;
                        case '-': stack.Push(op2 - op1); break;
                        case '*': stack.Push(op1 * op2); break;
                        case '/': stack.Push(op2 / op1); break;
                    }
                }
                else
                    stack.Push(Convert.ToInt32(item));
            }
            return stack.Pop();
        }

        static int getPrioritet(char c)
        {
            int index = operations.IndexOf(c);
            if ( index >= 0) return prioritet[index];
            return -1;
        }

        static bool IsOperation(char c)
        {
            return operations.IndexOf(c) >= 0;
        }

        static void GetAllFromStackToStartBack(Stack<char> stack, Queue<string> queue)
        {
            while(stack.Count > 0)
            {
                var item = stack.Pop();
                if (item == '(') return;
                queue.Enqueue(item.ToString());
            }
        }

        static void PrintQueue(Queue<string> queue)
        {
            foreach (string item in queue) Console.Write(item);
        }

        static Queue<string> GetBackExpression(string expreession)
        {
            Queue<string> queueElements = GetElementsOfExpression(expreession);
            Queue<string> queueBackExpression = new Queue<string>();
            Stack<char> stackOperations = new Stack<char>();
            foreach (var item in queueElements)
            {
                if (item == "(") stackOperations.Push(item[0]);
                else if (item == ")")
                {
                    GetAllFromStackToStartBack(stackOperations, queueBackExpression);
                }
                else if (IsOperation(item[0]))
                {
                    while (stackOperations.Count > 0)
                    {
                        if (getPrioritet(stackOperations.Peek()) >= getPrioritet(item[0]))
                        {
                            queueBackExpression.Enqueue(stackOperations.Pop().ToString());
                        }
                        else break;
                    }
                    stackOperations.Push(item[0]);
                }
                else
                    queueBackExpression.Enqueue(item);
            }
            while (stackOperations.Count > 0)
            {
                queueBackExpression.Enqueue(stackOperations.Pop().ToString());
            }
            return queueBackExpression;
        }
    }
}
