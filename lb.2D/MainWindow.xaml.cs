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

namespace Clock
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Clock.Interval = new TimeSpan(0, 0, 0, 0, 1);
            Clock.Tick += tick;
            
        }


        DispatcherTimer Clock = new DispatcherTimer();

        double RotateS;
        double RotateM;
        double RotateH;
        void tick(object sender, EventArgs e)
        {
            bool zero = false;

            //Получаем текущее время на компьютере
            if (zero == false){
                DateTime current = DateTime.Now;
                RotateH = current.Hour * 30;
                RotateM = current.Minute * 6;
                RotateS = current.Second * 6;

                //Вращаем стрелки часов
                Second.RenderTransform = new RotateTransform(RotateS, 1, 170);
                Minute.RenderTransform = new RotateTransform(RotateM, 1, 170);
                Hour.RenderTransform = new RotateTransform(RotateH, 1, 100);
            }
            //Вращаем стрелки часов c 0-ой позиции
            if(zero == true){
                RotateS += 0.1;

                Second.RenderTransform = new RotateTransform(RotateS, 1, 170);

                if(RotateS >= 360)
                {
                    RotateS = 0;
                    RotateM += 6;

                    Minute.RenderTransform = new RotateTransform(RotateM, 1, 170);
                }

                if (RotateM >= 360)
                {
                    RotateM = 0;
                    RotateH += 30;

                    Hour.RenderTransform = new RotateTransform(RotateH, 1, 100);
                }
            }

        } 

        Line Hour;
        Line HourShape()
        {
            //создание объекта линия
            Line myLine = new Line();
            //установка цвета линии
            myLine.Stroke = System.Windows.Media.Brushes.Black;

            //координаты начала линии
            myLine.X1 = 1;
            myLine.Y1 = 1;
            //координаты конца линии
            myLine.X2 = 1;
            myLine.Y2 = 110;

            myLine.Margin = new Thickness(300, 185, 300, 100);

            //толщина линии
            myLine.StrokeThickness = 6;
            //добавление линии в сцену
            return myLine;
        }

        Line Minute;
        Line MinuteShape()
        {
            //создание объекта линия
            Line myLine = new Line();
            //установка цвета линии
            myLine.Stroke = System.Windows.Media.Brushes.Black;

            //координаты начала линии
            myLine.X1 = 1;
            myLine.Y1 = 1;
            //координаты конца линии
            myLine.X2 = 1;
            myLine.Y2 = 180;

            myLine.Margin = new Thickness(300, 115, 300, 100);

            //толщина линии
            myLine.StrokeThickness = 3;
            //добавление линии в сцену
            return myLine;
        }

        Line Second;
        Line SecondShape()
        {
            //создание объекта линия
            Line myLine = new Line();
            //установка цвета линии
            myLine.Stroke = System.Windows.Media.Brushes.Red;

            //координаты начала линии
            myLine.X1 = 1;
            myLine.Y1 = 1;
            //координаты конца линии
            myLine.X2 = 1;
            myLine.Y2 = 180;

            myLine.Margin = new Thickness(300, 115, 300, 100);

            //толщина линии
            myLine.StrokeThickness = 2;
            //добавление линии в сцену
            return myLine;
        }

        Ellipse Dial()
        {
            //создание объекта овал
            Ellipse myEllipse = new Ellipse();
            //кисть для заполнения прямоугольника изображением
            ImageBrush ib = new ImageBrush();
            //позиция изображения будет указана как координаты левого верхнего угла
            //изображение будет растянуто по размерам прямоугольника, описанного вокруг фигуры
            ib.AlignmentX = AlignmentX.Left;
            ib.AlignmentY = AlignmentY.Top;
            //загрузка изображения и назначение кисти
            ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Pic/clock dial.jpg", UriKind.Absolute));
            myEllipse.Fill = ib;


            //толщина и цвет обводки
            myEllipse.StrokeThickness = 2;
            myEllipse.Stroke = Brushes.Black;

            //размеры овала
            myEllipse.Width = 400;
            myEllipse.Height = 400;

            //позиция овала
            myEllipse.Margin = new Thickness(100, 80, 100, 80);
            
            return myEllipse;
        }

        Ellipse Dot()
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


            //толщина и цвет обводки
            myEllipse.StrokeThickness = 2;
            myEllipse.Stroke = Brushes.Black;

            //размеры овала
            myEllipse.Width = 10;
            myEllipse.Height = 10;

            //позиция овала
            myEllipse.Margin = new Thickness(297, 280, 300, 100);

            return myEllipse;
        }


        private void make_Click(object sender, RoutedEventArgs e)
        {
            Hour = HourShape();
            Minute = MinuteShape();
            Second = SecondShape();

            scene.Children.Add(Dial());

            scene.Children.Add(Hour);
            scene.Children.Add(Minute);
            scene.Children.Add(Second);

            //scene.Children.Add(Dot());

            Clock.Start();

            make.IsEnabled = false;
        }

    }
}
