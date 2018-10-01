using Hapy.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hapy.Models;

namespace Hapy.MiddelLayer
{
    public class NewsAPI : DbCommands<DB.NewsAPI>, INewsAPI
    {
        private DbCommands<DB.NewsAPI> _dbCommands { get; set; }
        public NewsAPI()
        {
            _dbCommands = new DbCommands<DB.NewsAPI>();
        }

        public bool Insert(List<Articles> newsList)
        {
            foreach (var item in newsList)
            {
                DB.NewsAPI newsAPI = new DB.NewsAPI()
                {
                    Nauthor = item.author,
                    Nname = item.source.name,
                    NUrlid = item.source.id,
                    Ndescription = item.description,
                    NpublishedAt = item.publishedAt,
                    Ntitle = item.title,
                    Nurl = item.url,
                    NurlToImage = item.urlToImage
                };
                _dbCommands.Insert(newsAPI);
            }
            return _dbCommands.Save();
        }

        public SearchUsers SearchUser(SearchOnSP search)
        {
            return _dbCommands.GetOnSP<SearchUsers>
                ("searchSP_Users @searchBy, @searchTxt, @searchOn, @searchType, @pageNumber, @pageSize, @id, @searchStatus, @searchIsActive", search.SearchBy, search.PageNumber, search.PageSize, search.Id, search.SearchText, search.SearchOn, search.SearchType, search.Active, search.Status).SingleOrDefault();
        }

        public IEnumerable<SearchResult> Search(SearchParams search)
        {
            List<SearchResult> searchData = new List<SearchResult>();
            return searchData;
        }
    }
}