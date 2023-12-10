using Accord.Statistics.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.MachineLearning.DecisionTrees;
using Accord.Math;
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.Math.Optimization.Losses;
using TDT.Core.Models;
using TDT.QLDV.Models.QLDVTableAdapters;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using Microsoft.SqlServer.Server;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Accord.IO;

namespace TDT.QLDV.Ultils
{
    public class Algorithms
    {
        public static class DecisionTree_ID3
        {
            private static readonly int ROWCOUNT = 1000;
            private static Models.DataBindings _bindings = Models.DataBindings.Instance;
            public static Codification codebook;
            public static DecisionTree tree;
            public static DataTable data;
            private static DataTable symbols;
            private static int[][] inputs;
            private static int[] outputs;

            public static void ProcessingData()
            {
                codebook = new Codification(data);
                ReloadDataCodebook();
            }
            public static void ReloadDataCodebook()
            {
                //codebook = new Codification(data);

                // Translate our training data into integer symbols using our codebook:
                //data.PrimaryKey = null;
                symbols = codebook.Apply(data);
                inputs = symbols.ToJagged<int>("msg");
                outputs = symbols.ToArray<int>("violate");
            }
            public static void TrainingData()
            {
                //UsersTableAdapter da = new UsersTableAdapter();
                //DataTable data = da.GetData();
                
                new Thread(() =>
                {
                    //data = GetDataTableFromExcel(@"D:\HK\HK7\CSPC2.xlsx");
                    ProcessingData();
                    
                    // For this task, in which we have only categorical variables, the simplest choice 
                    // to induce a decision tree is to use the ID3 algorithm by Quinlan. Let’s do it:

                    DecisionVariable[] attributes = DecisionVariable.FromCodebook(codebook,
                        "msg"
                        );

                    // Create a teacher ID3 algorithm
                    var id3learning = new ID3Learning(attributes);

                    // Learn the training instances!
                    tree = id3learning.Learn(inputs, outputs);

                    // Compute the training error when predicting training instances
                    double error = new ZeroOneLoss(outputs).Loss(tree.Decide(inputs));
                }).Start();
                
            }
            public static string MakeDecision(string[,] inputs)
            {
                try
                {
                    //ReloadDataCodebook();

                    // The tree can now be queried for new examples through 
                    // its decide method. For example, we can create a query

                    int[] query = codebook.Transform(inputs);

                    // And then predict the label using
                    int predicted = tree.Decide(query);

                    // We can translate it back to strings using
                    string answer = codebook.Revert("violate", predicted);

                    return answer;
                }
                catch (Exception ex)
                {
                    return "-1";
                }
                
            }
            public static string[,] GetInputs(string msg)
            {
                return new[,]{
                        {"msg", msg.ToString()}
                    };
            }
            public static void SaveCodebook(string filePath)
            {
                codebook.Save(filePath);
            }
            public static void ImportCodebook(string filePath)
            {
                codebook = Accord.IO.Serializer.Load<Codification>(filePath);
            }
            public static void SaveModel(string filePath)
            {                
                // Serialize the tree
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    formatter.Serialize(stream, tree);
                }

                //tree.Save();
            }
            public static void ImportModel(string filePath)
            {
                //tree = Accord.IO.Serializer.Load<DecisionTree>(filePath);

                // Deserialize the tree
                DecisionTree deserializedTree;
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
                {
                    deserializedTree = (DecisionTree)formatter.Deserialize(stream);
                }
                tree = deserializedTree;
            }
            public static DataTable GetDataTableFromExcel(string filePath)
            {
                _bindings.progressBar.Invoke(new MethodInvoker(delegate
                {
                    _bindings.progressBar.Value = 0;
                    _bindings.progressBar.Maximum = ROWCOUNT;
                }));

                // Create a new Excel application
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(filePath);

                // Assuming the data is in the first worksheet (index 1)
                Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];
                Excel.Range excelRange = excelWorksheet.UsedRange;

                // Get the number of rows and columns
                //int rowCount = excelRange.Rows.Count;
                int rowCount = ROWCOUNT;
                int colCount = excelRange.Columns.Count;

                // Create a DataTable to store the data
                DataTable dataTable = new DataTable();

                // Add columns to the DataTable
                for (int col = 1; col <= colCount; col++)
                {
                    DataColumn column = new DataColumn((string)(excelRange.Cells[1, col] as Excel.Range).Value);
                    dataTable.Columns.Add(column);
                }

                // Add data rows to the DataTable
                for (int row = 2; row <= rowCount; row++)
                {
                    _bindings.progressBar.Invoke(new MethodInvoker(delegate
                    {
                        _bindings.progressBar.Value = row;
                    }));
                    Console.WriteLine("read line " + row);
                    DataRow dataRow = dataTable.NewRow();
                    for (int col = 1; col <= colCount; col++)
                    {
                        dataRow[col - 1] = (excelRange.Cells[row, col] as Excel.Range).Value;
                    }
                    dataTable.Rows.Add(dataRow);
                }

                // Close Excel
                excelWorkbook.Close(false);
                excelApp.Quit();

                // Release COM objects to avoid memory leaks
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                return dataTable;
            }
        }
    }
}
