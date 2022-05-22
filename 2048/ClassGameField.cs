using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace _2048
{
    class ClassGameField
    {
        #region ZeroRow
        public static Cell Element_0_0 = new Cell { Row = 0, Column = 0 };
        public static Cell Element_0_1 = new Cell { Row = 0, Column = 1 };
        public static Cell Element_0_2 = new Cell { Row = 0, Column = 2 };
        public static Cell Element_0_3 = new Cell { Row = 0, Column = 3 };
        #endregion
        #region FirstRow
        public static Cell Element_1_0 = new Cell { Row = 1, Column = 0 };
        public static Cell Element_1_1 = new Cell { Row = 1, Column = 1 };
        public static Cell Element_1_2 = new Cell { Row = 1, Column = 2 };
        public static Cell Element_1_3 = new Cell { Row = 1, Column = 3 };
        #endregion
        #region SecondRow
        public static Cell Element_2_0 = new Cell { Row = 2, Column = 0 };
        public static Cell Element_2_1 = new Cell { Row = 2, Column = 1 };
        public static Cell Element_2_2 = new Cell { Row = 2, Column = 2 };
        public static Cell Element_2_3 = new Cell { Row = 2, Column = 3 };
        #endregion
        #region ThirdRow
        public static Cell Element_3_0 = new Cell { Row = 3, Column = 0 };
        public static Cell Element_3_1 = new Cell { Row = 3, Column = 1 };
        public static Cell Element_3_2 = new Cell { Row = 3, Column = 2 };
        public static Cell Element_3_3 = new Cell { Row = 3, Column = 3 };
        #endregion
        public static List<Cell> gameField = new List<Cell> { 
            Element_0_0 , Element_0_1 , Element_0_2 , Element_0_3,
            Element_1_0 , Element_1_1 , Element_1_2 , Element_1_3,
            Element_2_0 , Element_2_1 , Element_2_2 , Element_2_3,
            Element_3_0 , Element_3_1 , Element_3_2 , Element_3_3
        };
        private static string defaultValue = "2";

        public static string ReturnNumberWithRowAndColumn(int row,int column)
        {
            foreach (Cell item in gameField)
            {
                if (item.Row == row && item.Column== column)
                {
                    return item.Number;
                }
            }
            return String.Empty;
        }

        public static void ResetOldUpdateNewData(byte oldRow,byte oldColumn,string number, byte newRow, byte newColumn)
        {
            for (int i = 0; i < gameField.Count; i++)
            {
                if (gameField[i].Row== newRow && gameField[i].Column == newColumn)
                {
                    gameField[i].Number = number;
                }
                if (gameField[i].Row == oldRow && gameField[i].Column == oldColumn)
                {
                    gameField[i].Number = null;
                }
            }
        }
        public static void SetNumberIntoParticularPosition(string Number,byte row, byte column)
        {
            for (int i = 0; i < gameField.Count; i++)
            {
                if (gameField[i].Row == row && gameField[i].Column == column)
                {
                    gameField[i].Number = Number;
                }
            }

        }
        public static void SetColemnAndRow(Grid element, byte row,byte column)
        {
            Grid.SetColumn(element, column);
            Grid.SetRow(element, row);
        }

        public static bool IsFieldFilled()
        {
            bool isFelt = false;
            foreach (Cell item in gameField)
            {
                if (item.Number == null)
                {
                    return false;
                }
            }
            //foreach (UIElement element in GameField.Children)
            //{
            //    if (Grid.GetColumn(element) == column && Grid.GetRow(element) == row)
            //        return element;
            //}
            return true;
        }

        public static void ShowEndWindow()
        {
            FinishWindow window = new FinishWindow();
            window.ShowDialog();
        }
        public static Grid SetNewElement()
        {
            bool elementInstalled = false;
            int number =default;
            Cell chosenCell = null;
            List<int>arrayOfNumbers =new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            
            while (elementInstalled == false)
            {
                number = GenerateRandomPositionOnField2Way(arrayOfNumbers);
                arrayOfNumbers.Remove(number);

                switch (number)
                {
                    #region ZeroRow
                    case 1:
                        {
                            if (Element_0_0.Number == null)
                            {
                                Element_0_0.Number = defaultValue;
                                chosenCell = Element_0_0;
                                elementInstalled = true;
                            }
                            break;
                        }
                    case 2:
                        {
                            if (Element_0_1.Number == null)
                            {
                                Element_0_1.Number = defaultValue;
                                chosenCell = Element_0_1;
                                elementInstalled = true;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (Element_0_2.Number == null)
                            {
                                Element_0_2.Number = defaultValue;
                                chosenCell = Element_0_2;
                                elementInstalled = true;
                            }
                            break;
                        }
                    case 4:
                        {
                            if (Element_0_3.Number == null)
                            {
                                Element_0_3.Number = defaultValue;
                                chosenCell = Element_0_3;
                                elementInstalled = true;
                            }
                            break;
                        }
                    #endregion
                    #region FirstRow
                    case 5:
                        {
                            if (Element_1_0.Number == null)
                            {
                                Element_1_0.Number = defaultValue;
                                chosenCell = Element_1_0;
                                elementInstalled = true;
                            }
                            break;
                        }
                    case 6:
                        {
                            if (Element_1_1.Number == null)
                            {
                                Element_1_1.Number = defaultValue;
                                chosenCell = Element_1_1;
                                elementInstalled = true;
                            }
                            break;
                        }
                    case 7:
                        {
                            if (Element_1_2.Number == null)
                            {
                                Element_1_2.Number = defaultValue;
                                chosenCell = Element_1_2;
                                elementInstalled = true;
                            }
                            break;
                        }
                    case 8:
                        {
                            if (Element_1_3.Number == null)
                            {
                                Element_1_3.Number = defaultValue;
                                chosenCell = Element_1_3;
                                elementInstalled = true;
                            }
                            break;
                        }
                    #endregion
                    #region SecondRow
                    case 9:
                        {
                            if (Element_2_0.Number == null)
                            {
                                Element_2_0.Number = defaultValue;
                                chosenCell = Element_2_0;
                                elementInstalled = true;
                            }
                            break;
                        }
                    case 10:
                        {
                            if (Element_2_1.Number == null)
                            {
                                Element_2_1.Number = defaultValue;
                                chosenCell = Element_2_1;
                                elementInstalled = true;
                            }
                            break;
                        }
                    case 11:
                        {
                            if (Element_2_2.Number == null)
                            {
                                Element_2_2.Number = defaultValue;
                                chosenCell = Element_2_2;
                                elementInstalled = true;
                            }
                            break;
                        }
                    case 12:
                        {
                            if (Element_2_3.Number == null)
                            {
                                Element_2_3.Number = defaultValue;
                                chosenCell = Element_2_3;
                                elementInstalled = true;
                            }
                            break;
                        }
                    #endregion
                    #region ThirdRow
                    case 13:
                        {
                            if (Element_3_0.Number == null)
                            {
                                Element_3_0.Number = defaultValue;
                                chosenCell = Element_3_0;
                                elementInstalled = true;
                            }
                            break;
                        }
                    case 14:
                        {
                            if (Element_3_1.Number == null)
                            {
                                Element_3_1.Number = defaultValue;
                                chosenCell = Element_3_1;
                                elementInstalled = true;
                            }
                            break;
                        }
                    case 15:
                        {
                            if (Element_3_2.Number == null)
                            {
                                Element_3_2.Number = defaultValue;
                                chosenCell = Element_3_2;
                                elementInstalled = true;
                            }
                            break;
                        }
                    case 16:
                        {
                            if (Element_3_3.Number == null)
                            {
                                Element_3_3.Number = defaultValue;
                                chosenCell = Element_3_3;
                                elementInstalled = true;
                            }
                            break;
                        }
                        #endregion
                }
            }
            //chosenCell.Number = defaultValue;
            Grid element = chosenCell.GetGrid();
            SetColemnAndRow(element, chosenCell.Row, chosenCell.Column);
            return element;
        }

        public static void SetStringIntoProperObject(ref string obj,string item)
        {
            obj = item;
        }

        public static int GenerateRandomPositionOnField1Way()
        {
            Random rand = new Random();
            int number = rand.Next(1,17);
            return number;
        }
        public static int GenerateRandomPositionOnField2Way(List<int> array)
        {
            if (array.Count ==0)
            {
                throw new Exception("Count of numbers in array is zero");
            }
            Random rand = new Random();
            int number = rand.Next(0, array.Count);
            return array[number];
        }
    }
}
