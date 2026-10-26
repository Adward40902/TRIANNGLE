using System;
using System.Windows;

namespace Triangle
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            // 1. Считываем данные
            string aStr = SideA.Text.Trim();
            string bStr = SideB.Text.Trim();
            string cStr = SideC.Text.Trim();

            // 2. Валидация ввода (проверка, что введены числа)
            if (!int.TryParse(aStr, out int a) ||
                !int.TryParse(bStr, out int b) ||
                !int.TryParse(cStr, out int c))
            {
                ResultText.Text = "Ошибка: Введите целые числа во все поля.";
                return;
            }

            // 3. Проверка на положительные числа
            if (a <= 0 || b <= 0 || c <= 0)
            {
                ResultText.Text = "Ошибка: Длины сторон должны быть положительными числами.";
                return;
            }

            // 4. Проверка существования треугольника (Неравенство треугольника)
            if (a + b <= c || a + c <= b || b + c <= a)
            {
                ResultText.Text = "Такой треугольник не существует (нарушено неравенство треугольника).";
                return;
            }

            // 5. Определение типа треугольника
            string type;
            if (a == b && b == c)
            {
                type = "Равносторонний";
            }
            else if (a == b || b == c || a == c)
            {
                type = "Равнобедренный";
            }
            else
            {
                type = "Разносторонний";
            }

            ResultText.Text = $"Это {type} треугольник.";
        }
    }
}