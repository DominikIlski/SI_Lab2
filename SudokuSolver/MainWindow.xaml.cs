using Algorytm_Ewolucyjny.Services;
using SudokuSolver.Models;
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

namespace SudokuSolver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SudokuBook SudokuBook { get; set; }
        FileReader FileReader { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            FileReader = new FileReader();
            SudokuBook = FileReader.FirstLoad();
            var tester = SudokuBook;


            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j <9; j++)
                {


                    Border sudokuField = new Border
                    {
                        BorderBrush = Brushes.Black,
                        BorderThickness = GetThickness(i, j, 0.1, 0.3)
                    };

                    TextBlock tx = new TextBlock
                    {
                        Text = "9"
                    };

                    Viewbox vb = new Viewbox();

                    vb.Child = tx;

                   
                    sudokuField.Child = vb;


                    Grid.SetColumn(sudokuField, j);
                    Grid.SetRow(sudokuField, i);

                    SudokuGrid.Children.Add(sudokuField);
                    

                    /*SudokuGrid.Children.Add(sudokuField);
                    SudokuGrid.Children.Add(sudokuField);
                    SudokuGrid.Children.Add(sudokuField);*/



                }
            }


        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {



        }

        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {

        }

        #region private methods

        private Thickness GetThickness(int i, int j, double thin, double thick)
        {
            var top = i % 3 == 0 ? thick : thin;
            var bottom = i % 3 == 2 ? thick : thin;
            var left = j % 3 == 0 ? thick : thin;
            var right = j % 3 == 2 ? thick : thin;
            return new Thickness(left, top, right, bottom);
        }

        #endregion


    }
}
