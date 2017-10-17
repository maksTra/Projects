using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Models
{
    public class AdvancedSearchData
    {
        public AdvancedSearchOptions GetDataForAdvancedSearch(params string[] testingScenarios)
        {
            AdvancedSearchOptions aso = new AdvancedSearchOptions();
            foreach (string testingScenario in testingScenarios)
            {
                switch (testingScenario)
                {
                    case "all_keywords":
                        aso.AllFieldsKeyword = Data.TestData.all_keywords_field;
                        break;
                    case "title":
                        aso.TitleKeyword = Data.TestData.all_keywords_field;
                        break;
                    case "content_type_article":
                        aso.ArticlesChkBox = true;
                        break;
                    case "content_type_image":
                        aso.ImagesChkBox = true;
                        break;
                    case "cme":
                        aso.CMEChkBox = true;
                        break;
                    case "all_dates":
                        aso.DateOption = aso.GetPublicationDates("alldates");
                        break;
                    case "open_access":
                        aso.AccessOption = aso.GetArticleAccess("openaccessonly");
                        break;
                    case "sort_by_newest":
                        aso.SortOption = aso.GetSort("newest");
                        break;
                    case "sort_by_best":
                        aso.SortOption = aso.GetSort("best");
                        break;
                    default:
                        break;
                }                
            }
            return aso;
        }
    }
}
