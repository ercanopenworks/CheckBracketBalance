using System;
using System.Collections.Generic;

namespace CheckBalanceApp
{
    class Program
    {

        static int pairCount = 0;

        public static char[,] bracketPairs = new char[,]
        {
                {'{', '}' },
                {'[', ']' },
                {'(', ')'}

                //for example;
                //{'<', '>' } 
                //{'$', '€' }

                //by this way we can easily expand our solution without change in our methods..
                //This is called the Open-Closed Principle...

        };


        private static bool matches(char openTerm, char closeTerm)
        {
            for (int i = 0; i <= bracketPairs.Rank; i++)
            {
                if (bracketPairs[i, 0] == openTerm)
                {
                    var res = bracketPairs[i, 1] == closeTerm;

                    pairCount++;

                    return res;
                }
            }
            return false;
        }

        private static bool isOpenTerms(char item)
        {
            for (int i = 0; i <= bracketPairs.Rank; i++)
            {
                if (bracketPairs[i, 0] == item)
                {
                    return true;
                }
            }
            return false;
        }

        public static string CheckBalance(string expression)
        {
            Stack<char> myStack = new Stack<char>();

            foreach (char item in expression.ToCharArray())
            {
                if (char.IsLetter(item))
                    continue;

                if (isOpenTerms(item))
                {
                    myStack.Push(item);
                }
                else
                {
                    if ((myStack.Count == 0) || !matches(myStack.Pop(), item))
                    {
                        return "UnexpectedBracketClosing"; 
                    }
                }
            }
            if (myStack.Count == 0)
            {
                return pairCount.ToString();
            }
            else
                return "ExpectedClosingBracket"; 
        }
        static void Main(string[] args)
        {
            //This was the old version...

            //char[] input = ("be(gin").ToCharArray();
            //string result = checkBalance(input);


            //This is the new version...v1.0
            //This solution is a proper version according to 2 items of the S.O.L.I.D principles. S->Single responsibility and O->Open-Closed principle

            string checkString = "begin(wo(dog)od)middle(ste(ca(bridge)t)el)end{}[]";
            //string checkString = "be)(gin";
            //string checkString = "be(gin";

            string res = CheckBalance(checkString);

            Console.WriteLine(res);

        }


        //This was the old version v0.1
        //This was deprecated..

        //static string checkBalance(char[] input)
        //{
        //    int pairCount = 0;

        //    Stack<char> myStack = new Stack<char>();
        //    for (int i = 0; i < input.Length - 1; i++)
        //    {

        //        if (input[i] == '(')
        //            myStack.Push(input[i]);
        //        else if (input[i] == ')')
        //        {
        //            if (myStack.Count == 0)
        //            {
        //                return "UnexpectedBracketClosing";
        //            }
        //            else
        //            {
        //                myStack.Pop();
        //                pairCount++;
        //            }
        //        }

        //    }
        //    if (myStack.Count == 0)
        //    {
        //        //Console.WriteLine(pairCount);
        //        return pairCount.ToString();

        //    }
        //    else if (myStack.Count > 0)
        //    {
        //        //Console.WriteLine("ExpectedClosingBracket");
        //        return "ExpectedClosingBracket";
        //    }
        //}
    }
}
