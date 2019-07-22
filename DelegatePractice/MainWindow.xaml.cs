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
        {
            new MainThingProcessor().DoProcesses();
        }


        public static class ProcessesWeMightExtend
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
        public class MainThingProcessor
        {
            MainThing _mainThing = new MainThing();

     
            public void DoProcesses()
            {
                ProcessesWeMightExtend.DoProcessA(_mainThing);
                ProcessesWeMightExtend.DoProcessB(_mainThing);

            }
        }

        public class MainThing
        {
            public int Size { get; set; }

            


        }
    }
}
