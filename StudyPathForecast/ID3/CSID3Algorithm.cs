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
            else { return String.Format("{0} ו{1} שווים בהסתברותם", CSModel.Positive, CSModel.Negative); }

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
        private double Fraction(List<CSModel> set, Func<CSModel, bool> predicate)
        {
            double tot = set.Where(x => predicate(x)).Count();
            double selection = set.Where(x => predicate(x) && CSModel.Success(x)).Count();
            return selection / tot;
        }

        private double Entropy(List<CSModel> set, Func<CSModel, bool> predicate)
        {
            // the fraction
            double fraction = Fraction(set, predicate);
            // final result, entropy
            double e = 0;

            if (fraction == 0) { e = 0; }
            else if (fraction == 1) { e = 0; }
            else
            {
                e = EntropyExp(fraction);
            }
            return e;
        }

        /// <summary>
        /// The expression to calculate entropy
        /// </summary>
        /// <param name="prob">The probability</param>
        /// <returns></returns>
        private double EntropyExp(double fraction)
        {
            return -(fraction * Math.Log(fraction, 2)) - ((1 - fraction) * Math.Log((1 - fraction), 2));
        }

        /// <summary>
        /// Calculates the inforamtion gain of an attribute
        /// </summary>
        /// <param name="set">The set to be used</param>
        /// <param name="attr">The attribute</param>
        /// <returns></returns>
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

        /// <summary>
        /// Finds all values that are present in the set for the attribute
        /// For example: Is5PointsMathStudent - will be the attribute and
        /// "Yes" or "No" will be the possible values for the attribute
        /// </summary>
        /// <param name="set"></param>
        /// <param name="attr"></param>
        /// <returns></returns>
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