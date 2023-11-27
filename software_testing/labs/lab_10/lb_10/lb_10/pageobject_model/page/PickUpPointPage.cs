using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb_10.pageobject_model.page
{
    public class PickUpPointPage
    {
        private readonly IWebDriver _driver;
        private readonly string _baseUrl = "https://ozon.by/info/map/";

        public PickUpPointPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void Open()
        {
            _driver.Navigate().GoToUrl(_baseUrl);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
        }

        public void Search(string adress) 
        {
            IWebElement searchInput = _driver.FindElement(By.XPath("//*[@id=\"layoutPage\"]/div[1]/div[2]/div[4]/div/div[1]/div/div/div/div/div/div/form/div/div/fieldset/div[1]/div/div/div/label/div[1]/div/textarea"));
            searchInput.Click();
            searchInput.SendKeys(adress);
            searchInput.SendKeys(Keys.Enter);
        }

        public bool isFound()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                _driver.FindElement(By.XPath("/html/body/div[4]/div/div/div/div"));
                _driver.Quit();
                return true;
            }
            catch(NoSuchElementException) 
            {
                _driver.Quit();
                return false;
            }
        }
    }
}
