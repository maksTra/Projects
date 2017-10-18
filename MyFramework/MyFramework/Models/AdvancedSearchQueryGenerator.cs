using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Models
{
    public class AdvancedSearchQueryGenerator
    {
        public static string GenerateQuery(AdvancedSearchOptions aso)
        {
            //TBD
            StringBuilder sb = new StringBuilder("");
            if (aso.AllFieldsKeyword != "")
            {
                sb.Append("{\"QueryString\":\""+aso.AllFieldsKeyword+"\",");
            }
            else
            {
                sb.Append("{\"QueryString\":\"Title:("+aso.TitleKeyword+")\",");
            }
            sb.Append("\"Products\":[\"PRECOS\"],\"FilterQueries\":[\"AssetType:(");
            if (aso.ArticlesChkBox==true)
            {
                sb.Append("article");
                if (aso.ImagesChkBox == true)
                {
                    sb.Append("OR");
                }
            }
            if (aso.ImagesChkBox==true)
            {
                sb.Append("figure OR table OR math");
            }
            sb.Append(")");
            if (aso.CMEChkBox==true)
            {
                sb.Append(" AND CME:*");
            }
            if (aso.AccessOption == AdvancedSearchOptions.ArticleAccess.OpenAccessOnly)
            {
                sb.Append(" AND OpenAccess:true");
            }
            sb.Append("\"");
            if (aso.DateOption == AdvancedSearchOptions.PublicationDates.Last5Years)
            {
                DateTime date = DateTime.UtcNow;
                TimeSpan ts = date.AddYears(5) - date;
                DateTime fiveYears = date.Subtract(ts);
                string d = date.ToString("s") + "Z";
                string d5 = fiveYears.ToString("s") + "Z";
                sb.Append(",\"PublicationDateRange:["+ d5 +" TO "+ d +"]\"");
            }
            sb.Append("],\"QueryProcessingOptions\":{\"RecencyBoost\":\"None\",\"UseSynonyms\":true,\"BoostFields\":[{\"Name\":\"Title\",\"Value\":3.0},{\"Name\":\"Authors\",\"Value\":4.0}]},\"ResultSpec\":{\"Start\":0,\"CursorMark\":\"*\",\"Rows\":100,");
            if (aso.SortOption == AdvancedSearchOptions.SortBy.Newest)
            {
                sb.Append("\"SortFields\":[{\"Name\":\"PublicationDate\",\"Order\":\"Descending\"}],");
            }
            else
            {
                sb.Append("\"SortFields\":[{\"Name\":\"PublicationDate\",\"Order\":\"Descending\"}],");
            }
            sb.Append("\"Highlighting\":{\"Fields\":[\"Abstract\"]},\"ReturnFields\":[\"AccessionNumber\",\"AssetType\",\"Title\",\"ImageTitle\",\"ImageWkmrid\",\"OtherIds\",\"EpisodeUrl\",\"ImageID\"],\"Debug\":false}}");
            return sb.ToString();
        }
    }
}
