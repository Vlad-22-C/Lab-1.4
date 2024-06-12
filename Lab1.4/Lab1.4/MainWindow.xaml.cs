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

namespace Lab1._4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
  
      public partial class MainWindow : Window
        {
            public List<int> Years { get; set; }
            public List<string> Months { get; set; }
            public List<int> Days { get; set; }

            public MainWindow()
            {
                InitializeComponent();

                Years = Enumerable.Range(1900, DateTime.Now.Year - 1900 + 1).ToList();
                Months = new List<string> { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
                Days = Enumerable.Range(1, 31).ToList();

                cbYear.ItemsSource = Years;
                cbMonth.ItemsSource = Months;
                cbDay.ItemsSource = Days;

                cbMonth.SelectionChanged += CbMonth_SelectionChanged;
            }

            private void CbMonth_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                int year = Years[cbYear.SelectedIndex];
                int month = cbMonth.SelectedIndex + 1;

                Days = Enumerable.Range(1, DateTime.DaysInMonth(year, month)).ToList();
                cbDay.ItemsSource = Days;
            }

            private void BtnCalculate_Click(object sender, RoutedEventArgs e)
            {
                DateTime selectedDate = new DateTime(Years[cbYear.SelectedIndex], cbMonth.SelectedIndex + 1, cbDay.SelectedIndex + 1);
                TimeSpan timeSpan = DateTime.Now - selectedDate;

                int years = timeSpan.Days / 365;
                int months = (timeSpan.Days % 365) / 30;
                int days = (timeSpan.Days % 365) % 30;

                txtResult.Text = $"Прошло {years} лет, {months} месяцев и {days} дней с выбранной даты.";
            }
        }
    }
