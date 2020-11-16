using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace _01_Collections.Samples.Generic
{
    public class StackSample
    {
        public static void StackTest()
        {

            Stack<string> stack = new Stack<string>();
            stack.Push("User1");
            stack.Push("User2");
            stack.Push("User3");

            stack.PrintCollection("stack");

            var result = stack.Pop();
            Debug.WriteLine(result, "Pop - result");
            stack.PrintCollection("stack after pop");


            result = stack.Peek();
            Debug.WriteLine(result, "Peek - result");
            stack.PrintCollection("stack after peek");
        }
    }
}
