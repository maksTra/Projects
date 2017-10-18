using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Models
{
    public class AdvancedSearchOptions
    {
        public string AllFieldsKeyword { get; set; }
        public string TitleKeyword { get; set; }
        public string AuthorKeyword { get; set; }
        public string AbstractKeyword { get; set; }
        public string FullTextKeyword { get; set; }
        public string VolumeKeyword { get; set; }
        public string IssueKeyword { get; set; }
        public bool ArticlesChkBox { get; set; }
        public bool ImagesChkBox { get; set; }
        public bool PodcastChkBox { get; set; }
        public bool VideosChkBox { get; set; }
        public bool CMEChkBox { get; set; }
        public bool SupplementalDigitalContentChkBox { get; set; }
        public SortBy SortOption { get; set; }
        public PublicationDates DateOption { get; set;}
        public ArticleAccess AccessOption { get; set; }

        public enum SortBy
        {
            Newest,
            Oldest,
            Best //default
        }

        public enum PublicationDates
        {
            AllDates,//default                
            CurrentIssue,
            Last12Months,
            Last3Years,
            Last5Years,
            Last8Years
        }

        public enum ArticleAccess
        {
            AllArticleTypes,//default
            OpenAccessOnly
        }

        public SortBy GetSort(string value)
        {
            switch (value)
            {
                case "newest":
                    return SortBy.Newest;
                case "oldest":
                    return SortBy.Oldest;
                case "best":
                    return SortBy.Best;
                default:
                    return SortBy.Newest;
            }
        }

        public PublicationDates GetPublicationDates(string value)
        {
            switch (value)
            {
                case "alldates":
                    return PublicationDates.AllDates;
                case "CurrentIssue":
                    return PublicationDates.CurrentIssue;
                case "last12months":
                    return PublicationDates.Last12Months;
                case "last3years":
                    return PublicationDates.Last3Years;
                case "last5years":
                    return PublicationDates.Last5Years;
                case "last8years":
                    return PublicationDates.Last8Years;
                default:
                    return PublicationDates.AllDates;
            }
        }

        public ArticleAccess GetArticleAccess(string value)
        {
            switch (value)
            {
                case "allarticlestype":
                    return ArticleAccess.AllArticleTypes;
                case "openaccessonly":
                    return ArticleAccess.OpenAccessOnly;                
                default:
                    return ArticleAccess.AllArticleTypes;
            }
        }

        public AdvancedSearchOptions()
        {
            AllFieldsKeyword = "";
            TitleKeyword = "";
            AuthorKeyword = "";
            AbstractKeyword = "";
            FullTextKeyword = "";
            VolumeKeyword = "";
            IssueKeyword = "";
            ArticlesChkBox = false;
            ImagesChkBox = false;
            PodcastChkBox = false;
            VideosChkBox = false;
            CMEChkBox = false;
            SupplementalDigitalContentChkBox = false;
            SortOption = SortBy.Best;
            DateOption = PublicationDates.AllDates;
            AccessOption = ArticleAccess.AllArticleTypes;
        }
    }
}
