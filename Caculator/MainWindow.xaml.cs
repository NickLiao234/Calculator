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

            calculateService = (CalculateService)this.DataContext;
            MapMethod = new Dictionary<string, Delegate>();
            InitMapMethod();
        }

        private void InitMapMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                MapMethod.Add(
                    i.ToString(),
                    new Action<string>(param =>
                        calculateService.Excute(
                            new Action<string>(a =>
                                calculateService.AppendNumber(a)
                            ),
                            param
                        )
                    )
                );
            }
            MapMethod.Add(
                    ".",
                    new Action<string>(param =>
                        calculateService.Excute(
                            new Action<string>(a =>
                                calculateService.AppendNumber(a)
                            ),
                            param
                        )
                    )
                );
            MapMethod.Add(
                "+",
                new Action<string>(
                    _ => calculateService.ExcuteTemp(
                         new Action<string>(
                             _ => calculateService.Add()
                         )
                    )
                )
            );
            MapMethod.Add(
                "-",
                new Action<string>(
                    _ => calculateService.ExcuteTemp(
                         new Action<string>(
                             _ => calculateService.Sub()
                         )
                    )
                )
            );
            MapMethod.Add(
                "*",
                new Action<string>(
                    _ => calculateService.ExcuteTemp(
                         new Action<string>(
                             _ => calculateService.Multiple()
                         )
                    )
                )
            );
            MapMethod.Add(
                "/",
                new Action<string>(
                    _ => calculateService.ExcuteTemp(
                         new Action<string>(
                             _ => calculateService.Divide()
                         )
                    )
                )
            );
            MapMethod.Add(
                "C",
                new Action<string>(
                    _ => calculateService.Excute(
                         new Action<string>(
                             _ => calculateService.Clear()
                         ),
                         null
                    )
                )
            );
            MapMethod.Add(
                "CE",
                new Action<string>(
                    _ => calculateService.Excute(
                         new Action<string>(
                             _ => calculateService.ClearCurrent()
                         ),
                         null
                    )
                )
            );
            MapMethod.Add(
                "back",
                new Action<string>(
                    _ => calculateService.Excute(
                         new Action<string>(
                             _ => calculateService.Back()
                         ),
                         null
                    )
                )
            );
            MapMethod.Add(
                "=",
                new Action<string>(
                    _ => calculateService.Excute(
                         new Action<string>(
                             _ => calculateService.Equal()
                         ),
                         null
                    )
                )
            );
            MapMethod.Add(
                "+-",
                new Action<string>(
                    _ => calculateService.Excute(
                         new Action<string>(
                             _ => calculateService.Reverse()
                         ),
                         null
                    )
                )
            );
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var contentString = button.Content.ToString();
            MapMethod[contentString].DynamicInvoke(contentString);
        }

    }
}
