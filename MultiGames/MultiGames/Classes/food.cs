using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MultiGames.Classes
{
    class food
    {
        public Image food_a;
        private int height = 25;
        private int width = 25;
        public int PosX = 0;
        public int PosY = 0;
        public food(Grid plocha,int X, int Y) {
            food_a = new Image();
            food_a.Height = 25;
            food_a.Width = 25;
            this.PosX = X;
            this.PosY = Y;
            food_a.VerticalAlignment = VerticalAlignment.Top;
            food_a.HorizontalAlignment = HorizontalAlignment.Left;
            food_a.Source = new BitmapImage(new Uri(@"Images/apple.png", UriKind.Relative));
            food_a.Margin = new Thickness(PosX * width, PosY * height, 0, 0);
            plocha.Children.Add(food_a);
        }
    }
}
