using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using static Lb_11.Log.Log;

namespace Lb_11.Pages
{
    internal class FavoritesPage : PageBase.PageBase
    {
        public FavoritesPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsProductInFavorites()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                IWebElement element = Driver.FindElement(By.XPath("//*[@id=\"layoutPage\"]/div[1]/div[2]/div/div[2]/div[5]/div/div/div/div"));
                Info("Product is in favorites.");
                return true;
            }
            catch (NoSuchElementException)
            {
                Info("Product is not in favorites.");
                return false;
            }
        }
    }
    
}
