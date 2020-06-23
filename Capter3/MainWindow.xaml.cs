using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Capter3
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {


        protected Random random = new Random();



        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DummyViewModel();

            this.AddHandler(UIElement.MouseDownEvent, new MouseButtonEventHandler(OnMouseRightButtonDownEvent), true);
        }


        protected void OnMouseRightButtonDownEvent(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine(sender);
        }




        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            Debug.WriteLine("=============================");
            e.Handled = true;
            base.OnMouseDown(e);
        }










        private void tbBlk_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine(random.Next(1, 10));
        }
    }




    public class DummyViewModel
    {

        protected Random random = new Random();
        byte[] rgb = new byte[3];



        private RelayCommand _mouseUpCommand;
        public RelayCommand MouseUpCommand
        {
            get
            {
                if (_mouseUpCommand == null) return _mouseUpCommand = new RelayCommand(param => ExecuteMouseMove((MouseEventArgs)param));
                return _mouseUpCommand;
            }
            set { _mouseUpCommand = value; }
        }

        private void ExecuteMouseMove(MouseEventArgs e)
        {
            Debug.WriteLine(e.OriginalSource);
            /*
            FrameworkElement ui = e.OriginalSource as FrameworkElement;

            random.NextBytes(rgb);
            Color color = Color.FromArgb(255, rgb[0], rgb[1], rgb[2]);
            ui.Foreground = new SolidColorBrush(color);
            */
            Console.WriteLine("Mouse Up : " + e.GetPosition((IInputElement)e.Source));
        }
    }








    public class RelayCommand : ICommand
    {
        #region Fields

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
        private string _displayText;

        public static List<string> Log = new List<string>();
        private Action<object> action;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
            : this(execute, canExecute, "")
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute, string displayText)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
            _displayText = displayText;
        }


        public string DisplayText
        {
            get { return _displayText; }
            set { _displayText = value; }
        }

        #endregion // Constructors

        #region ICommand Members

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {

            _execute(parameter);
        }

        #endregion // ICommand Members
    }

}
