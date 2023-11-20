using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb_10.pageobject_model.page
{
    public class SearchResultPage
    {
        private readonly IWebDriver _driver;

        public SearchResultPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void LikeProduct()
        {
            _driver.FindElement(By.XPath("//*[@id=\"paginatorContent\"]/div/div/div[1]/div[2]/div/button")).Click();
        }

        public void GoToFavorites()
        {
            _driver.FindElement(By.XPath("//*[@id=\"stickyHeader\"]/div[3]/a[1]")).Click();
        }
    }
}
