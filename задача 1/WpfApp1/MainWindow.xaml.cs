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

namespace WpfApp1
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateArea_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получаем значения из TextBox
                double radius = double.Parse(RadiusTextBox.Text);
                double width = double.Parse(Rect1TextBox.Text);
                double height = double.Parse(Rect2TextBox.Text);
                double sideA = double.Parse(Triangle1TextBox.Text);
                double sideB = double.Parse(Triangle2TextBox.Text);
                double sideC = double.Parse(Triangle3TextBox.Text);

                // Создаем фигуры
                Figure circle = new Circle(radius);
                Figure rectangle = new Rectangle(width, height);
                Figure triangle = new Triangle(sideA, sideB, sideC);

                // Вычисляем площади
                double circleArea = circle.CalculateArea();
                double rectangleArea = rectangle.CalculateArea();
                double triangleArea = triangle.CalculateArea();

                // Отображаем результаты
                ResultTextBlock.Text = $"Площадь круга: {circleArea}\nПлощадь прямоугольника: {rectangleArea}\nПлощадь Треугольника: {triangleArea}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Введены неверные значения");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникла ошибка: {ex.Message}");
            }
        }
    }
}
