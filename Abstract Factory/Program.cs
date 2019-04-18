using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    class Program
    {
        static OperatingSystem CreateOS(IEnumerable<string> procesNames, CreateProgram prog_creator, CreateSystem sys_creator)
        {
            OperatingSystem os = sys_creator.Create();
            foreach (string name in procesNames)
            {
                ComputerProgram program = prog_creator.Create(name);
                os.Add(program);
            }
            return os;
        }

        static void Main(string[] args)
        {
            CreateWindows Windows = new CreateWindows(3);
            CreatePainter Painter = new CreatePainter(1, 10);
            OperatingSystem system1 = CreateOS(new List<string> { "Alpha", "Beta", "Gamma", "Delta", "Sigma", "Tau", "Zeta" }, Painter, Windows);
            system1.StartAll();
            system1.StartAll();
            system1.UseTasks();
            system1.UseTasks();
            system1.CloseAll();
            system1.CloseAll();
            Console.WriteLine("Koniec działania system1.");
            Console.WriteLine();

            CreateLinux Linux = new CreateLinux();
            CreateBrowser Browser = new CreateBrowser(5);
            OperatingSystem system2 = CreateOS(new List<string> { "Alpha", "Beta", "Gamma", "Delta", "Sigma", "Tau", "Zeta" }, Browser, Linux);
            system2.StartAll();
            system2.StartAll();
            system2.UseTasks();
            system2.UseTasks();
            system2.CloseAll();
            system2.CloseAll();
            Console.WriteLine("Koniec działania system2.");
        }
    }
}
