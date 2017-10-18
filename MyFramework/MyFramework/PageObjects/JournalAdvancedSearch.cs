using BusinessLogic;
using FrameworkTask;
using MyFramework.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyFramework.PageObjects
{
    public class JournalAdvancedSearch : AdvancedSearchPage
    {
        [FindsBy(How = How.XPath, Using = @"//div[@class='searchKeywords']/div[1]/div[@class='adsInputDiv']/input")]
        public IWebElement AllFieldsField { get; set; }

        [FindsBy(How = How.XPath, Using = @"//input[contains(@id, 'filterListArticle')]")]
        public IWebElement ArticlesCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = @"//div[@class='searchKeywords']/div[2]/div[@class='adsInputDiv']/input")]
        public IWebElement TitleField { get; set; }

        [FindsBy(How = How.XPath, Using = @"//input[contains(@id, 'filterListImage')]")]
        public IWebElement ImagesCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = @"//input[contains(@id, 'filterListCME')]")]
        public IWebElement CMECheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = @"//label[contains(@for, 'searchDatesRadioButtonList_0')]")]
        public IWebElement AllDatesRadioButton { get; set; }

        [FindsBy(How = How.XPath, Using = @"//label[contains(@for, 'searchDatesRadioButtonList_4')]")]
        public IWebElement Last5YearsRadioButton { get; set; }

        [FindsBy(How = How.XPath, Using = @"//label[contains(@for, 'AccessRadioButtonList_0')]")]
        public IWebElement AllArticleTypesRadioButton { get; set; }

        [FindsBy(How = How.XPath, Using = @"//label[contains(@for, 'articleAccessRadioButtonList_1')]")]
        public IWebElement OpenAccessOnlyRadioButton { get; set; }
        
        public void SearchWithData(AdvancedSearchOptions aso)
        {                        
            Browser.WaitUntilElementIsDisplayed(AllFieldsField, 5);
            KeywordField.SendKeys(aso.AllFieldsKeyword);
            TitleField.SendKeys(aso.TitleKeyword);
            if((aso.ArticlesChkBox==true && !ArticlesCheckBox.Selected)||(aso.ArticlesChkBox == false && ArticlesCheckBox.Selected))
            {
                ArticlesCheckBox.Click();
            }
            if((aso.CMEChkBox==true && !CMECheckBox.Selected) || (aso.CMEChkBox == false && CMECheckBox.Selected))
            {
                CMECheckBox.Click();
            }
            if((aso.ImagesChkBox==true && !ImagesCheckBox.Selected) || (aso.ImagesChkBox == false && ImagesCheckBox.Selected))
            {
                ImagesCheckBox.Click();
            }
            if(aso.AccessOption == AdvancedSearchOptions.ArticleAccess.OpenAccessOnly)
            {
                OpenAccessOnlyRadioButton.Click();
            }
            if(aso.DateOption == AdvancedSearchOptions.PublicationDates.Last5Years)
            {
                Last5YearsRadioButton.Click();            
            }
            Browser.WaitUntilElementIsDisplayed(SearchButton, 5);
            SearchButton.Click();
        }
    }
}
