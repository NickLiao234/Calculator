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

namespace Caculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CalculateService calculateService;
        private Dictionary<string, Delegate> MapMethod; 
        public MainWindow()
        {
            InitializeComponent();

            string a = "1.";
            var b = Convert.ToDouble(a);
            var c = 0 - b;
            var d = c.ToString();

            calculateService = new CalculateService();
            MapMethod = new Dictionary<string, Delegate>();
            for (int i = 0; i < 10; i++)
            {
                MapMethod.Add(i.ToString(), new Action<string>(param => calculateService.AppendNumber(param)));
            }
            MapMethod.Add("+", new Action<string>(c => calculateService.Add()));
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            var o = (Button)sender;
            var a = o.Content.ToString();
            MapMethod[a].DynamicInvoke(a);
        }

    }
}
