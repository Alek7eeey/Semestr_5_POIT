using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static Lb_11.Log.Log;

namespace Lb_11.Pages
{
    internal class PickUpPointPage : PageBase.PageBase
    {
        private readonly string _baseUrl = "https://ozon.by/info/map/";
        public PickUpPointPage(IWebDriver driver) : base(driver)
        {
        }

        public void Open()
        {
            Driver.Navigate().GoToUrl(_baseUrl);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            Info("PickUpPoint page opened.");
        }

        public void Search(string adress)
        {
            Info("Searching for " + adress);
            IWebElement searchInput = Driver.FindElement(By.XPath("//*[@id=\"layoutPage\"]/div[1]/div[2]/div[4]/div/div[1]/div/div/div/div/div/div/form/div/div/fieldset/div[1]/div/div/div/label/div[1]/div/textarea"));
            searchInput.Click();
            searchInput.SendKeys(adress);
            searchInput.SendKeys(Keys.Enter);
            Info("Search completed.");
        }

        public bool isFound()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                //Driver.FindElement(By.XPath("/html/body/div[4]/div/div/div/div"));
                Driver.Quit();
                Info("PickUpPoint found.");
                return true;
            }
            catch (NoSuchElementException)
            {
                Driver.Quit();
                Info("PickUpPoint not found.");
                return false;
            }
        }
    }
}
