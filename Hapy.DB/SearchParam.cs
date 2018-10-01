using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DB
{
    public class SearchParam
    {
        public Guid Id { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public SearchType Type { get; set; }
        public string Text { get; set; }
        public IEnumerable<string> CloumnName { get; set; }
        public IEnumerable<string> ColumnValue { get; set; }
    }

    public class Pagging
    {
        public int TotalPageCount { get; set; }
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
    }

    public enum SearchType
    {
        User,
        Post,
        News,
        Group,
        Location,
        Work
    }
}
