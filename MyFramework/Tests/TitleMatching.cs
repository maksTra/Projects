using BusinessLogic;
using FrameworkTask;
using MyFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    class TitleMatching
    {
        [Test]
        public void Test_TitleMatching()
        {            
            string query = "{\"QueryString\":\"blood\",\"Products\":[\"PRECOS\"],\"FilterQueries\":[\"AssetType:(article)\"],\"QueryProcessingOptions\":{\"RecencyBoost\":\"None\",\"UseSynonyms\":true,\"BoostFields\":[{\"Name\":\"Title\",\"Value\":3.0},{\"Name\":\"Authors\",\"Value\":4.0}]},\"ResultSpec\":{\"Start\":0,\"CursorMark\":\"*\",\"Rows\":100,\"SortFields\":[{\"Name\":\"PublicationDate\",\"Order\":\"Descending\"}],\"Highlighting\":{\"Fields\":[\"Abstract\"]},\"ReturnFields\":[\"AccessionNumber\",\"AssetType\",\"Title\",\"ImageTitle\",\"ImageWkmrid\",\"OtherIds\",\"EpisodeUrl\",\"ImageID\"],\"Debug\":false}}";
                        
            Browser.Initialize("Chrome");            
            Pages.JournalPage.GotoJournal("plasreconsurg");
            Browser.WaitUntilElementIsDisplayed(Pages.JournalPage.AdvancedSearchButton,20);
            Pages.JournalPage.GotoAdvancedSearch();
            Thread.Sleep(2000);

            Pages.JournalAdvancedSearch.SearchWithData("all_keywords", "content_type_article", "cme");

            Pages.ResultSearchPage.SortByNewest();
            Thread.Sleep(4000);                   
            List<string> titlesFromUI = Pages.ResultSearchPage.GetFirst20Titles();
            var titlesFromJson = JSonGetter.GetSearchResults(query);
            for(int i=0; i<20;i++)
            {
                string a = titlesFromUI[i];
                string b = titlesFromJson[i].Fields[2].FieldValue.ToString();
                Assert.True(a.Contains(b));
            }         
        }
    }
}
