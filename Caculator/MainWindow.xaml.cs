﻿using Caculator;
using Caculator.Objects;
using Caculator.Services;
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
        private CalculatorViewModel calculateViewmodel;

        /// <summary>
        /// 加法服務
        /// </summary>
        private readonly IAddService addService;

        /// <summary>
        /// 減法服務
        /// </summary>
        private readonly ISubService subService;

        /// <summary>
        /// 乘法服務
        /// </summary>
        private readonly IMultipleService multipleService;

        /// <summary>
        /// 除法服務
        /// </summary>
        private readonly IDivideService divideService;

        /// <summary>
        /// 倒退服務
        /// </summary>
        private readonly IBackService backService;

        /// <summary>
        /// 清除目前運算子服務
        /// </summary>
        private readonly IClearCurrentService clearCurrentService;

        /// <summary>
        /// 清除運算式服務
        /// </summary>
        private readonly IClearService clearService;

        /// <summary>
        /// 修改正負號服務
        /// </summary>
        private readonly IReverseService reverseService;

        /// <summary>
        /// 加入字元服務
        /// </summary>
        private readonly IAppendNumberService appendNumberService;

        /// <summary>
        /// 字串對應委派方法表
        /// </summary>
        private Dictionary<string, ButtonBase> MapMethod;

        /// <summary>
        /// 應用程式初始化
        /// </summary>
        /// <param name="calculateViewmodel">viewmodel</param>
        /// <param name="addService">加法服務</param>
        /// <param name="subService">減法服務</param>
        /// <param name="multipleService">乘法服務</param>
        /// <param name="divideService">除法服務</param>
        /// <param name="backService">倒退服務</param>
        /// <param name="clearCurrentService">清除目前運算子服務</param>
        /// <param name="clearService">清除所有運算服務</param>
        /// <param name="reverseService">修改正負號服務</param>
        /// <param name="appendNumberService">加入字元服務</param>
        public MainWindow(
            CalculatorViewModel calculateViewmodel,
            IAddService addService,
            ISubService subService,
            IMultipleService multipleService,
            IDivideService divideService,
            IBackService backService,
            IClearCurrentService clearCurrentService,
            IClearService clearService,
            IReverseService reverseService,
            IAppendNumberService appendNumberService)
        {
            this.calculateViewmodel = calculateViewmodel;
            this.addService = addService;
            this.subService = subService;
            this.multipleService = multipleService;
            this.divideService = divideService;
            this.backService = backService;
            this.clearCurrentService = clearCurrentService;
            this.clearService = clearService;
            this.reverseService = reverseService;
            this.appendNumberService = appendNumberService;
            InitializeComponent();

            DataContext = calculateViewmodel;
            MapMethod = new Dictionary<string, ButtonBase>();
            InitMapMethod();
        }

        /// <summary>
        /// 初始化對應表
        /// </summary>
        private void InitMapMethod()
        {
            MapMethod.Add("0", new ButtonZero(appendNumberService));
            MapMethod.Add("1", new ButtonOne(appendNumberService));
            MapMethod.Add("2", new ButtonTwo(appendNumberService));
            MapMethod.Add("3", new ButtonThree(appendNumberService));
            MapMethod.Add("4", new ButtonFour(appendNumberService));
            MapMethod.Add("5", new ButtonFive(appendNumberService));
            MapMethod.Add("6", new ButtonSix(appendNumberService));
            MapMethod.Add("7", new ButtonSeven(appendNumberService));
            MapMethod.Add("8", new ButtonEight(appendNumberService));
            MapMethod.Add("9", new ButtonNine(appendNumberService));
            MapMethod.Add(".", new ButtonDot(appendNumberService));
            MapMethod.Add("+-", new ButtonReverse(reverseService));
            MapMethod.Add("C", new ButtonClear(clearService));
            MapMethod.Add("CE", new ButtonClearCurrent(clearCurrentService));
            MapMethod.Add("Back", new ButtonBack(backService));
            MapMethod.Add("+", new ButtonAdd(addService));
            MapMethod.Add("-", new ButtonSub(subService));
            MapMethod.Add("*", new ButtonMultiple(multipleService));
            MapMethod.Add("/", new ButtonDivide(divideService));
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
            MapMethod[contentString].Excute();
        }
    }
}
