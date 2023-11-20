using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb_10.pageobject_model.page
{
    public class MainPage
    {
        private readonly IWebDriver _driver;
        private readonly string _baseUrl = "https://ozon.by/";

        public MainPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void Open()
        {
            _driver.Navigate().GoToUrl(_baseUrl);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
        }

        public void Search(string searchText)
        {
            IWebElement searchInput = _driver.FindElement(By.XPath("//*[@id=\"stickyHeader\"]/div[2]/div/div/form/div[1]/div[2]/input[1]"));
            searchInput.Click();
            searchInput.SendKeys(searchText);
            searchInput.SendKeys(Keys.Enter);
        }

        public SearchResultPage SelectProduct()
        {
            _driver.FindElement(By.XPath("//*[@id=\"paginatorContent\"]/div/div/div[1]/div[2]/div/button")).Click();
            _driver.FindElement(By.XPath("//*[@id=\"stickyHeader\"]/div[3]/a[1]")).Click();
            return new SearchResultPage(_driver);
        }
    }
}
