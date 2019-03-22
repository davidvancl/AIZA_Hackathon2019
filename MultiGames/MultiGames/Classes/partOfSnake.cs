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
    class partOfSnake
    {
        public Image MyPartOfSnake;
        public int PosX = 0;
        public int PosY = 0;
        private int width = 25;
        private int height = 25;
        public int LastPosX = 0;
        public int LastPosY = 0;
        public partOfSnake(Grid plocha,String coToJe,int PosX,int PosY) {
            MyPartOfSnake = new Image();
            MyPartOfSnake.Width = width;
            MyPartOfSnake.Height = height;
            MyPartOfSnake.VerticalAlignment = VerticalAlignment.Top;
            MyPartOfSnake.HorizontalAlignment = HorizontalAlignment.Left;
            this.PosX = PosX;
            this.PosY = PosY;
            MyPartOfSnake.Margin = new Thickness(PosX * width, PosY * height, 0, 0);
            if (coToJe == "HEAD"){
                MyPartOfSnake.Source = new BitmapImage(new Uri(@"Images/head.png", UriKind.Relative));
            }
            else {
                MyPartOfSnake.Source = new BitmapImage(new Uri(@"Images/body.png", UriKind.Relative));
            }
            plocha.Children.Add(MyPartOfSnake);
        }

        public void MoveObject(string smer) {
            this.LastPosX = PosX;
            this.LastPosY = PosY;
            switch (smer) {
                case "LEFT":

                    PosX++;
                    if (PosX > 30) {
                        PosX = 0;
                    }
                    break;
                case "RIGHT":

                    PosX--;
                    if (PosX < 0) {
                        PosX = 30;
                    }
                    break;
                case "TOP":
             
                    PosY++;
                    if (PosY > 16) {
                        PosY = 0;
                    }
                    break;
                case "DOWN":
                    
                    PosY--;
                    if (PosY < 0) {
                        PosY = 16;
                    }
                    break;
            }
            MyPartOfSnake.Margin = new Thickness(PosX * width, PosY * height, 0, 0);
        }

        public void sledujHlavu(int newPosX,int newPosY) {
            LastPosX = PosX;
            LastPosY = PosY;
            PosX = newPosX;
            PosY = newPosY;
            MyPartOfSnake.Margin = new Thickness(PosX * width, PosY * height, 0, 0);
        }
    }
}
