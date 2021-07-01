using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RpnCalculator.Classes
{
    public static class StringExtension
    {
        public static bool IsNumber(this string str)
        {
            if(int.TryParse(str, out _))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsOperator(this string str)
        {
            if(str == "+" ||
                str == "-" ||
                str == "*" ||
                str == "/")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int ToNumber(this string str)
        {
            return Convert.ToInt32(str);
        }
    }

    public static class Calculator
    {
        public static void Execute()
        {
            string inputExpr;

            inputExpr = Local.window.TbInput.Text;
            Local.stack = new Stack<string>(inputExpr.Split(' '));

            if (!Local.stack.Peek().IsOperator())
            {
                MessageBox.Show("Enter valid RPN expression!");
                return;
            }

            Local.window.TbOutput.Text = CalculateRpn(Local.stack).ToString();
        }

        public static int CalculateRpn(Stack<string> stack)
        {
            int n1,
                n2;
            string s3;

            if (stack.Peek().IsNumber())
            {
                return stack.Pop().ToNumber();
            }

            switch (stack.Pop())
            {
                case "+":
                    n2 = CalculateRpn(stack);
                    n1 = CalculateRpn(stack);
                    s3 = (n1 + n2).ToString();
                    
                    stack.Push(s3);
                    break;

                case "-":
                    n2 = CalculateRpn(stack);
                    n1 = CalculateRpn(stack);
                    s3 = (n1 - n2).ToString();

                    stack.Push(s3);
                    break;

                case "*":
                    n2 = CalculateRpn(stack);
                    n1 = CalculateRpn(stack);
                    s3 = (n1 * n2).ToString();

                    stack.Push(s3);
                    break;

                case "/":
                    n2 = CalculateRpn(stack);
                    n1 = CalculateRpn(stack);
                    s3 = (n1 / n2).ToString();

                    stack.Push(s3);
                    break;
            }
            return stack.Pop().ToNumber();
        }
    }
}
