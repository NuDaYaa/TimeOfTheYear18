using System.Windows;
using System.Windows.Controls;

namespace MonthInfoApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateGroupBoxVisibility(); // Обновление видимости GroupBox после инициализации компонентов
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateGroupBoxVisibility();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateGroupBoxVisibility();
        }

        private void UpdateGroupBoxVisibility()
        {
            if (cbAutomatic != null && gbAutomatic != null && cbManual != null && gbManual != null)
            {
                gbAutomatic.Visibility = cbAutomatic.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
                gbManual.Visibility = cbManual.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
                txtOutput.Clear();
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (gbAutomatic.Visibility == Visibility.Visible)
            {
                UpdateOutput();
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateOutput();
        }

        private void UpdateOutput()
        {
            string monthName = string.Empty;

            if (gbAutomatic.Visibility == Visibility.Visible)
            {
                foreach (var control in (gbAutomatic.Content as StackPanel).Children)
                {
                    if (control is RadioButton rb && rb.IsChecked == true)
                    {
                        monthName = rb.Content.ToString();
                        break;
                    }
                }
            }
            else if (gbManual.Visibility == Visibility.Visible)
            {
                foreach (var control in (gbManual.Content as StackPanel).Children)
                {
                    if (control is RadioButton rb && rb.IsChecked == true)
                    {
                        monthName = rb.Content.ToString();
                        break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(monthName))
            {
                int monthNumber = GetMonthNumber(monthName);
                string season = GetSeason(monthNumber);
                txtOutput.Text = $"Месяц: {monthName}, Номер: {monthNumber}, Время года: {season}";
            }
        }

        private int GetMonthNumber(string monthName)
        {
            switch (monthName)
            {
                case "Январь": return 1;
                case "Февраль": return 2;
                case "Март": return 3;
                case "Апрель": return 4;
                case "Май": return 5;
                case "Июнь": return 6;
                case "Июль": return 7;
                case "Август": return 8;
                case "Сентябрь": return 9;
                case "Октябрь": return 10;
                case "Ноябрь": return 11;
                case "Декабрь": return 12;
                default: return 0;
            }
        }

        private string GetSeason(int monthNumber)
        {
            switch (monthNumber)
            {
                case 12:
                case 1:
                case 2: return "Зима";
                case 3:
                case 4:
                case 5: return "Весна";
                case 6:
                case 7:
                case 8: return "Лето";
                case 9:
                case 10:
                case 11: return "Осень";
                default: return string.Empty;
            }
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: Тогузов Максим\nНомер работы: 1\nФормулировка задания: " +
                            "Составить программу, которая бы по названию месяца выдавала бы его " +
                            "порядковый номер и название времени года.", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
