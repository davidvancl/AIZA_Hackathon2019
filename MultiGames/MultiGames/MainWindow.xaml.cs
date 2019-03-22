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
using MultiGames.Classes;

namespace MultiGames
{
    public partial class MainWindow : Window
    {
        private List<partOfSnake> SnakeArray = new List<partOfSnake>();
        private DispatcherTimer threading;
        private string headSmer = "LEFT";
        private food jidlo;
        partOfSnake sn;
        Random rnd;
        private int points = 0;
        public MainWindow()
        {
            InitializeComponent();
            sn = new partOfSnake(had_grid,"HEAD",5,15);
            SnakeArray.Add(sn);
            partOfSnake had = new partOfSnake(had_grid, "BODY", 4, 15);
            SnakeArray.Add(had);
            partOfSnake had1 = new partOfSnake(had_grid, "BODY", 3, 15);
            SnakeArray.Add(had1);

            jidlo = new food(had_grid,10,10);
            rnd = new Random();
            threading = new DispatcherTimer();
            threading.Interval = TimeSpan.FromMilliseconds(400);
            threading.Tick += new EventHandler(execute_Move);
            threading.Start();
        }
        private void execute_Move(object sender, EventArgs e)
        {
            for (int i = 0; i < SnakeArray.Count; i++) {
                if (i == 0)
                {
                    sn.MoveObject(headSmer);
                } else {
                    if (SnakeArray[0].PosX == SnakeArray[i].PosX && SnakeArray[0].PosY == SnakeArray[i].PosY) {
                        output.Visibility = Visibility.Visible;
                        threading.Stop();
                    }
                }
                if(i == 1)
                {
                    int x = sn.LastPosX;
                    int y = sn.LastPosY;
                    SnakeArray[i].sledujHlavu(x, y);
                }
                if(i > 1) { 
                    int x = SnakeArray[i - 1].LastPosX;
                    int y = SnakeArray[i - 1].LastPosY;
                    SnakeArray[i].sledujHlavu(x, y);
                }
            }

            if (jidlo != null)
            {
                if (SnakeArray[0].PosX == jidlo.PosX && SnakeArray[0].PosY == jidlo.PosY)
                {
                    partOfSnake newPart = new partOfSnake(had_grid, "BODY", SnakeArray[SnakeArray.Count - 1].LastPosX, SnakeArray[SnakeArray.Count - 1].LastPosY);
                    SnakeArray.Add(newPart);
                    had_grid.Children.Remove(jidlo.food_a);
                    jidlo = null;
                    points++;
                }
            }
            else {
                int xi = rnd.Next(0, 31);
                int yi = rnd.Next(0, 17);
                jidlo = new food(had_grid, xi, yi);
            }
            points_output.Content = "My points: " + points;
        }

        private void vygenerujJidlo() {

        }

        private void MyApplication_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Left)
            {
                headSmer = "RIGHT";
            }
            if (e.Key == Key.Up)
            {
                headSmer = "DOWN";
            }
            if (e.Key == Key.Down)
            {
                headSmer = "TOP";
            }
            if (e.Key == Key.Right)
            {
                headSmer = "LEFT";
            }
        }
    }
}
