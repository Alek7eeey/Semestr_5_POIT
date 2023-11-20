using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb_10.pageobject_model.page
{
    public class FavoritesPage
    {
        private readonly IWebDriver _driver;

        public FavoritesPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public bool IsProductInFavorites()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                IWebElement element = _driver.FindElement(By.XPath("//*[@id=\"layoutPage\"]/div[1]/div[2]/div/div[2]/div[5]/div/div/div/div"));
                _driver.Quit();

                return true;
            }
            catch (NoSuchElementException)
            {
                _driver.Quit();
                return false;
            }
        }
    }
}
