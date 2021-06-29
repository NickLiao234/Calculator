using Caculator.Objects;
using Caculator.Objects.Operators;
using Caculator.Services;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
        /// 修改ViewModel屬性服務
        /// </summary>
        private readonly IEditViewModelService editModelService;

        /// <summary>
        /// 表達式計算服務
        /// </summary>
        private readonly ICalculateExpressionService calculateExpressionService;

        /// <summary>
        /// 字串對應委派方法表
        /// </summary>
        private Dictionary<string, ButtonBase> MapMethod;

        /// <summary>
        /// 應用程式初始化
        /// </summary>
        /// <param name="calculateViewmodel">viewmodel</param>
        /// <param name="backService">倒退服務</param>
        /// <param name="clearCurrentService">清除目前運算子服務</param>
        /// <param name="clearService">清除所有運算服務</param>
        /// <param name="reverseService">修改正負號服務</param>
        /// <param name="appendNumberService">加入字元服務</param>
        /// <param name="editModelService">修改viewmodel屬性服務</param>
        /// <param name="calculateExpressionService">運算表達式服務</param>
        public MainWindow(
            CalculatorViewModel calculateViewmodel,
            IBackService backService,
            IClearCurrentService clearCurrentService,
            IClearService clearService,
            IReverseService reverseService,
            IAppendNumberService appendNumberService,
            IEditViewModelService editModelService,
            ICalculateExpressionService calculateExpressionService)
        {
            this.calculateViewmodel = calculateViewmodel;
            this.backService = backService;
            this.clearCurrentService = clearCurrentService;
            this.clearService = clearService;
            this.reverseService = reverseService;
            this.appendNumberService = appendNumberService;
            this.editModelService = editModelService;
            this.calculateExpressionService = calculateExpressionService;
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
            MapMethod.Add("0", new ButtonOperand("0", appendNumberService));
            MapMethod.Add("1", new ButtonOperand("1", appendNumberService));
            MapMethod.Add("2", new ButtonOperand("2", appendNumberService));
            MapMethod.Add("3", new ButtonOperand("3", appendNumberService));
            MapMethod.Add("4", new ButtonOperand("4", appendNumberService));
            MapMethod.Add("5", new ButtonOperand("5", appendNumberService));
            MapMethod.Add("6", new ButtonOperand("6", appendNumberService));
            MapMethod.Add("7", new ButtonOperand("7", appendNumberService));
            MapMethod.Add("8", new ButtonOperand("8", appendNumberService));
            MapMethod.Add("9", new ButtonOperand("9", appendNumberService));
            MapMethod.Add(".", new ButtonOperand(".", appendNumberService));
            MapMethod.Add("+-", new ButtonReverse(reverseService));
            MapMethod.Add("C", new ButtonClear(clearService));
            MapMethod.Add("CE", new ButtonClearCurrent(clearCurrentService));
            MapMethod.Add("back", new ButtonBack(backService));
            MapMethod.Add("=", new ButtonEqual(editModelService, calculateExpressionService, clearService));
            MapMethod.Add("+", new ButtonOperators("+", typeof(AddElement), editModelService, calculateExpressionService));
            MapMethod.Add("-", new ButtonOperators("-", typeof(SubElement), editModelService, calculateExpressionService));
            MapMethod.Add("*", new ButtonOperators("*", typeof(MultipleElement), editModelService, calculateExpressionService));
            MapMethod.Add("/", new ButtonOperators("/", typeof(DivideElement), editModelService, calculateExpressionService));
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
