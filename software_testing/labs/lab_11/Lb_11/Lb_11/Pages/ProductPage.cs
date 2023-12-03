using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using static Lb_11.Log.Log;

namespace Lb_11.Pages
{
    internal class ProductPage : PageBase.PageBase
    {
        public ProductPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsThereADescription()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                IWebElement element = Driver.FindElement(By.XPath("//*[@id=\"layoutPage\"]/div[1]/div[5]/div/div[1]/div[3]/div[2]/div[1]/div/div[1]"));
                Info("Description is found");
                return true;
            }
            catch (NoSuchElementException)
            {
                Info("Description is not in found.");
                return false;
            }
        }
    }

}