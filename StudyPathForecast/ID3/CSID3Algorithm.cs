using StudyPathForecast.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudyPathForecast.ID3
{
    public class CSID3Algorithm
    {
        /*/// <summary>
        /// Stores attributes as keys and its features as values
        /// </summary>
        private Dictionary<string, string[]> attributes = new Dictionary<string, string[]>() {
            { "Is5PointsMathStudent", new string[] { "yes", "no" } },
            { "Is4PointsMathStudent", new string[] { "yes", "no" } },
            { "Is5PointsEnglishStudent", new string[] { "yes", "no" } },
            { "Is4PointsEnglishStudent", new string[] { "yes", "no" } },
            { "IsArtStudent", new string[] { "yes", "no" } },
            { "IsPhysicsStudent", new string[] { "yes", "no" } },
            { "ChosenPath", new string[] { "Biology", "Chemistry", "CS", "Physics" } },
            //{ "AvgGrade", new string[] { "Low", "Normal", "High" } },
        };

        /// <summary>
        /// Stores the target of the prediction, i.e. whether the student should learn Biology
        /// </summary>
        private string target;

        public DecisionTreeBuilder(string target)
        {
            this.target = target;
        }

        public int GetPositiveFromDataset()
        {
            SqlCommand cmd = new SqlCommand("SELECT ChosenPath FROM UserData WHERE ChosenPath=@Target;", Connections.Connection);

            cmd.Parameters.AddWithValue("@Target", target);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt.Rows.Count;
        }

        public int GetNegativeFromDataset()
        {
            SqlCommand cmd = new SqlCommand("SELECT ChosenPath FROM UserData WHERE ChosenPath!=@Target OR ChosenPath IS NULL;", Connections.Connection);

            cmd.Parameters.AddWithValue("@Target", target);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt.Rows.Count;
        }

        public int GetPositiveFromDataset(string attribute)
        {
            SqlCommand cmd = new SqlCommand("SELECT ChosenPath FROM UserData WHERE ChosenPath=@Target AND;", Connections.Connection);

            cmd.Parameters.AddWithValue("@Target", target);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt.Rows.Count;
        }

        /// <summary>
        /// Calculates entropy of the whole dataset
        /// </summary>
        /// <returns></returns>
        public double FindEntropy()
        {
            double entropy = 0;

            int p = GetPositiveFromDataset();
            int n = GetNegativeFromDataset();
            int sum = p + n;

            double pfraction = (double)p / sum;
            double nfraction = (double)n / sum;

            entropy = -pfraction * Math.Log(pfraction, 2) - nfraction * Math.Log(nfraction, 2);

            return entropy;
        }

        public double FindAttributeEntropy(string attribute)
        {
            return 0;
        }*/

        public static Node Root { get; set; }

        public Node ID3(List<CSModel> rows, List<string> attributes, string branchLabel)
        {
            if (AllPositive(rows))
            {
                return new Node() { Label = CSModel.Positive, Value = branchLabel };
            }
            if (AllNegative(rows))
            {
                return new Node() { Label = CSModel.Negative, Value = branchLabel };
            }
            if (attributes == null)
            {
                return new Node() { Label = MostPosOrNeg(rows), Value = branchLabel };
            }

            Node root = new Node();
            GainTuple gt = MaxGainAttribute(rows, attributes);
            root.Attribute = gt.attribute;
            root.Gain = gt.gain;
            root.Value = branchLabel;

            foreach (string value in PossibleValues(rows, gt.attribute))
            {
                List<CSModel> rest = rows.Where(x => x.ValueByField(root.Attribute) == value).ToList();
                if (rest.Count == 0)
                {
                    root.children.Add(new Node() { Label = MostPosOrNeg(rows), Value = value });
                }
                else
                {
                    root.children.Add(ID3(rest, attributes.Except(new List<string>() { root.Attribute }).ToList(), value));
                }
            }
            return root;
        }

        private string MostPosOrNeg(List<CSModel> rows)
        {
            int pos = rows.Where(CSModel.Success).Count();
            int neg = rows.Count - pos;
            if (pos > neg) { return CSModel.Positive; }
            else if (neg > pos) { return CSModel.Negative; }
            else { return String.Format("{0} and {1} Equally Likely", CSModel.Positive, CSModel.Negative); }

        }

        /// <summary>
        /// If all rows in a set contains a 'successful' outcome according to CSModel.Success()
        /// </summary>
        /// <param name="rows">the set of rows</param>
        /// <returns>true if all are positive</returns>
        private bool AllPositive(List<CSModel> rows)
        {
            foreach (CSModel row in rows)
            {
                if (!CSModel.Success(row)) { return false; }
            }
            return true;
        }

        private bool AllNegative(List<CSModel> rows)
        {
            foreach (CSModel row in rows)
            {
                if (CSModel.Success(row)) { return false; }
            }
            return true;
        }


        private GainTuple MaxGainAttribute(List<CSModel> rows, List<string> attrs)
        {
            List<GainTuple> gains = new List<GainTuple>();
            foreach (string attr in attrs)
            {
                gains.Add(new GainTuple { gain = Gain(rows, attr), attribute = attr });
            }
            return gains.OrderByDescending(x => x.gain).First();
        }

        /// <summary>
        /// Fraction calculation
        /// </summary>
        /// <param name="set"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        private double Prob(List<CSModel> set, Func<CSModel, bool> predicate)
        {
            double tot = set.Where(x => predicate(x)).Count();
            double selection = set.Where(x => predicate(x) && CSModel.Success(x)).Count();
            return selection / tot;
        }

        private double Entropy(List<CSModel> set, Func<CSModel, bool> predicate)
        {
            // the fraction
            double prob = Prob(set, predicate);
            // final result, entropy
            double e;
            if (prob == 0) { e = 0; }
            else if (prob == 1) { e = 0; }
            else
            {
                e = e_vlad(prob);
            }
            return e;
        }

        private double e_vlad(double prob)
        {
            return (prob * Math.Log(1 / prob, 10)) + ((1 - prob) * Math.Log(1 / (1 - prob), 10));
        }

        /*private double e_internet(double prob)
        {
            return -(prob * Math.Log(prob, 2)) - ((1 - prob) * Math.Log((1 - prob), 2));
        }*/

        private double Gain(List<CSModel> set, string attr)
        {
            double g = 0;
            List<string> values = PossibleValues(set, attr);

            // Entropy for the whole set.
            g += Entropy(set, (x => true));
            //The entropies of the classes of the attribute   
            foreach (string value in values)
            {
                g -= (((double)set.Select(x => x).Where(row => row.ValueByField(attr) == value).Count() / (double)set.Count()) * Entropy(set, (row => row.ValueByField(attr) == value)));
            }
            //Console.WriteLine()
            return g;
        }

        private List<string> PossibleValues(List<CSModel> set, string attr)
        {
            List<string> values = new List<string>();
            set.ForEach(x => values.Add(x.ValueByField(attr)));
            values = values.Select(x => x).Distinct().ToList();
            return values;
        }
    }

    /// <summary>
    /// GainTuple stores the gain value and its attribute
    /// </summary>
    class GainTuple {
        public double gain;
        public string attribute;
    }
}