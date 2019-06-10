using Advanced_Combat_Tracker;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace KothosOverlay
{
    public class KothosMainACT : IActPluginV1
    {
        public KothosMainACT()
        {
        }

        public void DeInitPlugin()
        {

        }

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            pluginStatusText.Text = "Powered by Okothismo Magiks";
            if (ActGlobals.oFormActMain != null)
            {
                ActGlobals.oFormActMain.AfterCombatAction += OFormActMain_AfterCombatAction;

                ActGlobals.oFormActMain.OnCombatStart += OFormActMain_OnCombatStart;
                ActGlobals.oFormActMain.OnCombatEnd += OFormActMain_OnCombatEnd;
            }

            Thread newWindowThread = new Thread(new ThreadStart(ThreadStartingPoint));
            newWindowThread.SetApartmentState(ApartmentState.STA);
            newWindowThread.IsBackground = true;
            newWindowThread.Start();

            Thread combatDataThread = new Thread(new ThreadStart(CombatDataFetch))
            {
                IsBackground = true
            };
            combatDataThread.Start();

        }

        private void CombatDataFetch()
        {
            while (true)
            {
                if (ActGlobals.oFormActMain == null)
                {
                    continue;
                }

                if (ActGlobals.oFormActMain.ActiveZone == null)
                {
                    continue;
                }

                if (ActGlobals.oFormActMain.ActiveZone.ActiveEncounter == null)
                {
                    continue;
                }

                SortedList<string, CombatantData> items = ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.Items;

                foreach (KeyValuePair<string, CombatantData> item in items)
                {
                    UpdatePlayerData(item.Value.Name, item.Value.DPS);
                    string debugStr = item.Value.Name + " - " + item.Value.DPS + " - " + item.Value.EncDPS;
                    UpdateText(debugStr);
                }

                Thread.Sleep(500);
            }


        }

        private void OFormActMain_OnCombatEnd(bool isImport, CombatToggleEventArgs encounterInfo)
        {
            UpdateText("Combat End:" + encounterInfo.encounter.DurationS);
        }

        private void OFormActMain_OnCombatStart(bool isImport, CombatToggleEventArgs encounterInfo)
        {
            UpdateText("Combat Start");
        }

        private void OFormActMain_AfterCombatAction(bool isImport, CombatActionEventArgs actionInfo)
        {
            //UpdateText(actionInfo.ToString());
            //MainWindow.overlay.tbLog.Text += actionInfo.combatAction.ToString(); -- throw exception
            Debug.WriteLine(actionInfo.combatAction.ToString());
        }

        public MainWindow Main;
        public delegate void NextPrimeDelegate();

        private void ThreadStartingPoint()
        {
            System.Windows.Application application = new System.Windows.Application();
            Main = new MainWindow();

            Main.Closed += (sender2, e2) =>
                Main.Dispatcher.InvokeShutdown();

            application.Run(Main);


            //System.Windows.Threading.Dispatcher.Run();
        }

        public void UpdateText(string text)
        {

            Main.OverlayModel.MessageLog = text;
            //Main.Dispatcher.InvokeAsync(() => {
            //    Main.OverlayModel.MessageLog += text + "\n";
            //    //Main.overlay.tbLog.CaretIndex = Main.overlay.tbLog.Text.Length;
            //    //Main.overlay.tbLog.ScrollToEnd();
            //});
            //Main.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new NextPrimeDelegate(Test), "params");
        }

        public void UpdatePlayerData(string name, double dps)
        {
            Main.Dispatcher.InvokeAsync(() =>
            {
                PlayerModel pm = Main.OverlayModel.Players.Where(p => p.Name.Equals(name)).FirstOrDefault();
                if (pm == null)
                {
                    pm = new PlayerModel
                    {
                        Name = name
                    };
                    Main.OverlayModel.Players.Add(pm);
                }

                pm.DPS = dps;

            });
        }

        public void UpdateGrid(SortedList<string, CombatantData> list)
        {
            //Main.Dispatcher.InvokeAsync(() => {
            //    Main.overlay.dgCombatData.ItemsSource = list.Values;
            //    //CollectionViewSource.GetDefaultView(Main.overlay.dgCombatData).Refresh();

            //});
            //Main.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new NextPrimeDelegate(Test), "params");
        }

    }
}
