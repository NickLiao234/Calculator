using Caculator;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 計算機服務實體
        /// </summary>
        private CalculateService calculateService;

        /// <summary>
        /// 字串對應委派方法表
        /// </summary>
        private Dictionary<string, Delegate> MapMethod;

        /// <summary>
        /// 應用程式初始化
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            calculateService = (CalculateService)this.DataContext;
            MapMethod = new Dictionary<string, Delegate>();
            InitMapMethod();
        }

        /// <summary>
        /// 初始化對應表
        /// </summary>
        private void InitMapMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                MapMethod.Add(
                    i.ToString(),
                    new Action<string>(param =>
                        calculateService.Execute(
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
                        calculateService.Execute(
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
                    _ => calculateService.ExcuteOperator(
                         new Action<string>(
                             _ => calculateService.Add()
                         ),
                         OperatorEnum.Add
                    )
                )
            );
            MapMethod.Add(
                "-",
                new Action<string>(
                    _ => calculateService.ExcuteOperator(
                         new Action<string>(
                             _ => calculateService.Sub()
                         ),
                         OperatorEnum.Sub
                    )
                )
            );
            MapMethod.Add(
                "*",
                new Action<string>(
                    _ => calculateService.ExcuteOperator(
                         new Action<string>(
                             _ => calculateService.Multiple()
                         ),
                         OperatorEnum.Multiple
                    )
                )
            );
            MapMethod.Add(
                "/",
                new Action<string>(
                    _ => calculateService.ExcuteOperator(
                         new Action<string>(
                             _ => calculateService.Divide()
                         ),
                         OperatorEnum.Divide
                    )
                )
            );
            MapMethod.Add(
                "C",
                new Action<string>(
                    _ => calculateService.Execute(
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
                    _ => calculateService.Execute(
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
                    _ => calculateService.Execute(
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
                    _ => calculateService.Execute(
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
                    _ => calculateService.Execute(
                         new Action<string>(
                             _ => calculateService.Reverse()
                         ),
                         null
                    )
                )
            );
        }

        /// <summary>
        /// 所有button事件
        /// </summary>
        /// <param name="sender">按鈕</param>
        /// <param name="e">參數</param>
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var contentString = button.Content.ToString();
            MapMethod[contentString].DynamicInvoke(contentString);
        }
    }
}
