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

namespace TDT.QLDV.Ultils
{
    public class Algorithms
    {
        public static class DecisionTree_ID3
        {
            public static Codification codebook;
            public static DecisionTree tree;
            public static void TrainingData()
            {
                UsersTableAdapter da = new UsersTableAdapter();

                DataTable data = da.GetData();

                codebook = new Codification(data);

                // Translate our training data into integer symbols using our codebook:
                data.PrimaryKey = null;
                DataTable symbols = codebook.Apply(data);
                int[][] inputs = symbols.ToJagged<int>("AccessFailedCount");
                int[] outputs = symbols.ToArray<int>("LockoutEnabled");

                // For this task, in which we have only categorical variables, the simplest choice 
                // to induce a decision tree is to use the ID3 algorithm by Quinlan. Let’s do it:

                DecisionVariable[] attributes = DecisionVariable.FromCodebook(codebook,
                    "AccessFailedCount"
                    );

                // Create a teacher ID3 algorithm
                var id3learning = new ID3Learning(attributes);

                // Learn the training instances!
                tree = id3learning.Learn(inputs, outputs);

                // Compute the training error when predicting training instances
                double error = new ZeroOneLoss(outputs).Loss(tree.Decide(inputs));
            }
            public static string MakeDecision(string[,] inputs)
            {
                // The tree can now be queried for new examples through 
                // its decide method. For example, we can create a query

                int[] query = codebook.Transform(inputs);

                // And then predict the label using
                int predicted = tree.Decide(query);

                // We can translate it back to strings using
                string answer = codebook.Revert("LockoutEnabled", predicted);

                return answer;
            }
            public static string[,] GetInputs(int accessFailedCount, bool emailConfirmed, bool phoneNumberConfirmed)
            {
                return new[,]{
                        {"AccessFailedCount", accessFailedCount.ToString()},
                        {"EmailConfirmed", emailConfirmed.ToString()},
                        {"PhoneNumberConfirmed", phoneNumberConfirmed.ToString()}
                    };
            }
        }
    }
}
