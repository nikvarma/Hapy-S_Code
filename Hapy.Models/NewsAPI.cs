using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.Models
{
    public class NewsAPI
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public List<Articles> articles { get; set; }
    }

    public class Articles
    {
        public Source source { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string publishedAt { get; set; }
        public string urlToImage { get; set; }
        public string url { get; set; }
    }

    public class SearchOnSP
    {
        public Guid? Id { get; set; }
        public Guid SearchBy { get; set; }
        public string SearchText { get; set; }
        public string SearchOn { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public bool? Status { get; set; }
        public bool? Active { get; set; }
        public SearchType SearchType { get; set; }
    }

    public class SearchParams : Filter
    {
        public Guid Id { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public SearchType Type { get; set; }
        public string Text { get; set; }
    }

    public class SearchResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ProfileImage { get; set; }
        public SearchResultType Type { get; set; }
    }

    public enum SearchResultType
    {
        Add,
        View,
        Friend,
        Update,
        Delete
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

    public class Source
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}
