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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace lb._2D
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Время
            Clock = new System.Windows.Threading.DispatcherTimer();
            //назначение обработчика события Тик
            Clock.Tick += new EventHandler(tick);
            //TimeSpan – переменная для хранения времени в формате часы/минуты/секунды
            Clock.Interval = new TimeSpan(0, 0, 1);
        }

        //stopwatch
        System.Windows.Threading.DispatcherTimer Clock;


        int i = 0;
        void tick(object sender, EventArgs e)
        {
            //создание объекта линия
            Line myLine1 = new Line();
            if (i == 0){
                //установка цвета линии
                myLine1.Stroke = System.Windows.Media.Brushes.Black;
                //координаты начала линии
                myLine1.X1 = 100;
                myLine1.Y1 = 100;
                //координаты конца линии
                myLine1.X2 = 1;
                myLine1.Y2 = 1;

                //параметры выравнивания в сцене
                myLine1.HorizontalAlignment = HorizontalAlignment.Left;
                myLine1.VerticalAlignment = VerticalAlignment.Center;
                //толщина линии
                myLine1.StrokeThickness = 2;
                //добавление линии в сцену
                scene.Children.Add(myLine1);
                i++;
                return;
            }
            if (i == 1)
            {
                scene.Children.Remove(myLine1);
                Line myLine2 = new Line();

                //установка цвета линии
                myLine2.Stroke = System.Windows.Media.Brushes.Black;
                //координаты начала линии
                myLine2.X1 = 1;
                myLine2.Y1 = 100;
                //координаты конца линии
                myLine2.X2 = 100;
                myLine2.Y2 = 100;

                //параметры выравнивания в сцене
                myLine2.HorizontalAlignment = HorizontalAlignment.Left;
                myLine2.VerticalAlignment = VerticalAlignment.Center;
                //толщина линии
                myLine2.StrokeThickness = 2;
                scene.Children.Add(myLine2);
            }

        }
        void circle()
        {
            //создание объекта овал
            Ellipse myEllipse = new Ellipse();
            //создание объекта кисть
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            //установка цвета в виде сочетания компонент ARGB (alpha, red, green, blue)
            mySolidColorBrush.Color = Color.FromArgb(255, 0, 0, 0);
            //установка объекта кисти в параметр заливки объекта овал
            myEllipse.Fill = mySolidColorBrush;
            //толщина и цвет обводки
            myEllipse.StrokeThickness = 2;
            myEllipse.Stroke = Brushes.Black;
            //размеры овала
            myEllipse.Width = 100;
            myEllipse.Height = 100;
            //позиция овала
            myEllipse.Margin = new Thickness(50, 50, 0, 0);
            //добавление овала в сцену
            scene.Children.Add(myEllipse);

            //создание объекта овал
            Ellipse myEllipse1 = new Ellipse();
            //создание объекта кисть
            SolidColorBrush mySolidColorBrush1 = new SolidColorBrush();
            //установка цвета в виде сочетания компонент ARGB (alpha, red, green, blue)
            mySolidColorBrush1.Color = Color.FromArgb(255, 255, 0, 0);
            //установка объекта кисти в параметр заливки объекта овал
            myEllipse1.Fill = mySolidColorBrush1;
            //толщина и цвет обводки
            myEllipse1.StrokeThickness = 2;
            myEllipse1.Stroke = Brushes.Black;
            //размеры овала
            myEllipse1.Width = 90;
            myEllipse1.Height = 90;
            //позиция овала
            myEllipse1.Margin = new Thickness(50, 50, 0, 0);
            //добавление овала в сцену
            scene.Children.Add(myEllipse1);

        }

        private void make_Click(object sender, RoutedEventArgs e)
        {
            //Clock.Start();

            circle();
        }
    }
}
