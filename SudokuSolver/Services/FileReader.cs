
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Microsoft.Win32;

namespace Algorytm_Ewolucyjny.Services
{
    public class FileReader
    {
        private readonly string FILEPATH_ERROR = "Problem With filePath";



        public FileReader()
        {

        }

        private string ChooseFileToOpen()
        {
            string filePath;
            Win32.OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "D:\\gitProjects\\SI_Lab1\\",
                Filter = "File Type (*.fileType)|*.fileType|All files (*.*)| *.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                filePath = openFileDialog.FileName;
            }
            else
            {
                filePath = FILEPATH_ERROR;
            }

            return filePath;

        }

        private void LoadObject(string filePath)
        {
            string[] fileData;

            if (filePath != FILEPATH_ERROR)
            {
                fileData = File.ReadAllLines(filePath);


            }
            else
            {

                throw new Exception("problem getting filePath");

            }


        }

        public bool LoadData()
        {
            bool result;
            string filePath = ChooseFileToOpen();
            result = LoadObject(filePath);
            return result;

        }



        public void SaveFile(List<(double BestScore, double AvarageScore, double WorstScore)> Scores)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Zapisz wyniki algorytmu";
            saveFileDialog.FileName = "wyniki_algorytmu";
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.AddExtension = true;
            saveFileDialog.ShowDialog();
            // If the file name is not an empty string open it for saving.
            if (saveFileDialog.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                using Stream fs = saveFileDialog.OpenFile();

                using StreamWriter streamWriter = new StreamWriter(fs);

                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.



                streamWriter.WriteLine(ScoresString(Scores));

                //File.WriteAllText(saveFileDialog.FileName, ddd);




            }
        }


        #region privateMethods





        #endregion
    }
}
