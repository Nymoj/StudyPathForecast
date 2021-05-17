using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyPathForecast.ID3
{
    public class Node
    {
        public List<Node> children { get; set; }
        public string Attribute { get; set; }
        public double Gain { get; set; }
        public string Label { get; set; }
        public string Value;

        public Node()
        {
            children = new List<Node>();
        }
    }
}