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
using System.Windows.Threading;
using Library;
namespace Практикаnew
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
        Matrix<int> matrix = new Matrix<int>(0, 0);

        private void FirtsTaskCheck_Click(object sender, RoutedEventArgs e)
        {
            if (!Int32.TryParse(numberTB.Text, out int result) || numberTB.Text.Length < 3)
            {
                MessageBox.Show("Вы ввели не 3-ех значное число. Еще раз");
                numberTB.Clear();
            }
            else if (Nubmer.CompareThreeNumber(result)) MessageBox.Show("Все три числа равны");
            else MessageBox.Show("Числа не равны");
        }

        private void SolvingSecond_Click(object sender, RoutedEventArgs e)
        {
            if (!Int32.TryParse(firstNumber.Text, out int first) || !Int32.TryParse(secondNumber.Text, out int second) || !Int32.TryParse(thirdNumber.Text, out int third))
            {
                MessageBox.Show("Вы не ввели числа");
                firstNumber.Clear();
                secondNumber.Clear();
                thirdNumber.Clear();
            }
            else
            {
                var results = Nubmer.CountPositiveOrNegetiveNumb(first, second, third);
                MessageBox.Show($"Количество положительных - {results.Item1}\n Количество отрицательных - {results.Item2}");
                firstNumber.Clear();
                secondNumber.Clear();
                thirdNumber.Clear();
            }
        }

        private void SolvingThird_Click(object sender, RoutedEventArgs e)
        {
            if (!Int32.TryParse(lenghtTB.Text, out int results) | !Int32.TryParse(numberForTheSearchTB.Text, out int search))
            {
                MessageBox.Show("Вы не ввели длину массива и число для нахождения его в массиве");
                lenghtTB.Clear();
            }
            else
            {
                string defArray = "";
                string resultsString = "";
                Random rnd = new();
                int[] array = new int[Int32.Parse(lenghtTB.Text)];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rnd.Next(-2, 2);
                    defArray += $"{array[i]} ";
                }
                var resultsArray = Nubmer.SqurareNegativeNumber(array, search);
                for (int i = 0; i < array.Length; i++)
                {
                    resultsString += $"{resultsArray[i]} ";
                }

                arrayDefaultTB.Text = defArray;
                arrayWithNegetiveNumbTB.Text = resultsString;
                lenghtTB.Clear();
                numberForTheSearchTB.Clear();
            }
        }

        private void CreateMatrix_Click(object sender, RoutedEventArgs e)
        {
            if (!Int32.TryParse(rowMatrixTB.Text, out int rowMatrix) || !Int32.TryParse(columnMatrixTB.Text, out int columnMatrix)) MessageBox.Show("Вы не выполнили все условия на создание матрицы!\nВведите количество строк и столбцов.");
            else
            {
                Nubmer.Create(matrix, rowMatrix, columnMatrix);
                DataGrid.ItemsSource = matrix.ToDataTable().DefaultView;
                rowMatrixTB.Clear();
                columnMatrixTB.Clear();
            }
        }

        private void SolvingMatrix_Click(object sender, RoutedEventArgs e)
        {
            if (!Int32.TryParse(startIntervalTB.Text, out int startInterval) || !Int32.TryParse(endIntervalTB.Text, out int endInterval)) MessageBox.Show("Вы не ввели границы интервала!");
            else
            {
                MessageBox.Show($"Количество элеметов, которые находятся вне интервала - {Nubmer.CountElementWithOutIntervala(matrix, startInterval, endInterval)}");
                startIntervalTB.Clear();
                endIntervalTB.Clear();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timer.IsEnabled = true;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            time.Text = d.ToString("HH:mm");
            data.Text = d.ToString("dd.MM.yyyy");
        }
    }
}
