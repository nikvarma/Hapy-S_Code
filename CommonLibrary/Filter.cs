using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class Filter
    {
        public IDictionary<string, FilterCondition> FilterOn { get; set; }
        public string SelectFileds { get; set; }
    }

    public class FilterCondition
    {
        public string Value { get; set; }
        public Condition Condition { get; set; }
        public Operation Operation { get; set; }
    }
    public enum Condition
    {
        And,
        Or,
        OrElse,
        AndAlso
    }
    public enum Operation
    {
        EqualTo,
        Contains,
        StartsWith,
        EndsWith,
        NotEqualTo,
        GreaterThan,
        GreaterThanOrEqualTo,
        LessThan,
        LessThanOrEqualTo
    }
}
