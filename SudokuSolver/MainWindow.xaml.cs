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
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {



        }

        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DifficultySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
