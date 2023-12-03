using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using static Lb_11.Log.Log;

namespace Lb_11.Pages
{
    internal class BasketPage :PageBase.PageBase
    {
        public BasketPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsProductInBasket()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                IWebElement element = Driver.FindElement(By.XPath("//*[@id=\"layoutPage\"]/div[1]/div/div/div[2]/div[4]/div[1]/div/div/div[2]/div/div/div[2]/div[1]"));
                Info("Product is in basket.");
                return true;
            }
            catch (NoSuchElementException)
            {
                Info("Product is not in basket.");
                return false;
            }
        }
    }
}
