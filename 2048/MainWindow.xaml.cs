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

namespace _2048
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void PressingHandler(object sender,KeyEventArgs ev)
        {
            if (ClassGameField.IsFieldFilled())
            {
                ClassGameField.ShowEndWindow();
                return;
            }

            
            if (ev.Key==Key.Down)
            {
                MoveAllElements("Down");
                Grid currentCell = ClassGameField.SetNewElement();
                AddAllNumbers("Down");
                GameField.Children.Add(currentCell);
            }
            else if (ev.Key == Key.Left)
            {
                MoveAllElements("Left");
                Grid currentCell = ClassGameField.SetNewElement();
                AddAllNumbers("Left");
                GameField.Children.Add(currentCell);
            }
            else if (ev.Key == Key.Right)
            {
                MoveAllElements("Right");
                Grid currentCell = ClassGameField.SetNewElement();
                AddAllNumbers("Right");
                GameField.Children.Add(currentCell);
            }
            else if(ev.Key == Key.Up)
            {
                MoveAllElements("Up");
                Grid currentCell = ClassGameField.SetNewElement();
                //AddAllNumbersUpSide();
                AddAllNumbers("Up");
                GameField.Children.Add(currentCell);
                //GameField.Children.Clear();
                //To Do make function to remove elements
                //GameField.Children.Add(ClassGameField.SetNewElement());
            }

        }
        public void Method(object sender,RoutedEventArgs ev)
        {
            //Cell cell = new Cell("2",0,3);

            //Grid grid = cell.GetGrid();
            //Grid.SetColumn(grid, cell.Column);
            //Grid.SetRow(grid, cell.Row);
            //GameField.Children.Add(grid);
            //ClassGameField.Element_0_3.Number = "2";
        }
        //public bool IsFieldFilled()
        //{
        //    foreach (UIElement element in GameField.Children)
        //    {
        //        if (element == null)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        private UIElement GetElementInGridPosition(int row, int column)
        {
            foreach (UIElement element in GameField.Children)
            {
                if (Grid.GetColumn(element) == column && Grid.GetRow(element) == row)
                    return element;
            }
            return null;
        }
        private TextBlock GetElementInGridPositionTextBlock(int row, int column)
        {
            foreach (TextBlock element in GameField.Children)
            {
                if (Grid.GetColumn(element) == column && Grid.GetRow(element) == row)
                    return element;
            }
            return null;
        }
        public void AddAllNumbersUpSide()
        {
            Grid currentGridElement = null;
            Grid nextPositionElement = null;
            string currentFieldNumber = String.Empty;
            string nextFieldNumber = String.Empty;
            for (byte i = 0; i <= 3; i++)
            {
                for (byte j = 0; j <= 3; j++)
                {
                    currentGridElement = GetElementInGridPosition(i,j) as Grid;
                    nextPositionElement = GetElementInGridPosition(i+1, j) as Grid;

                    if (i<3&& currentGridElement!=null&& nextPositionElement!=null)
                    {
                        currentFieldNumber = ClassGameField.ReturnNumberWithRowAndColumn(i, j);
                        nextFieldNumber = ClassGameField.ReturnNumberWithRowAndColumn(i + 1, j);
                        if (currentFieldNumber.Equals(nextFieldNumber))
                        {
                            GameField.Children.Remove(nextPositionElement);
                            GameField.Children.Remove(currentGridElement);
                            ClassGameField.SetNumberIntoParticularPosition(null,i,j);
                            ClassGameField.SetNumberIntoParticularPosition(null, (byte)(i + 1), j);
                           
                            //ClassGameField.SetNumberIntoParticularPosition((int.Parse(currentFieldNumber)*2).ToString(), i, j);
                            string newNumber= (byte.Parse(currentFieldNumber) * 2).ToString();
                            Grid elementToAdd = Cell.GetGrid(newNumber);
                            ClassGameField.SetColemnAndRow(elementToAdd, i, j);
                            GameField.Children.Add(elementToAdd);

                            ClassGameField.SetNumberIntoParticularPosition(newNumber, i,j);

                        }
                    }

                }
            }

        }
        public (int, int,string, int,int)? ChooseDirection(string direction)
        {
            // 
            (int, int, string, int, int)? result = null;
            switch (direction) 
            {
                case "Up":
                    {
                        result = (-1,0,"Row",0,0);
                        break;
                    }
                case "Down":
                    {
                        result = (1, 0, "Row", 3, 0);
                        break;
                    }
                case "Left":
                    {
                        result = (0, -1, "Column", 0, 0);
                        break;
                    }
                case "Right":
                    {
                        result = (0, 1, "Column", 0, 3);
                        break;
                    }
            }
            return result;
        }
        public void MoveAllElements(string keyWord)
        {
            (int, int, string, int, int)? directionOfChanging = ChooseDirection(keyWord);
            Grid currentElement = null;
            Grid nextElement = null;
            for (int i = 0; i < 4; i++)
            {
                foreach (Cell item in ClassGameField.gameField)
                {
                    currentElement = GetElementInGridPosition(item.Row, item.Column) as Grid;
                    nextElement = GetElementInGridPosition((byte)(item.Row + directionOfChanging.Value.Item1), (byte)(item.Column + directionOfChanging.Value.Item2)) as Grid;
                    if (currentElement != null)
                    {
                        while (true)
                        {
                            if (directionOfChanging.Value.Item3=="Row" && directionOfChanging.Value.Item1==-1 && item.Row == 0)
                            {
                                break;
                            }
                            else if(directionOfChanging.Value.Item3 == "Row" && directionOfChanging.Value.Item1 == 1 && item.Row == 3)
                            {
                                break;
                            }
                            else if (directionOfChanging.Value.Item3 == "Column" && directionOfChanging.Value.Item2 == -1 && item.Column == 0)
                            {
                                break;
                            }
                            else if (directionOfChanging.Value.Item3 == "Column" && directionOfChanging.Value.Item2 == 1 && item.Column == 3)
                            {
                                break;
                            }

                            if (nextElement == null)
                            {
                                GameField.Children.Remove(currentElement);
                                ClassGameField.SetColemnAndRow(currentElement, (byte)(item.Row + directionOfChanging.Value.Item1), (byte)(item.Column + directionOfChanging.Value.Item2));
                                GameField.Children.Add(currentElement);
                                ClassGameField.ResetOldUpdateNewData(item.Row, item.Column, item.Number, (byte)(item.Row + directionOfChanging.Value.Item1), (byte)(item.Column + directionOfChanging.Value.Item2));
                                break;
                            }
                            if (nextElement != null)
                            {
                                break;
                            }
                            currentElement = null;
                            nextElement = null;
                        }
                    }

                }
            }
        }
        public bool CanItGo(int i,int j,string keyWord)
        {
            if (keyWord=="Up")
            {
                if (i<3)
                {
                    return true;
                }
            }
            else if (keyWord == "Down")
            {
                if (i > 0)
                {
                    return true;
                }
            }
            else if (keyWord == "Left")
            {
                if (j < 3)
                {
                    return true;
                }
            }
            else if (keyWord == "Right")
            {
                if (j > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public void AddAllNumbers(string keyWord)
        {
            (int, int)? ourKeyWord = ChooseDirectionToAdd(keyWord);
            Grid currentGridElement = null;
            Grid nextPositionElement = null;
            string currentFieldNumber = String.Empty;
            string nextFieldNumber = String.Empty;
            for (byte i = 0; i <= 3; i++)
            {
                for (byte j = 0; j <= 3; j++)
                {
                    currentGridElement = GetElementInGridPosition(i, j) as Grid;
                    nextPositionElement = GetElementInGridPosition(i + ourKeyWord.Value.Item1, j+ ourKeyWord.Value.Item2) as Grid;

                    if (CanItGo(i,j,keyWord) && currentGridElement != null && nextPositionElement != null)
                    {
                        currentFieldNumber = ClassGameField.ReturnNumberWithRowAndColumn(i, j);
                        nextFieldNumber = ClassGameField.ReturnNumberWithRowAndColumn(i + ourKeyWord.Value.Item1, j + ourKeyWord.Value.Item2);
                        if (currentFieldNumber.Equals(nextFieldNumber))
                        {
                            GameField.Children.Remove(nextPositionElement);
                            GameField.Children.Remove(currentGridElement);
                            ClassGameField.SetNumberIntoParticularPosition(null, i, j);
                            ClassGameField.SetNumberIntoParticularPosition(null, (byte)(i+ourKeyWord.Value.Item1), (byte)(j + ourKeyWord.Value.Item2));

                            //ClassGameField.SetNumberIntoParticularPosition((int.Parse(currentFieldNumber)*2).ToString(), i, j);
                            string newNumber = (byte.Parse(currentFieldNumber) * 2).ToString();
                            Grid elementToAdd = Cell.GetGrid(newNumber);
                            ClassGameField.SetColemnAndRow(elementToAdd, i, j);
                            GameField.Children.Add(elementToAdd);

                            ClassGameField.SetNumberIntoParticularPosition(newNumber, i, j);

                        }
                    }


                }
            }

        }
        public (int, int)? ChooseDirectionToAdd(string direction)
        {
            // 
            (int, int)? result = null;
            switch (direction)
            {
                case "Up":
                    {
                        result = (1, 0);
                        break;
                    }
                case "Down":
                    {
                        result = (-1, 0);
                        break;
                    }
                case "Left":
                    {
                        result = (0, 1);
                        break;
                    }
                case "Right":
                    {
                        result = (0, -1);
                        break;
                    }
            }
            return result;
        }
    }
}
