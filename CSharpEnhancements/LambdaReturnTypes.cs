using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEnhancements
{
    internal class LambdaReturnTypes
    {
        public void LambdaReturnTypesExample() {
            //previous way to write code
            Action<int,int> printMessage = (int x, int y) => { Console.WriteLine(x + y); };

            //new way to write
            var printMessage1 = (int x, int y) => { Console.WriteLine(x + y); };
            printMessage(3, 4);
            printMessage1(4, 5);

            var getTotal = (float x, float y) =>  x + y;

            //we can also specify the return type
            var getTotalInDouble = double (float x, float y) => x + y;

            Console.WriteLine(getTotal(12.1f, 14.2f));
        }
    }
}
