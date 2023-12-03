using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static Lb_11.Log.Log;

namespace Lb_11.Pages
{
    internal class SearchResultPage : PageBase.PageBase
    {
        public SearchResultPage(IWebDriver driver) : base(driver)
        {
        }

        public void LikeProduct()
        {
            Driver.FindElement(By.XPath("//*[@id=\"paginatorContent\"]/div/div/div[1]/div[2]/div/button")).Click();
            Info("Product liked.");
        }

        public void GoToFavorites()
        {
            Driver.FindElement(By.XPath("//*[@id=\"stickyHeader\"]/div[3]/a[1]")).Click();
            Info("Going to favorites.");
        }

        public void AddToBasket()
        {
            Driver.FindElement(By.XPath("//*[@id=\"paginatorContent\"]/div/div/div[1]/div[1]/div[4]/div/div/div/button")).Click();
            Info("Product added to basket.");
        }

        public void GoToBasket()
        {
            Driver.FindElement(By.XPath("//*[@id=\"stickyHeader\"]/div[3]/a[2]")).Click();
            Info("Going to basket.");
        }

        public bool isFound()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                IWebElement element = Driver.FindElement(By.XPath("//*[@id=\"paginatorContent\"]/div/div/div[1]"));
                Info("Product is found.");
                return true;
            }
            catch (NoSuchElementException)
            {
                Info("Product is not found.");
                return false;
            }
        }
        public void EnableSales()
        {
            Driver.FindElement(By.XPath("//*[@id=\"layoutPage\"]/div[1]/div[2]/div[2]/div[1]/div/aside/div[2]/div[1]/div/label/div[1]")).Click();
            Info("Sales is enable.");
        }

        public void GoToProduct()
        {
            Driver.FindElement(By.XPath("//*[@id=\"paginatorContent\"]/div/div/div[1]/a")).Click();
            Info("Go to product.");
        }

        public void IncludeDeliveryUpTo3Days()
        {
            Driver.FindElement(By.XPath("//*[@id=\"layoutPage\"]/div[1]/div[2]/div[2]/div[1]/div/aside/div[2]/div[2]/div[2]/div/div[3]/label/span")).Click();
            Info("Delivery up to 3 days is included.");
        }
    }
}
