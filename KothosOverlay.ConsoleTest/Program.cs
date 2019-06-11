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
                for (int i = 1000; i < 10000; i++)
                {
                    kothosMainACT.UpdatePlayerData("Raziel Jone", 5086.85 + i,      "16%", "33.2%", "34.1%", "13.2%");
                    kothosMainACT.UpdatePlayerData("Lucifer Morningstar", 4961 + i, "15%", "14.2%", "34.1%", "13.2%");
                    kothosMainACT.UpdatePlayerData("Matt Ishida", 4713.85 + i,      "15%", "33.2%", "34.1%", "13.2%");
                    kothosMainACT.UpdatePlayerData("Lulu Mizuki", 4395.85 + i,      "14%", "33.2%", "34.1%", "13.2%");
                    kothosMainACT.UpdatePlayerData("YOU", 3875.85 + i,              "12%", "33.2%", "34.1%", "13.2%");
                    kothosMainACT.UpdatePlayerData("Alkeid Yashiro", 3850.85 + i,   "12%", "33.2%", "34.1%", "13.2%");
                    kothosMainACT.UpdatePlayerData("Leon Lanceloth", 2167.85 + i,   "6%",  "33.2%", "34.1%", "13.2%");
                    kothosMainACT.UpdatePlayerData("Aeria Moon", 1978.85 + i,       "6%",  "33.2%", "34.1%", "13.2%");

                    Thread.Sleep(100);
                }

                
            }



            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

    }
}
