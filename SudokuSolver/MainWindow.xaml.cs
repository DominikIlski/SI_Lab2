using Algorytm_Ewolucyjny.Services;
using SudokuSolver.Global;
using SudokuSolver.Models;
using SudokuSolver.Models.ValueHeuristics;
using SudokuSolver.Models.VariableHeuristics;
using SudokuSolver.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SudokuSolver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SudokuBook SudokuBook { get; set; }
        private FileReader FileReader { get; set; }
        private SudokuSolverAlgorithm SudokuSolver { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            FileReader = new FileReader();
            SudokuBook = FileReader.FirstLoad();
            DisplaySudokuGrid(SudokuBook[0].Sudoku);
            InitializeSudokuBox();
            InitializeMethodBox();
            InitializeVariableBox();
            InitializeValueBox();
        }

        private void InitializeSudokuBox()
        {
            var idList = SudokuBook.SudokuList.Select( item => $"{item.Id}  Poziom trudności: {item.Difficulty}").ToList();
            ChooseSudokuBox.ItemsSource = idList;
            ChooseSudokuBox.SelectedIndex = 0;
        }

        private void InitializeMethodBox()
        {
            var methodsList = new List<string>
            {
                "Przeszukiwanie z nawrotami"
            };
            ChooseMethodBox.ItemsSource = methodsList;
            ChooseMethodBox.SelectedIndex = 0;
        }

        private void InitializeVariableBox()
        {
            var methodsList = new List<string>
            {
                "Najbardziej ograniczona"
            };
            ChooseVariableBox.ItemsSource = methodsList;
            ChooseVariableBox.SelectedIndex = 0;
        }

        private void InitializeValueBox()
        {
            var methodsList = new List<string>
            {
                "W kolejności definicji"
            };
            ChooseValueBox.ItemsSource = methodsList;
            ChooseValueBox.SelectedIndex = 0;
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

        private void DisplaySudokuGrid(Sudoku sudoku)
        {
            SudokuGrid.Children.Clear();

            for (int i = 0; i < Globals.SUDOKU_SIZE; i++)
            {
                for (int j = 0; j < Globals.SUDOKU_SIZE; j++)
                {
                    Border sudokuField = new Border
                    {
                        BorderBrush = Brushes.Black,
                        BorderThickness = GetThickness(i, j, 0.1, 0.3)
                    };

                    TextBlock tx = new TextBlock
                    {
                        Text = sudoku[j, i] == 0 ? " " : sudoku[j, i].ToString()
                    };

                    Viewbox vb = new Viewbox
                    {
                        Child = tx
                    };

                    sudokuField.Child = vb;

                    Grid.SetColumn(sudokuField, j);
                    Grid.SetRow(sudokuField, i);

                    SudokuGrid.Children.Add(sudokuField);
                }
            }
        }

        #endregion private methods

        private void Solve_Click(object sender, RoutedEventArgs e)
        {
            SudokuSolver = new SudokuSolverAlgorithm(SudokuBook, new MostLimitedVariable(), new RandomValue());
            var solved = SudokuSolver.Run(ChooseSudokuBox.SelectedIndex);
            DisplaySudokuGrid(solved[0]);
            FirstNodeCoutTxt.Text = $"Odwiedzone węzły drzewa: {SudokuSolver.FirstNodes}";
            FirstTimeTxt.Text = $"Czas rozwiązywania: {SudokuSolver.FirstSolutionTime}";
            ReturnNodeCountTxt.Text = $"Liczba nawrotów: {SudokuSolver.FirstReturnCount}";

            AllNodeCoutTxt.Text = $"Odwiedzone węzły drzewa: {SudokuSolver.AllNodes}";
            AllTimeTxt.Text = $"Czas rozwiązywania: {SudokuSolver.AllSolutionsTime}";
            AllReturnNodeCountTxt.Text = $"Liczba nawrotów: {SudokuSolver.AllReturnCount}";
            SolutionCountTxt.Text = $"Ilość rozwiązań: {SudokuSolver.AllSolutions.Count}";        
        }

        private void ChooseSudokuBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DisplaySudokuGrid(SudokuBook[ChooseSudokuBox.SelectedIndex].Sudoku);

        }
    }
}