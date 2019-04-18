using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    public abstract class ComputerProgram
    {
        protected string fileName;
        protected bool working;
        public bool Working
        {
            get { return working; }
        }
        public ComputerProgram(string fileName)
        {
            this.fileName = fileName;
            working = false;
        }
        public abstract void Start();
        public abstract void Use();
        public abstract void Close();
    }

    public class Painter : ComputerProgram
    {
        public int size;
        public int def;
        public Painter(string fileName, int size, int def) : base(fileName)
        {
            this.size = size;
            this.def = def;
        }
        public override void Close()
        {
            Console.WriteLine("Last size of canvas was: " + size);
            working = false;
            size = def;
        }
        public override void Start()
        {
            if (Working == true) Console.WriteLine(fileName + " is already working.");
            else
            {
                working = true;
                Console.WriteLine(fileName + " started.");
            }
        }
        public override void Use()
        {
            if(Working==true)
            {
                Console.WriteLine(fileName + " is doubling the picture size");
                size *= 2;
            }
            else Console.WriteLine("Please start " + fileName + " first.");
        }
    }

    public class Browser : ComputerProgram
    {
        public int max;
        public int curr;
        public Browser(string fileName, int max) : base(fileName)
        {
            this.max = max;
        }
        public override void Close()
        {
            if (curr < 2)
            {
                curr = 0;
                working = false;
                Console.WriteLine("Closed all tabs.");
                return;
            }
            curr -= 2;
            Console.WriteLine("Closed two last tabs");
            if (curr == 0) working = false;
        }
        public override void Start()
        {
            Use();
        }
        public override void Use()
        {
            curr++;
            Console.WriteLine("Current no. of tabs: " + curr);
            if (curr == max) Close();
        }
    }

    public abstract class CreateProgram
    {
        public abstract ComputerProgram Create(string name);
    }

    public class CreatePainter : CreateProgram
    {
        int size;
        int def;
        public CreatePainter(int size, int def)
        {
            this.size = size;
            this.def = def;
        }
        public override ComputerProgram Create(string name)
        {
            return new Painter(name, size, def);
        }
    }

    public class CreateBrowser : CreateProgram
    {
        int max;
        public CreateBrowser(int max)
        {
            this.max = max;
        }
        public override ComputerProgram Create(string name)
        {
            return new Browser(name, max);
        }
    }

}
