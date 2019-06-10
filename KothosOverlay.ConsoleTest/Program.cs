using System;
using System.Threading;
using System.Windows.Forms;

namespace KothosOverlay.ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            KothosMainACT kothosMainACT = new KothosMainACT();
            kothosMainACT.InitPlugin(new TabPage(), new System.Windows.Forms.Label());

            Thread.Sleep(1000);
            kothosMainACT.UpdateText("Test Model");

            while (true)
            {
                for (int i = 0; i < 1000; i++)
                {
                    kothosMainACT.UpdatePlayerData("Kothos", i);
                    Thread.Sleep(100);
                }

                
            }



            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

    }
}
