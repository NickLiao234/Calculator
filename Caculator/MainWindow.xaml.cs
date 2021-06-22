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
        private Delegate tempDelegate; 
        public MainWindow()
        {
            InitializeComponent();

            calculateService = new CalculateService();
            MapMethod = new Dictionary<string, Delegate>();
            for (int i = 0; i < 10; i++)
            {
                MapMethod.Add(i.ToString(), new Action<string>(param => calculateService.AppendNumber(param)));
            }
            MapMethod.Add("+", new Action<string>(_ => calculateService.Add()));
            MapMethod.Add("-", new Action<string>(_ => calculateService.Sub()));
            MapMethod.Add("*", new Action<string>(_ => calculateService.Multiple()));
            MapMethod.Add("/", new Action<string>(_ => calculateService.Divide()));
            MapMethod.Add("C", new Action<string>(_ => calculateService.Clear()));
            MapMethod.Add("CE", new Action<string>(_ => calculateService.ClearCurrent()));
            MapMethod.Add("Back", new Action<string>(_ => calculateService.Back()));
            MapMethod.Add("+-", new Action<string>(_ => calculateService.Reverse()));
            MapMethod.Add(".", new Action<string>(param => calculateService.AppendNumber(param)));

            tempDelegate = new Action<string>(_ => calculateService.Add());
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            var o = (Button)sender;
            var a = o.Content.ToString();
            MapMethod[a].DynamicInvoke(a);
        }

    }
}
