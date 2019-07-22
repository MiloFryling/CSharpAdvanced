using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DelegatePractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        // 3 parts: the object, the object manager, and the class(es) of functions that might be called by the manager to operate on the object
        // instead of the manager being hard-coded, it can receive delegates.  That way new operation functions require no changes to the manager or the object.
        {
            Console.WriteLine("Invoking the old way");
            new MainThingProcessor().DoProcesses();

            Console.WriteLine("Invoking the new way");
            //var processes = new MainThingProcessor.ProcessHandler();

            new MainThingProcessor().DoProcesses(OriginalProcesses.DoProcessB);
            new MainThingProcessor().DoProcesses(OriginalProcesses.DoProcessA);
            new MainThingProcessor().DoProcesses(NewProcesses.DoProcessH);

        }


        public static class OriginalProcesses
        {
            public static void DoProcessA(MainThing mainThing)
            {
                Console.WriteLine("DoProcessA");
            }
            public static void DoProcessB(MainThing mainThing)
            {
                Console.WriteLine("DoProcessB");
            }

        }

        //added after first version.  Needs delegate so that this wouldn't require changes in the Processor
        public static class NewProcesses
        {
            public static void DoProcessH(MainThing mainThing)
            {
                Console.WriteLine("PROCESS H!");
            }
        }
        public class MainThingProcessor
        {
            MainThing _mainThing = new MainThing();

            public delegate void ProcessHandler(MainThing mainThing);


            //Old way, without delegate
            public void DoProcesses()
            {
                OriginalProcesses.DoProcessA(_mainThing);
                OriginalProcesses.DoProcessB(_mainThing);
            }

            public void DoProcesses(ProcessHandler processHandler)
            {
                processHandler(_mainThing);
            }




        }

        public class MainThing
        {
            public int Size { get; set; }

            


        }
    }
}
