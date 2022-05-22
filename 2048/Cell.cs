using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _2048
{
    class Cell
    {
        public string Number { get; set; }
        public byte Row { get; set; }
        public byte Column { get; set; }

        public Cell(string number, byte row, byte column)
        {
            Number = number;
            Row = row;
            Column = column;
        }

        public Cell() {}

        public  Grid GetGrid()
        {
            Grid codeGrid = new Grid();
            TextBlock textBlock = new TextBlock();
            textBlock.Text = Number;
            codeGrid.Background = Brushes.RosyBrown;
            textBlock.Foreground = Brushes.Black;
            textBlock.FontSize = 27;
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            codeGrid.Children.Add(textBlock);
            return codeGrid;
        }

        public static Grid GetGrid(string number)
        {
            Grid codeGrid = new Grid();
            TextBlock textBlock = new TextBlock();
            textBlock.Text = number;
            codeGrid.Background = Brushes.RosyBrown;
            textBlock.Foreground = Brushes.Black;
            textBlock.FontSize = 27;
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            codeGrid.Children.Add(textBlock);
            return codeGrid;
        }
    }
}
