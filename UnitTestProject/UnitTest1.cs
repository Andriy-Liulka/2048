using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace _2048
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetCell_Test()
        {
            Grid codeGrid = new Grid();
            TextBlock textBlock = new TextBlock();
            textBlock.Text = Number;
            codeGrid.Background = Brushes.RosyBrown;
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center;

        }
    }
}
