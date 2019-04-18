using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    public abstract class OperatingSystem
    {
        protected List<ComputerProgram> programs = new List<ComputerProgram>();
        public abstract void Add(ComputerProgram cp);
        public abstract void StartAll();
        public abstract void CloseAll();
        public void UseTasks()
        {
            Console.WriteLine("Running tasks:");
            foreach (var a in programs.Where(x => x.Working)) {
                a.Use();
            }
        }
    }

    public class Windows : OperatingSystem
    {
        public int errorTimes;
        int counter = 0;
        public Windows(int err)
        {
            this.errorTimes = err;
        }
        public override void Add(ComputerProgram cp)
        {
            programs.Add(cp);
            counter++;
            if (counter == 5)
            {
                cp.Start();
                counter = 0;
            }
        }
        public override void CloseAll()
        {
            int c = 0;
            foreach(var elem in programs)
            {
                if(c==5)
                {
                    c = 0;
                    continue;
                }
                elem.Close();
                c++;
            }
        }
        public override void StartAll()
        {
            int c = 0;
            foreach (var elem in programs)
            {
                if (c == 5)
                {
                    c = 0;
                    continue;
                }
                elem.Start();
                c++;
            }
        }
    }

    public class Linux : OperatingSystem
    {
        public override void Add(ComputerProgram cp)
        {
            programs.Add(cp);
        }
        public override void CloseAll()
        {
            foreach (var elem in programs)
            {
                elem.Close();
            }
        }
        public override void StartAll()
        {
            foreach (var elem in programs)
            {
                elem.Start();
            }
        }
    }

    public abstract class CreateSystem
    {
        public abstract OperatingSystem Create();
    }

    public class CreateLinux : CreateSystem
    {
        public override OperatingSystem Create()
        {
            return new Linux();
        }
    }

    public class CreateWindows : CreateSystem
    {
        int errorTimes;
        public CreateWindows(int errorTimes)
        {
            this.errorTimes = errorTimes;
        }
        public override OperatingSystem Create()
        {
            return new Windows(errorTimes);
        }            
    }

}
