using BusinessLogic;
using FrameworkTask;
using MyFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyFramework.Steps
{
    public class AdvancedSearchSteps
    {
        private AdvancedSearchOptions aso;
        private AdvancedSearchData asd;        

        public AdvancedSearchSteps(params string[] testScenarios)
        {
            asd = new AdvancedSearchData();
            aso = asd.GetDataForAdvancedSearch(testScenarios);            
        }

        public List<JsonResult> GetArticlesFromAPI()
        {
            string query = AdvancedSearchQueryGenerator.GenerateQuery(aso);
            List<JsonResult> results = JSonGetter.GetSearchResults(query);
            return results;
        }

        //Depends on testScenarios: method returns results(titles) of advanced search
        public List<string> GetArticleTitlesFromUI()
        {            
            Pages.JournalAdvancedSearch.SearchWithData(aso);
            Pages.ResultSearchPage.SortByNewest();//TODO: change logic in SortByNewest to just SortBy
            Thread.Sleep(3000); //waiting for sorting
            List<string> titlesFromUI = Pages.ResultSearchPage.GetFirst20Titles();
            return titlesFromUI;
        }

        public void ChooseAdvancedSearchInJournal(string journalName)
        {
            Pages.JournalPage.GotoJournal(journalName);
            Browser.WaitUntilElementIsDisplayed(Pages.JournalPage.AdvancedSearchButton, 20);
            Pages.JournalPage.GotoAdvancedSearch();
            Thread.Sleep(2000);
        }
    }
}
