using BusinessLogic;
using FrameworkTask;
using MyFramework;
using MyFramework.Steps;
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
            Browser.Initialize("Chrome");

            AdvancedSearchSteps ass = new AdvancedSearchSteps("all_keywords", "content_type_article", "last_5_years");
            ass.ChooseAdvancedSearchInJournal("plasreconsurg");
            var titlesFromUI = ass.GetArticleTitlesFromUI();
            var resultsFromJson = ass.GetArticlesFromAPI();

            for(int i=0; i<8;i++)
            {
                string a = titlesFromUI[i];
                string b = resultsFromJson[i].Fields[2].FieldValue.ToString();
                Assert.True(a.Contains(b));
            }         
        }
    }
}
