using Microsoft.Win32;
using SudokuSolver.Global;
using SudokuSolver.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Algorytm_Ewolucyjny.Services
{
    public class FileReader
    {
        public string[] LoadRawSudoku(string filePath)
        {
            string[] fileData;

            if (filePath != Globals.FILEPATH_ERROR)
            {
                fileData = File.ReadAllLines(filePath);
            }
            else
            {
                throw new Exception("problem getting filePath");
            }

            return fileData;
        }

        public SudokuBook LoadData()
        {
            string filePath = ChooseFileToOpen();
            var rawData = LoadRawSudoku(filePath);

            return CreateSudokuBook(rawData);
        }

        public SudokuBook FirstLoad()
        {
            var rawData = LoadRawSudoku(Globals.FILEPATH_DEFAULT_SUDOKU);

            return CreateSudokuBook(rawData);
        }

        private SudokuBook CreateSudokuBook(string[] rawData)
        {
            var sudokuBook = new SudokuBook();

            for (int i = 1; i < rawData.Length; i++)
            {
                var line = rawData[i].Split(';');

                var id = int.Parse(line[0]);

                var difficulty = double.Parse(line[1].Replace('.', ','));

                var grid = GridParser(line[2]);

                sudokuBook.Add((Id: id, Difficulty: difficulty, Sudoku: new Sudoku(grid)));
            }

            return sudokuBook;
        }

        private int[,] GridParser(string gridRaw)
        {
            var grid = new int[Globals.SUDOKU_SIZE, Globals.SUDOKU_SIZE];

            var gridChar = gridRaw.ToCharArray();

            var index = 0;

            for (int i = 0; i < Globals.SUDOKU_SIZE; i++)
            {
                for (int j = 0; j < Globals.SUDOKU_SIZE; j++)
                {
                    grid[j, i] = (int)char.GetNumericValue(gridChar[index].Equals('.') ? '0' : gridChar[index]);
                    index++;
                }
            }
            return grid;
        }

        public void SaveFile(List<(double BestScore, double AvarageScore, double WorstScore)> Scores)
        {
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Zapisz wyniki algorytmu";
            saveFileDialog.FileName = "wyniki_algorytmu";
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.AddExtension = true;
            saveFileDialog.ShowDialog();
           
            if (saveFileDialog.FileName != "")
            {
               
                using Stream fs = saveFileDialog.OpenFile();

                using StreamWriter streamWriter = new StreamWriter(fs);

            }
        }

        #region privateMethods

        private string ChooseFileToOpen()
        {
            string filePath;
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "D:\\gitProjects\\SI_Lab2v2\\SudokuSolver\\Resources\\",
                Filter = "excel Files (*.csv)|*.csv|All files (*.*)| *.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                filePath = openFileDialog.FileName;
            }
            else
            {
                filePath = Globals.FILEPATH_ERROR;
            }

            return filePath;
        }

        #endregion privateMethods
    }
}