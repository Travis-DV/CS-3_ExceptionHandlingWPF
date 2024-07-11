using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Validator;

namespace ExceptionHandlingWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<int> ints = new ObservableCollection<int>();

        public MainWindow()
        {
            InitializeComponent();
            int[] test = new int[] { 1, 2, 3 };
            LB_Viewer.ItemsSource = ints;
        }

        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            Tuple<bool, int[]> output = Validator.Validator.CheckIntArray(this.TB_Input.Text);
            if (output.Item1)
            {
                foreach (int item in output.Item2)
                {
                    ints.Add(item);
                }
                LB_Viewer.ItemsSource = new ObservableCollection<int>();
                LB_Viewer.ItemsSource = ints;
                LB_Adverage.Content = $"Adverage: {CalculateAverage(ints.ToArray())}";
            }
        }

        public static double CalculateAverage(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("Array cannot be null or empty");
            }

            double sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }

            return sum / numbers.Length;
        }
    }
}