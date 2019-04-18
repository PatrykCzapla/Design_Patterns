using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            IStream stream = new StringStream("Faculty of Mathematics and Information Science, Warsaw University of Technology");
            IStream another = new StringStream(" is the best place to learn about Decorators. Period.");

            //stream = new ToSmallDecorator(stream);
            //stream = new ToGreaterDecorator(stream);
            //stream = new SpaceDecorator(stream);
            //stream = new ConcatenateDecorator(stream, another);
            //stream = new ConcatenateAndFirstToSmallDecorator(stream, another);
            //stream = new DeleteVowelsDecorator(stream);
            //stream = new AfterDotGreaterDecorator(stream);
            //stream = new CipherDecorator(stream,3);
            //stream = new GreaterLowerDecorator(stream);
            //stream = new OnlyNFirstCharsDecorator(stream, 5);
            //stream = new SkipNDecorator(stream, 5);

            while (!stream.AtEnd())
            {
                Console.Write(stream.ReadNext());
            }
            Console.WriteLine();
        }
    }
}
