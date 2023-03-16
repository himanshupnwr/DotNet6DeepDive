using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEnhancements
{
    //C# 10 adds support for a custom interpolated string handler
    //An interpolated string is a type that processes the placeholder expression in the interpolated string
    //The interploated string expression is handed off to a type that knows about how to build a string in an efficient manner

    internal class StringInterpolation
    {
        int dice1 = 1;
        int dice2 = 2;

        void DemoString()
        {
            var message = $"Duce results: {dice1} and {dice2} Total: {dice1 + dice2}";
            var builder = new StringBuilder();
            builder.AppendLine("Dice results");
            builder.AppendLine($"{dice1} and {dice2}");
            builder.AppendLine($"Total = {dice1 + dice2}");
        }

        //C# 10 is using a default Interpolated string handler which helps in not doing boxing and unboxing the int
        //to string and saves performance. Check the IL code to see how the compiler is doing the interpolation

        //String builder is also using AppendInterpolatedStringHandler 
    }
}
